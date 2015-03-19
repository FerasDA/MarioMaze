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
    class Bush2 : IBackground
    {
        Rectangle spriteRef = new Rectangle(Rec.BUSH2_X, Rec.BUSH2_Y, Rec.BUSH2_W, Rec.BUSH2_H);
        int xPos;
        int yPos;
        Texture2D bush2Texture;

        public Bush2(Texture2D bush2texture, int x, int y)
        {
            bush2Texture = bush2texture;
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
            spriteBatch.Draw(bush2Texture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
          //  spriteBatch.Draw(bushesTexture, new Rectangle(xPos + 300, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
        }
    }
}
