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
    class PoisonMushroom : IItem
    {
        Rectangle spriteRef = new Rectangle(Rec.POISONMUSHROOM_X, Rec.MUSHROOM_Y, Rec.MUSHROOM_W, Rec.MUSHROOM_H);
        int xPos;
        int yPos;
        Texture2D mushroomTexture;
        bool facingRight = true;
        bool isFalling = false;

        public PoisonMushroom(Texture2D texture, int x, int y)
        {
           mushroomTexture = texture;
            xPos = x;
            yPos = y;
        }
        public void Collision(IPlayer player)
        {
            player.Damaged();
            Console.WriteLine("Player got a Poison Mushroom");
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(xPos, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Camera camera = new Camera();
            spriteBatch.Draw(mushroomTexture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
        }

        public void Update()
        {
            if (isFalling)
                yPos += 3;
            else
                yPos++;
            if (facingRight)
                xPos++;
            else
                xPos--;

            isFalling = true;
        }


        public void TurnAround()
        {
            facingRight = !facingRight;
        }

        public void ShiftUp()
        {
            yPos--;
            isFalling = false;
        }
    }
}
