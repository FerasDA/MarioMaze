using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class LeftRunning : IMegamanState
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { 
            new Rectangle(115,39,24,22), 
            new Rectangle(97,37,16,24), 
            new Rectangle(74,39,21,22),
            new Rectangle(97,37,16,24)};
        int totalFrames = refRectangle.Length;
        public LeftRunning() { }
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
            mmb.Attack(false);
            return new LeftRunningShooting();
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
            return this;
        }

        public Rectangle getReferenceRectangle()
        {
            return refRectangle[(int)currentFrame];
        }
    }
}
