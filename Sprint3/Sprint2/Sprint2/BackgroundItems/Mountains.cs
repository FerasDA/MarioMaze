using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.BackgroundItems
{
    class Mountains : IBackground
    {
        Rectangle spriteRef = new Rectangle(0, 165, 80, 35);
        int xPos;
        int yPos;
        Texture2D mountainsTexture;

        public Mountains(Texture2D mountainstexture, int x, int y)
        {
            mountainsTexture = mountainstexture;
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
            spriteBatch.Draw(mountainsTexture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
        }
    }
}
