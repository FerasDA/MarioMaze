using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class LeftJumpingShooting : IMegamanState
    {
        Rectangle refRectangle = new Rectangle(76, 63, 29, 30);
        int shootingCooldown;
        public LeftJumpingShooting() 
        {
            shootingCooldown = 20;
        }
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
            shootingCooldown = 20;
            mmb.Attack(false);
            return this;
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
            shootingCooldown--;
            if(shootingCooldown <1)
                return new LeftJumping();
            return this;
        }

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
