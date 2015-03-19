using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class RightRunningShooting : IMegamanState
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { 
            new Rectangle(206,97,29,22), 
            new Rectangle(239,95,26,24), 
            new Rectangle(268,97,30,22),
            new Rectangle(239,95,26,24)};
        int totalFrames = refRectangle.Length;
        int shootingCooldown;
        public RightRunningShooting() 
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
            return new RightIdle();
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
            currentFrame = (currentFrame + .1) % totalFrames;
            shootingCooldown--;
            if(shootingCooldown < 1)
                return new RightRunning();
            return this;
        }

        public Rectangle getReferenceRectangle()
        {
            return refRectangle[(int)currentFrame];
        }
    }
}
