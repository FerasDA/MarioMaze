using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.SpecialMarioState
{
    class notSpecialState : ISpecialState
    {
        public notSpecialState(){}
        public ISpecialState update()
        {
            return this;
        }
        public ISpecialState Star() 
        {
            return new StarState();
        }
        public ISpecialState damaged()
        {
            return new DamagedState();
        }

        public ISpecialState notSpecial()
        {
            return this;
        }
        public Color GetColor() 
        {
            return Color.White;
        }

        public bool damageable() 
        {
            return true;
        }
    }
}
