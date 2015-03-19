using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class RightIdleShooting : IMegamanState
    {
        Rectangle refRectangle = new Rectangle(172,95,31,24);
        int shootingCooldown;
        public RightIdleShooting() 
        {
            shootingCooldown= 20;
        }
        public IMegamanState Idle()
        {
            return new RightIdle();
        }

        public IMegamanState Jump()
        {
            return new RightJumping();
        }

        public IMegamanState Left()
        {
            return new LeftIdle();
        }

        public IMegamanState Right()
        {
            return new RightRunning();
        }

        public IMegamanState Attack(Attacks.MegamansBullet mmb)
        {
            shootingCooldown= 20;
            mmb.Attack(true);
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
            if(shootingCooldown < 1)
                return new RightIdle();
            return this;
        }

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
