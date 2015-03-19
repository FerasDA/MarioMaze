using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class RightRunning : IMegamanState
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { 
            new Rectangle(195,39,24,22), 
            new Rectangle(221,37,16,24), 
            new Rectangle(239,39,21,22),
            new Rectangle(221,37,16,24)};
        int totalFrames = refRectangle.Length;
        public RightRunning() { }
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
            mmb.Attack(true);
            return new RightRunningShooting();
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
