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

namespace Sprint2.Objects.DeadBodies.Enemy
{
    class DeadBodyKoopa : IObject
    {
        double yPos;
        double xPos;
        double xVelos;
        Texture2D texture;
        Rectangle refRectangle = new Rectangle(Rec.DEADBODYKOOPA_X, Rec.DEADBODYKOOPA_Y, Rec.DEADBODYKOOPA_W, Rec.DEADBODYKOOPA_H);
        float rotation = (float)Math.PI;
        int deathBumpCounter = 16;

        public DeadBodyKoopa(int x, int y, Texture2D texture, CollisionType.Collision c)
        {
            yPos = y;
            xPos = x;
            this.texture = texture;
            if (c.Equals(CollisionType.Collision.left))
                xVelos = 0.5;
            else if (c.Equals(CollisionType.Collision.right))
                xVelos = -0.5;
        }

        public void Update()
        {
            xPos += xVelos;
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
            spriteBatch.Draw(texture, new Rectangle((int)xPos - camera.GetCameraOffset(), (int)yPos - refRectangle.Height, refRectangle.Width, refRectangle.Height), refRectangle, Color.White, rotation, new Vector2((float)0,(float)
                0), SpriteEffects.None, (float)0 );
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
