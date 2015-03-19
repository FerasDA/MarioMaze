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
    class Pole :IObject
    {
        Flag flag;
        Texture2D texture;
        Rectangle refRectangle = new Rectangle(Rec.POLE_X, Rec.POLE_Y, Rec.POLE_W, Rec.POLE_H);
        int xPos;
        int yPos;

        public Pole(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            xPos = x;
            yPos = y;
            flag = new Flag(texture, x - 12, y - 127);
        }

        public void Update()
        {
            flag.Update();
        }

        public void Collision()
        {
            flag.Collision();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Camera camera = new Camera();
            spriteBatch.Draw(texture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - refRectangle.Height, refRectangle.Width, refRectangle.Height), refRectangle, Color.White);
            flag.Draw(spriteBatch);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(xPos, yPos - refRectangle.Height, refRectangle.Width, refRectangle.Height);
        }

        public Rectangle GetWeakSpot()
        {
            throw new NotImplementedException();
        }
    }
}
