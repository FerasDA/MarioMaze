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
    class FireFlower : IItem 
    {
        double currentFrame = 0;
        static Rectangle[] spriteRef = new Rectangle[] { 
            new Rectangle(Rec.FIREFLOWER_X0, Rec.FIREFLOWER_Y, Rec.FIREFLOWER_W, Rec.FIREFLOWER_H), 
            new Rectangle(Rec.FIREFLOWER_X1, Rec.FIREFLOWER_Y, Rec.FIREFLOWER_W, Rec.FIREFLOWER_H), 
            new Rectangle(Rec.FIREFLOWER_X2, Rec.FIREFLOWER_Y, Rec.FIREFLOWER_W, Rec.FIREFLOWER_H), 
            new Rectangle(Rec.FIREFLOWER_X3 , Rec.FIREFLOWER_Y, Rec.FIREFLOWER_W, Rec.FIREFLOWER_H) };
        int totalFrames = spriteRef.Length;
        int xPos;
        int yPos;
        Texture2D fireFlowerTexture;

        public FireFlower(Texture2D texture, int x, int y)
        {
            fireFlowerTexture = texture;
            xPos = x;
            yPos = y;
        }
        public void Collision(IPlayer player)
        {
            player.Fire();
            Console.WriteLine("Player got a fire flower");
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(xPos, yPos - spriteRef[(int)currentFrame].Height, spriteRef[(int)currentFrame].Width, spriteRef[(int)currentFrame].Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Camera camera = new Camera();
            spriteBatch.Draw(fireFlowerTexture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef[(int)currentFrame].Height, spriteRef[(int)currentFrame].Width, spriteRef[(int)currentFrame].Height), spriteRef[(int)currentFrame], Color.White);
        }

        public void Update()
        {
            currentFrame = (currentFrame + .15) % totalFrames;
        }


        public void TurnAround()
        {
        }

        public void ShiftUp()
        {
            yPos--;
        }
    }
}
