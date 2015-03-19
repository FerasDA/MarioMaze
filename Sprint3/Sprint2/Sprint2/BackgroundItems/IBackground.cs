using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.BackgroundItems
{
    interface IBackground
    {
        Rectangle GetRectangle();
        void Draw(SpriteBatch spriteBatch);
    }
}
