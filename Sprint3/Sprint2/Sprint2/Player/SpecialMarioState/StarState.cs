using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Sprint2.Player.SpecialMarioState
{
    class StarState : ISpecialState
    {
        int starStateCountDown;

        public StarState()
        {
            starStateCountDown = 60 * 5;
        }

        public ISpecialState update()
        {
            starStateCountDown--;
            if (starStateCountDown < 0)
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
            Random rand = new Random();
            return new Color((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
        }

        public bool damageable()
        {
            return false;
        }

        public override string ToString()
        {
            return "Star";
        }
    }
}
