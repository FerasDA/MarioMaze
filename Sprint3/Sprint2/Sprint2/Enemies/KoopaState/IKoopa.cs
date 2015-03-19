using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Enemies.KoopaState
{
    interface IKoopa
    {
        void Update();

        IKoopa Damage();

        Rectangle getRefRectangle();

        Rectangle GetWeakSpot();

        IKoopa TurnAround();
    }
}
