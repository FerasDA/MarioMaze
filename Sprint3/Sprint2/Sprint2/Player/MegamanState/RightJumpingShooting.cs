using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class RightJumpingShooting : IMegamanState
    {
        Rectangle refRectangle = new Rectangle(230,63,29,30);
        int shootingCooldown;
        public RightJumpingShooting() 
        {
            shootingCooldown =20;
        }
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
                return new RightJumping();
            return this;
        }

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
