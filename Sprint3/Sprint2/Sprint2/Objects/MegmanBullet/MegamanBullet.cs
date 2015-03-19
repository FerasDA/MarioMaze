using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Objects.MegmanBullet
{
    class MegamanBullet : IObject
    {
        Rectangle refRectangle;
        int xPos;
        int yPos;
        Texture2D bulletTexture;
        bool facingRight;
        int collisionCountDown = 5;
        bool hasCollided = false;
        bool hasLeftScreen = false;
        IPlayer thrownByPlayer;
        public MegamanBullet(Texture2D texture, int x, int y, bool facingRight, IPlayer p)
        {
            if (facingRight)
                refRectangle = new Rectangle(276,1851,8,6);
            else
                refRectangle = new Rectangle(52,1851,8,6);
            bulletTexture = texture;
            xPos = x;
            yPos = y;
            this.facingRight = facingRight;
            thrownByPlayer = p;
        }

        public void Update()
        {
            if (hasCollided)
            {
                collisionCountDown--;
            }
            else
            {
                if (facingRight)
                    xPos+=4;
                else
                    xPos-=4;
            }
            Camera camera = new Camera();
            if (xPos < camera.GetCameraOffset() || xPos > camera.GetCameraOffset() + 800)
            {
                RemoveElementList re = new RemoveElementList();
                re.Add(this);
            }
            if((collisionCountDown < 0) || (yPos > 500))
            {
                RemoveElementList re = new RemoveElementList();
                re.Add(this);
            }
        }
        public void Collision()
        {
            hasCollided = true;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(xPos, yPos - refRectangle.Height, refRectangle.Width, refRectangle.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Camera camera = new Camera();
            spriteBatch.Draw(bulletTexture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - refRectangle.Height, refRectangle.Width, refRectangle.Height), refRectangle, Color.White);
        }

        public Rectangle GetWeakSpot()
        {
            throw new NotImplementedException();
        }
        internal void Exit()
        {
            RemoveElementList re = new RemoveElementList();
            re.Add(this);
        }

        internal bool IsMovingRight()
        {
            return facingRight;
        }

        public IPlayer ThrownByPlayer()
        {
            return thrownByPlayer;
        }
    }
}
