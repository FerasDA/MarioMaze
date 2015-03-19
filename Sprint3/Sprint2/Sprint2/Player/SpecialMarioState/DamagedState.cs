using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Sprint2.Player.SpecialMarioState
{
    class DamagedState : ISpecialState
    {
        int colorCounter;
        int damageStateCooldown;

        public DamagedState()
        {
            damageStateCooldown = 60;
        }

        public ISpecialState update()
        {
            colorCounter++;
            colorCounter %= 10;
            damageStateCooldown--;
            if (damageStateCooldown < 0)
                return new notSpecialState();
            return this;
        }
        public ISpecialState Star()
        {
            return new StarState();
        }
        public ISpecialState damaged()
        {
            return this;
        }

        public ISpecialState notSpecial()
        {
            return new notSpecialState();
        }
        public Color GetColor()
        {
            if(colorCounter<5)
                return Color.White;
            return Color.Gray;
        }

        public bool damageable()
        {
            return false;
        }
    }
}
