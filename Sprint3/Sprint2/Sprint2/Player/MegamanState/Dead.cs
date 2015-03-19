using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class Dead : IMegamanState
    {
        public Dead() { }
        public IMegamanState Idle()
        {
            return this;
        }

        public IMegamanState Jump()
        {
            return this;
        }

        public IMegamanState Left()
        {
            return this;
        }

        public IMegamanState Right()
        {
            return this;
        }

        public IMegamanState Attack(Attacks.MegamansBullet mmb)
        {
            return this;
        }

        public IMegamanState Death()
        {
            return this;
        }

        public IMegamanState Flagpole()
        {
            return this;
        }

        public IMegamanState Update() 
        {
            return this;
        }

        public Rectangle getReferenceRectangle()
        {
            return new Rectangle(0,0,0,0);
        }

        public override string ToString()
        {
            return "dead";
        }
    }
}
