using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class LeftJumping : IMegamanState
    {
        Rectangle refRectangle = new Rectangle(136, 63, 26, 30);
        public LeftJumping() { }
        public IMegamanState Idle()
        {
            return new LeftIdle();
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
            return new RightJumping();
        }

        public IMegamanState Attack(Attacks.MegamansBullet mmb)
        {
            mmb.Attack(false);
            return new LeftJumpingShooting();
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
