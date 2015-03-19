using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Items
{
    class Star : IItem
    {
        double currentFrame = 0;
        static Rectangle[] spriteRef = new Rectangle[] { 
            new Rectangle(Rec.STAR_X0, Rec.STAR_Y, Rec.STAR_W, Rec.STAR_H), 
            new Rectangle(Rec.STAR_X1, Rec.STAR_Y, Rec.STAR_W, Rec.STAR_H), 
            new Rectangle(Rec.STAR_X2, Rec.STAR_Y, Rec.STAR_W, Rec.STAR_H), 
            new Rectangle(Rec.STAR_X3, Rec.STAR_Y, Rec.STAR_W, Rec.STAR_H) };
        int totalFrames = spriteRef.Length;
        int xPos;
        int yPos;
        Texture2D starTexture;
        bool facingRight= true;

        public Star(Texture2D texture, int x, int y)
        {
            starTexture = texture;
            xPos = x;
            yPos = y;
        }
        public void Collision(IPlayer player)
        {
            player.Star();
            Console.WriteLine("Player got a Star");
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(xPos, yPos - spriteRef[(int)currentFrame].Height, spriteRef[(int)currentFrame].Width, spriteRef[(int)currentFrame].Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Camera camera = new Camera();
            spriteBatch.Draw(starTexture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef[(int)currentFrame].Height, spriteRef[(int)currentFrame].Width, spriteRef[(int)currentFrame].Height), spriteRef[(int)currentFrame], Color.White);
        }

        public void Update()
        {
            currentFrame = (currentFrame + .25) % totalFrames;
            yPos++;
            if (facingRight)
                xPos++;
            else
                xPos--;
        }


        public void TurnAround()
        {
            facingRight = !facingRight;
        }

        public void ShiftUp()
        {
            yPos--;
        }
    }
}
