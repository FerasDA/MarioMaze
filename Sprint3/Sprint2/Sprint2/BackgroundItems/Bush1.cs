using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;


namespace Sprint2.BackgroundItems
{
    class Bush1 : IBackground
    {
        Rectangle spriteRef = new Rectangle(Rec.BUSH1_X, Rec.BUSH1_Y, Rec.BUSH1_W, Rec.BUSH1_H);
        int xPos;
        int yPos;
        Texture2D bush1Texture;

        public Bush1(Texture2D bush1texture, int x, int y)
        {
            bush1Texture = bush1texture;
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
            spriteBatch.Draw(bush1Texture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
          //  spriteBatch.Draw(bushesTexture, new Rectangle(xPos + 300, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
        }
    }
}
