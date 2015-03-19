using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.FireBall
{
    class FireBall : IObject
    {
        double currentFrame = 0;
        Rectangle[] refRectangle;
        int totalFrames;
        int xPos;
        int yPos;
        Texture2D coinTexture;
        bool facingRight;
        int collisionCountDown = 5;
        bool hasCollided = false;
        int bounceCounter = 0;
        bool hasLeftScreen = false;
        IPlayer thrownByPlayer;
        public FireBall(Texture2D texture, int x, int y, bool facingRight, IPlayer p)
        {
            refRectangle = new Rectangle[] { 
                new Rectangle(Rec.FIREBALL_X0, Rec.FIREBALL_Y0, Rec.FIREBALL_W, Rec.FIREBALL_H), 
                new Rectangle(Rec.FIREBALL_X1, Rec.FIREBALL_Y0, Rec.FIREBALL_W, Rec.FIREBALL_H), 
                new Rectangle(Rec.FIREBALL_X0, Rec.FIREBALL_Y1, Rec.FIREBALL_W, Rec.FIREBALL_H), 
                new Rectangle(Rec.FIREBALL_X1, Rec.FIREBALL_Y1, Rec.FIREBALL_W, Rec.FIREBALL_H) };
            totalFrames =refRectangle.Length;
            coinTexture = texture;
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
                currentFrame = (currentFrame + .2) % totalFrames;
                if(bounceCounter>0)
                {
                    yPos--;
                    bounceCounter--;
                }
                else
                    yPos++;
                if (facingRight)
                    xPos+=2;
                else
                    xPos-=2;
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
            refRectangle = new Rectangle[] { new Rectangle(592, 148, 8, 8) };
            totalFrames = refRectangle.Length;
            currentFrame = 0;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(xPos, yPos - refRectangle[(int)currentFrame].Height, refRectangle[(int)currentFrame].Width, refRectangle[(int)currentFrame].Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Camera camera = new Camera();
            spriteBatch.Draw(coinTexture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - refRectangle[(int)currentFrame].Height, refRectangle[(int)currentFrame].Width, refRectangle[(int)currentFrame].Height), refRectangle[(int)currentFrame], Color.White);
        }

        public Rectangle GetWeakSpot()
        {
            throw new NotImplementedException();
        }

        internal void Bounce()
        {
            bounceCounter = 20;
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
