using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.BackgroundItems
{
    class Black : IBackground
    {

        Rectangle spriteRef = new Rectangle(Rec.BLACK_X, Rec.BLACK_Y, Rec.BLACK_W, Rec.BLACK_H);
        int xPos;
        int yPos;
        Texture2D Texture;

        public Black(Texture2D texture, int x, int y)
        {
            Texture = texture;
            xPos = x;
            yPos = y;
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(xPos, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Camera camera = new Camera();
            spriteBatch.Draw(Texture, new Rectangle(xPos - camera.GetCameraOffset(), yPos, 1500, 500), spriteRef, Color.Black);
          //  spriteBatch.Draw(bushesTexture, new Rectangle(xPos + 300, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
        }
    }
}
