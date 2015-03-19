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
    class Cloud2 : IBackground
    {
        Rectangle spriteRef = new Rectangle(Rec.CLOUD2_X, Rec.CLOUD2_Y, Rec.CLOUD2_W, Rec.CLOUD2_H);
        int xPos;
        int yPos;
        Texture2D cloudTexture;

        public Cloud2(Texture2D cloudtexture, int x, int y)
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
