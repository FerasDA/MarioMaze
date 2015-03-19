using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.Collision;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.Enemies.KoopaState;
using Sprint2.Objects.DeadBodies.Enemy;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Enemies
{
    class KoopaShell : IEnemy
    {
        Texture2D koopaSprite;
        int xPos;
        int yPos;
        IKoopa state = new ShellKoopa();
        bool isMoving = false;
        bool facingRight = false;
        IPlayer kickedBy;
        public KoopaShell(Texture2D texture, int x, int y, IKoopa koopaState)
        {
            koopaSprite = texture;
            xPos = x;
            yPos = y;
            state = koopaState;
        }
        public void update()
        {
           yPos++;
           state.Update();
           if(isMoving)
            {
                if (facingRight)
                    xPos+=2;
                else
                    xPos-=2;
            }

           if (yPos > 500)
           {
               RemoveElementList re = new RemoveElementList();
               re.Add(this);
           }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle refRectangle = state.getRefRectangle();
            Camera camera = new Camera();
            spriteBatch.Draw(koopaSprite, new Rectangle(xPos - camera.GetCameraOffset(), yPos - refRectangle.Height, refRectangle.Width, refRectangle.Height), refRectangle, Color.White);
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
        }
        public override string ToString()
        {
            return state.ToString();
        }

        public bool IsMoving()
        {
            return isMoving;
        }

        internal void Kick(Collision.CollisionType.Collision collision, IPlayer p)
        {
            isMoving = true;
            kickedBy = p;
            if (collision.Equals(Collision.CollisionType.Collision.left))
                facingRight = true;
            if (collision.Equals(Collision.CollisionType.Collision.right))
                facingRight = false;
        }

        public void Killed(CollisionType.Collision c, IPlayer p)
        {
            p.AddScore(200);
            RemoveElementList re = new RemoveElementList();
            re.Add(this);
            AddElementList ad = new AddElementList();
            Rectangle refRectangle = state.getRefRectangle();
            ad.Add(new DeadBodyKoopa(xPos + refRectangle.Width, yPos + refRectangle.Height, koopaSprite, c));
        }
        internal void Stomp()
        {
            isMoving = false;
        }

        internal bool IsMovingRight()
        {
            return facingRight;
        }

        public IPlayer KickedBy()
        {
            return kickedBy;
        }
    }
}
