using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint2.Collision;
using Sprint2.Player;

namespace Sprint2
{
    interface IEnemy
    {
        void update();
        void Draw(SpriteBatch spritebatch);
        Rectangle GetRectangle();
        Rectangle GetWeakSpot();
        void Damage();
        void TurnAround();
        void ShiftUp();
        void Killed(CollisionType.Collision c, IPlayer p);
    }
}
