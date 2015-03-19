using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.Player;
using Sprint2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Items
{
    class Coin : IItem
    {
        double currentFrame = 0;
        static Rectangle[] spriteRef = new Rectangle[] { 
            new Rectangle(Rec.COIN_X0, Rec.COIN_Y, Rec.COIN_W, Rec.COIN_H), 
            new Rectangle(Rec.COIN_X1, Rec.COIN_Y, Rec.COIN_W, Rec.COIN_H), 
            new Rectangle(Rec.COIN_X2, Rec.COIN_Y, Rec.COIN_W, Rec.COIN_H), 
            new Rectangle(Rec.COIN_X1, Rec.COIN_Y, Rec.COIN_W, Rec.COIN_H), 
            new Rectangle(Rec.COIN_X0, Rec.COIN_Y, Rec.COIN_W, Rec.COIN_H) };
        int totalFrames = spriteRef.Length;
        int xPos;
        int yPos;
        Texture2D coinTexture;

        public Coin(Texture2D texture, int x, int y)
        {
            coinTexture = texture;
            xPos = x;
            yPos = y;
        }
        public void Collision(IPlayer player)
        {
            Console.WriteLine("Player got a coin");
            player.GainedCoin();
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(xPos, yPos - spriteRef[(int)currentFrame].Height, spriteRef[(int)currentFrame].Width, spriteRef[(int)currentFrame].Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Camera camera = new Camera();
            spriteBatch.Draw(coinTexture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef[(int)currentFrame].Height, spriteRef[(int)currentFrame].Width, spriteRef[(int)currentFrame].Height), spriteRef[(int)currentFrame], Color.White);
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
