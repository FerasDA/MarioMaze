using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.SpecialMarioState
{
    interface ISpecialState
    {
        ISpecialState update();
        ISpecialState Star();
        ISpecialState damaged();
        ISpecialState notSpecial();
        Color GetColor();
        bool damageable();
    }
}
