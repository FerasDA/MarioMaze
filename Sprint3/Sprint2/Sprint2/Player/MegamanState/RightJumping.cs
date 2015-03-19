using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class RightJumping : IMegamanState
    {
        Rectangle refRectangle = new Rectangle(172,63,26,30);
        public RightJumping() { }
        public IMegamanState Idle()
        {
            return new RightIdle();
        }

        public IMegamanState Jump()
        {
            return this;
        }

        public IMegamanState Left()
        {
            return new LeftJumping();
        }

        public IMegamanState Right()
        {
            return this;
        }

        public IMegamanState Attack(Attacks.MegamansBullet mmb)
        {
            mmb.Attack(true);
            return new RightJumpingShooting();
        }

        public IMegamanState Flagpole()
        {
            return this;
        }
        public IMegamanState Death()
        {
            return new Dead();
        }

        public IMegamanState Update()
        {
            return this;
        }

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
