using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class LeftIdleShooting : IMegamanState
    {
        Rectangle refRectangle = new Rectangle(131, 95, 31, 24);
        int shootingCooldown;
        public LeftIdleShooting() 
        {
            shootingCooldown = 20;
        }
        public IMegamanState Idle()
        {
            return new LeftIdle();
        }

        public IMegamanState Jump()
        {
            return new LeftJumping();
        }

        public IMegamanState Left()
        {
            return new LeftRunning();
        }

        public IMegamanState Right()
        {
            return new RightIdle();
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
            if(shootingCooldown < 1)
                return new LeftIdle();
            return this;
        }

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
