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
    class Bush3 : IBackground
    {
        Rectangle spriteRef = new Rectangle(Rec.BUSH3_X, Rec.BUSH3_Y, Rec.BUSH3_W, Rec.BUSH3_H);
        int xPos;
        int yPos;
        Texture2D bushesTexture;

        public Bush3(Texture2D bushestexture, int x, int y)
        {
            bushesTexture = bushestexture;
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
            spriteBatch.Draw(bushesTexture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
          //  spriteBatch.Draw(bushesTexture, new Rectangle(xPos + 300, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
        }
    }
}
