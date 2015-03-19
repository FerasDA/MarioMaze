using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Objects.Items
{
    interface IItem
    {
        void Collision(IPlayer player);
        Rectangle GetRectangle();
        void Draw(SpriteBatch spriteBatch);
        void Update();

        void TurnAround();

        void ShiftUp();
    }
}
