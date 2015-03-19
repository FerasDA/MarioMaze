using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sprint2.Objects
{
    public interface IObject
    {
        void Update();
        void Collision();
        void Draw(SpriteBatch spriteBatch);
        Rectangle GetRectangle();
        Rectangle GetWeakSpot();
    }
}
