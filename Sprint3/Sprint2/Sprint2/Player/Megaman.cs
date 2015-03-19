using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.GameState;
using Sprint2.Objects.DeadBodies.Player;
using Sprint2.Player.Attacks;
using Sprint2.Player.MegamanState;
using Sprint2.Player.PlayerPhysics;
using Sprint2.Player.SpecialMarioState;
using Sprint2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player
{
    class Megaman : IPlayer
    {
        PlayerStats playerStats;
        Texture2D megmanSprite;
        public IMegamanState state = new RightIdle();
        int xPos;
        int yPos;
        ISpecialState specialState = new notSpecialState();
        MegamansBullet mmb;
        MegamanPhysics physics;
        bool alive = true;
        bool flagpole;
        bool facingRight;

        bool isAttacking= false;
        bool hasAttacked = false;

        bool isPressingDown = false;
        bool wasPressingDown = false;

        SoundController sc = new SoundController();

        public Megaman(Texture2D texture, int x, int y, IMegamanState megamanState) 
        {
            megmanSprite = texture;
            xPos = x;
            yPos = y;
            state = megamanState;
            facingRight = true;
            flagpole = false;
            mmb = new MegamansBullet(this);
            physics = new MegamanPhysics(this, x, y);
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
        }

        public void Crouch()
        {
            physics.PressingDown();

            isPressingDown = true;
        }

        public void Left()
        {
            state = state.Left();
            physics.PressingLeft();
            facingRight = false;
        }

        public void Right()
        {
            state = state.Right();
            physics.PressingRight();
            facingRight = true;
        }

        public void Attack() 
        {
            if (!hasAttacked)
            {
                state = state.Attack(mmb);
                physics.PressedAttack();
            }
            //physics.PressedAttack();
            isAttacking = true;
        }

        public void Mushroom(){}

        public void Fire(){}

        public void Damaged() 
        {
            if (specialState.damageable() && !state.ToString().Equals(new Dead().ToString()))
            {
                IMegamanState oldState = state;
                state = state.Death();
                //if (oldState != state && !state.ToString().Equals("dead"))
                //    new PlayerStateTransitions(this, oldState, state);
                //specialState = specialState.damaged();
            }
        }

        public void Death()
        {
            state = new Dead();
            //specialState = new notSpecialState();
        }

        public void Update()
        {
            state = state.Update();
            specialState = specialState.update();
            mmb.Update();

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
                if (facingRight)
                    ad.Add(new DeadRightFacingMegaman(xPos, yPos + refRectangle.Height, megmanSprite));
                else
                    ad.Add(new DeadLeftFacingMegaMan(xPos, yPos + refRectangle.Height, megmanSprite));
            }

            hasAttacked = isAttacking;
            isAttacking = false;

            wasPressingDown = isPressingDown;
            isPressingDown = false;
        }

        public void Star() 
        {
            if (!state.ToString().Equals(new Dead().ToString()))
            specialState = new StarState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle spriteRef = state.getReferenceRectangle();
            Color color = specialState.GetColor();
            Camera camera = new Camera();
            spriteBatch.Draw(megmanSprite, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, color);
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
            physics = new MegamanPhysics(this, x, y);
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
            state = new RightIdle();
            specialState = new notSpecialState();
            alive = true;
            flagpole = false;
            facingRight = true;
        }

        public bool IsDead()
        {
            return !alive;
        }


        public Texture2D GetTexture()
        {
            return megmanSprite;
        }
    }
}
