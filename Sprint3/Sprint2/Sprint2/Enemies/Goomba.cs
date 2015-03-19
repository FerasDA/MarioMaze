using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Enemies;
using Sprint2.Enemies.GoombaState;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.Objects.DeadBodies.Enemy;
using Sprint2.Collision;
using Sprint2.Cameras;
using Sprint2.Player;



namespace Sprint2.Enemies
{
    class Goomba : IEnemy
    {
        Texture2D goomba;
        int xPos;
        int yPos;
        IGoomba state = new WalkingGoomba();
        bool facingRight = false;
        bool isFalling = false;
        int ticksTillRemoved = 30;
        public Goomba(Texture2D texture, int x, int y, IGoomba goombaState)
        {
            goomba = texture;
            xPos = x;
            yPos = y;
            state = goombaState;
        }
        public void update()
        {
            if (isFalling)
                yPos += 3;
            else
                yPos++;
           state.Update();
           if (!state.ToString().Equals(new DeadGoomba().ToString()))
           {
               if (facingRight)
                   xPos++;
               else
                   xPos--;
           }
           else
           {
               ticksTillRemoved--;
           }
           if (ticksTillRemoved < 0 || yPos > 500)
           {
               RemoveElementList re = new RemoveElementList();
               re.Add(this);
           }
           isFalling = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle refRectangle = state.getRefRectangle();
            Camera camera = new Camera();
            spriteBatch.Draw(goomba, new Rectangle(xPos - camera.GetCameraOffset(), yPos - refRectangle.Height, refRectangle.Width, refRectangle.Height), refRectangle, Color.White);
        }
        public Rectangle GetRectangle()
        {
            Rectangle refRectangle = state.getRefRectangle();
            return new Rectangle(xPos, yPos - refRectangle.Height, refRectangle.Width, refRectangle.Height);
        }

        public Rectangle GetWeakSpot()
        {
            Rectangle weakRec = state.GetWeakSpot();
            return new Rectangle(xPos + weakRec.X, yPos - weakRec.Y, weakRec.Width, weakRec.Height);
        }


        public void Damage()
        {
            state = state.Damage();
        }

        public void TurnAround()
        {
            facingRight = !facingRight;
        }

        public void ShiftUp()
        {
            yPos--;
            isFalling = false;
        }

        public override string ToString()
        {
            return state.ToString();
        }


        public void Killed(CollisionType.Collision c, IPlayer p)
        {
            p.AddScore(100);
            RemoveElementList re = new RemoveElementList();
            re.Add(this);
            AddElementList ad = new AddElementList();
            Rectangle refRectangle = state.getRefRectangle();
            ad.Add(new DeadBodyGoomba(xPos+ refRectangle.Width, yPos + refRectangle.Height, goomba, c));
        }
    }
}
