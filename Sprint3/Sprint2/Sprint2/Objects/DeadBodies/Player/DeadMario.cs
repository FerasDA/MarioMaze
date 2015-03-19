using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.Collision;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.DeadBodies.Player
{
    class DeadMario : IObject
    {
        double yPos;
        double xPos;
        Texture2D texture;
        Rectangle refRectangle = new Rectangle(Rec.DEADMARIO_X, Rec.DEADMARIO_Y, Rec.DEADMARIO_W, Rec.DEADMARIO_H);
        int deathBumpCounter = 16;

        public DeadMario(int x, int y, Texture2D texture)
        {
            yPos = y;
            xPos = x;
            this.texture = texture;
        }

        public void Update()
        {
            if (deathBumpCounter > 0)
                yPos-=1.5;
            else if (yPos > 500)
            {
                RemoveElementList re = new RemoveElementList();
                re.Add(this);
            }
            else
                yPos+=2;

            deathBumpCounter--;
        }

        public void Collision()
        {
            //throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Camera camera = new Camera();
            spriteBatch.Draw(texture, new Rectangle((int)xPos - camera.GetCameraOffset(), (int)yPos - refRectangle.Height, refRectangle.Width, refRectangle.Height), refRectangle, Color.White);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(0, 0, 0, 0);
        }

        public Rectangle GetWeakSpot()
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }
}
