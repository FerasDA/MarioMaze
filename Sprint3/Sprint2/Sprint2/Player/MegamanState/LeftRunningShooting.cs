using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class LeftRunningShooting : IMegamanState
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { 
            new Rectangle(99,97,29,22), 
            new Rectangle(69,95,26,24), 
            new Rectangle(36,97,30,22),
            new Rectangle(69,95,26,24)};
        int totalFrames = refRectangle.Length;
        int shootingCooldown;
        public LeftRunningShooting() 
        {
            shootingCooldown= 20;
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
            return this;
        }

        public IMegamanState Right()
        {
            return new LeftIdle();
        }

        public IMegamanState Attack(Attacks.MegamansBullet mmb)
        {
            shootingCooldown=20;
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
            currentFrame = (currentFrame + .1) % totalFrames;
            shootingCooldown--;
            if(shootingCooldown<1)
                return new LeftRunning();
            return this;
        }

        public Rectangle getReferenceRectangle()
        {
            return refRectangle[(int)currentFrame];
        }
    }
}
