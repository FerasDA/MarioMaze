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
    class Cloud1 : IBackground
    {
        Rectangle spriteRef = new Rectangle(Rec.CLOUD1_X, Rec.CLOUD1_Y, Rec.CLOUD1_W, Rec.CLOUD1_H);
        int xPos;
        int yPos;
        Texture2D cloudTexture;

        public Cloud1(Texture2D cloudtexture, int x, int y)
        {
            cloudTexture = cloudtexture;
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
            spriteBatch.Draw(cloudTexture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
            //spriteBatch.Draw(cloudTexture, new Rectangle(xPos + 100, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
            //spriteBatch.Draw(cloudTexture, new Rectangle(xPos + 200, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
            //spriteBatch.Draw(cloudTexture, new Rectangle(xPos + 300, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
            //spriteBatch.Draw(cloudTexture, new Rectangle(xPos + 400, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
        }
    }
}
