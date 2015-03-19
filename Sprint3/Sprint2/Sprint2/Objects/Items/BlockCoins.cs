using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.Player;
using Sprint2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Items
{
    class BlockCoins : IItem
    {
        double currentFrame = 0;
        static Rectangle[] spriteRef = new Rectangle[] { 
            new Rectangle(Rec.BLOCKCOIN_X0, Rec.BLOCKCOIN_Y, Rec.BLOCKCOIN_W, Rec.BLOCK_H), 
            new Rectangle(Rec.BLOCKCOIN_X1, Rec.BLOCKCOIN_Y, Rec.BLOCKCOIN_W, Rec.BLOCK_H), 
            new Rectangle(Rec.BLOCKCOIN_X2, Rec.BLOCKCOIN_Y, Rec.BLOCKCOIN_W, Rec.BLOCK_H), 
            new Rectangle(Rec.BLOCKCOIN_X3, Rec.BLOCKCOIN_Y, Rec.BLOCKCOIN_W, Rec.BLOCK_H) };
        int totalFrames = spriteRef.Length;
        int xPos;
        int yPos;
        Texture2D coinTexture;
        SoundController sc;
        int toRemoveCounter;

        public BlockCoins(Texture2D texture, int x, int y)
        {
            coinTexture = texture;
            xPos = x;
            yPos = y;
            sc = new SoundController();
            toRemoveCounter = 30;
        }
        public void Collision(IPlayer player)
        {
            Console.WriteLine("Player got a coin");
            player.GainedCoin();
            sc.Coin();
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
            currentFrame = (currentFrame + .3) % totalFrames;
            {
                if (toRemoveCounter > 15)
                    yPos -= 2;
                else
                    yPos += 2;
            }
            toRemoveCounter--;
            if(toRemoveCounter<0)
            {
                RemoveElementList re = new RemoveElementList();
                re.Add(this);
            }
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
