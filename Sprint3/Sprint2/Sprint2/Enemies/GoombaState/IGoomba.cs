using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Enemies.GoombaState
{
    interface IGoomba
    {
        void Update();

        IGoomba Damage();

        Rectangle getRefRectangle();

        Rectangle GetWeakSpot();
    }
}
