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
    class SmallMountain : IBackground
    {
        Rectangle spriteRef = new Rectangle(256, 181, 48, 19);
        int xPos;
        int yPos;
        Texture2D smallMountainTexture;

        public SmallMountain(Texture2D mountainstexture, int x, int y)
        {
            smallMountainTexture = mountainstexture;
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
            spriteBatch.Draw(smallMountainTexture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
        }
    }
}
