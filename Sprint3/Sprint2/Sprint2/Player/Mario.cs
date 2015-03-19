using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Player.MarioState;
using Sprint2.Player.SpecialMarioState;
using Sprint2.Collision;
using Sprint2.Player.Attacks;
using Sprint2.Player.PlayerPhysics;
using Sprint2.GameState;
using Sprint2.Cameras;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.Objects.DeadBodies.Player;
using Sprint2.Sound;

namespace Sprint2.Player
{
    class Mario : IPlayer
    {
        PlayerStats playerStats;
        Texture2D marioSprite;
        public IMarioState state = new smallRightFacingIdle();
        int xPos;
        int yPos;
        ISpecialState specialState = new notSpecialState();
        MariosFireBall FB;
        MarioPhysics physics;
        bool alive = true;
        bool flagpole;

        bool isAttacking= false;
        bool hasAttacked = false;

        bool isPressingDown = false;
        bool wasPressingDown = false;

        SoundController sc = new SoundController();
        //old collision tester
        //CollisionTester test = new CollisionTester();

        public Mario(Texture2D texture, int x, int y, IMarioState marioState) 
        {
            marioSprite = texture;
            xPos = x;
            yPos = y;
            state = marioState;
            flagpole = false;
            FB = new MariosFireBall(this);
            physics = new MarioPhysics(this, x, y);
        }
        public void Idle()
        {
            state = state.Idle();
        }

        public void Jump()
        {
            
            physics.PressingUp();
            if(physics.IsJumping())
                state = state.Jump();
            //Old Collision testing
            //if (test.playerLevelObjectCollisionTest(GetRectangle()))
            //    yPos++;
        }

        public void Crouch()
        {
            state = state.Crouch();
            physics.PressingDown();
            //Old Collision testing
            //if (test.playerLevelObjectCollisionTest(GetRectangle()))
            //    yPos--;

            isPressingDown = true;
        }

        public void Left()
        {
            state = state.Left();
            physics.PressingLeft();
            //Old Collision testing
            //while (test.playerLevelObjectCollisionTest(GetRectangle()))
            //   xPos++;
        }

        public void Right()
        {
            state = state.Right();
            physics.PressingRight();
            //Old Collision testing
            //while (test.playerLevelObjectCollisionTest(GetRectangle()))
            //    xPos--;
        }

        public void Attack() 
        {
            if(!hasAttacked)
                state.Attack(FB);
            physics.Running();
            isAttacking = true;
        }

        public void Mushroom()
        {
            IMarioState oldState = state;
            state = state.Mushroom();
            if(oldState != state)
            new PlayerStateTransitions(this, oldState, state);
            //Old Collision testing
            //if (test.playerLevelObjectCollisionTest(GetRectangle()))
            //{
            //    specialState = new notSpecialState();
            //    this.Damaged();
            //}

        }

        public void Fire()
        {
            IMarioState oldState = state;
            state = state.Fire();
            if (oldState != state)
                new PlayerStateTransitions(this, oldState, state);
            //Old Collision testing
            //if (test.playerLevelObjectCollisionTest(GetRectangle()))
            //{
            //    specialState = new notSpecialState();
            //    this.Damaged();
            //    specialState = new notSpecialState();
            //    this.Damaged();
            //}

        }

        public void Damaged() 
        {
            if (specialState.damageable() && !state.ToString().Equals(new dead().ToString()))
            {
                IMarioState oldState = state;
                state = state.damaged();
                if (oldState != state && !state.ToString().Equals("dead"))
                    new PlayerStateTransitions(this, oldState, state);
                specialState = specialState.damaged();
            }
        }

        public void Death()
        {
            state = new dead();
            //specialState = new notSpecialState();
        }

        public void Update()
        {
            state.update();
            specialState = specialState.update();
            FB.Update();

            physics.Update();
            Tuple<int, int> location = physics.GetLocation();
            xPos = location.Item1;
            yPos = location.Item2;
           // test.playerEnemyCollisionTest(this,GetRectangle(),specialState.ToString().Equals(new StarState().ToString()));
           // test.playerItemCollisionTest(this, GetRectangle());

            if (yPos > 480)
            {
                Death();
            }

            if (state.ToString().Equals("dead") && alive)
            {
                alive = false;
                playerStats.Died();
                sc.PlayerDeath();
                AddElementList ad = new AddElementList();
                Rectangle refRectangle = state.getReferenceRectangle();
                ad.Add(new DeadMario(xPos, yPos + refRectangle.Height, marioSprite));
            }

            hasAttacked = isAttacking;
            isAttacking = false;

            wasPressingDown = isPressingDown;
            isPressingDown = false;
        }

        public void Star() 
        {
            if (!state.ToString().Equals(new dead().ToString()))
            specialState = new StarState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle spriteRef = state.getReferenceRectangle();
            Color color = specialState.GetColor();
            Camera camera = new Camera();
            spriteBatch.Draw(marioSprite, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, color);
        }

        public bool IsStar()
        {
            return specialState.ToString().Equals(new StarState().ToString());
        }

        public Rectangle GetRectangle()
        {
            Rectangle spriteRef = state.getReferenceRectangle();
            return new Rectangle(xPos, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height);
        }

        public Rectangle GetWeakSpot() 
        {
            Rectangle spriteRef = state.getReferenceRectangle();
            return new Rectangle(xPos, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height);
        }



        public void ShiftUp()
        {
            yPos--;
            physics.ShiftUp();
        }

        public void ShiftDown()
        {
            yPos++;
            physics.ShiftDown();
        }

        public void ShiftLeft()
        {
            xPos--;
            physics.ShiftLeft();
        }

        public void ShiftRight()
        {
            xPos++;
            physics.ShiftRight();
        }

        public override string ToString()
        {
            return state.ToString();
        }


        public bool IsPressingDown()
        {
            return wasPressingDown;
        }

        public void SetXYPos(int x, int y)
        {
            xPos = x;
            yPos = y;
            physics = new MarioPhysics(this, x, y);
            flagpole = false;
        }


        public void SetPlayerStats(PlayerStats p)
        {
            playerStats = p;
        }


        public void GainedCoin()
        {
            playerStats.GetCoin();
            playerStats.AddScore(200);
            sc.Coin();
        }

        public void AddScore(int s)
        {
            playerStats.AddScore(s);
        }

        public void Bounce()
        {
            physics.Bounce();
        }


        public Rectangle GetSpriteRefRectangle()
        {
            return state.getReferenceRectangle();
        }

        public void Flagpole(int score)
        {
            if (!flagpole)
            {
                AddScore(score);
                Console.WriteLine("Added flagpole score:" +score);
                state = state.Flagpole();
                flagpole = true;
                physics.Flagpole();
                PlayerFlagpoleState pfs = new PlayerFlagpoleState(this);
            }
        }


        public void Reset()
        {
            state = new smallRightFacingIdle();
            specialState = new notSpecialState();
            alive = true;
            flagpole = false;
        }

        public bool IsDead()
        {
            return !alive;
        }


        public Texture2D GetTexture()
        {
            return marioSprite;
        }
    }
}
