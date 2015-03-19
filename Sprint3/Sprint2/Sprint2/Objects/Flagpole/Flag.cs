using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Flagpole
{
    class Flag : IObject
    {
        Texture2D texture;
        Rectangle refRectangle = new Rectangle(Rec.FLAG_X, Rec.FLAG_Y, Rec.FLAG_W, Rec.FLAG_H);
        int xPos;
        int yPos;
        bool dropping = false;
        int flagLowerAmount = 122;

        public Flag(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            xPos = x;
            yPos = y;
        }

        public void Update()
        {
            if (dropping)
            {
                if (flagLowerAmount > 0)
                {
                    yPos++;
                    flagLowerAmount--;
                }
            }
        }

        public void Collision()
        {
            dropping = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Camera camera = new Camera();
            spriteBatch.Draw(texture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - refRectangle.Height, refRectangle.Width, refRectangle.Height), refRectangle, Color.White);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(0, 0, 0, 0);
        }

        public Rectangle GetWeakSpot()
        {
            throw new NotImplementedException();
        }
    }
}
