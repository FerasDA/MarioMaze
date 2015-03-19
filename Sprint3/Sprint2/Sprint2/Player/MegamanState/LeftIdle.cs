using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class LeftIdle : IMegamanState
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { 
            new Rectangle(78, 11, 21, 24), 
            new Rectangle(78, 11, 21, 24),
            new Rectangle(78, 11, 21, 24),
            new Rectangle(78, 11, 21, 24), 
            new Rectangle(78, 11, 21, 24), 
            new Rectangle(78, 11, 21, 24), 
            new Rectangle(78, 11, 21, 24), 
            new Rectangle(78, 11, 21, 24), 
            new Rectangle(78, 11, 21, 24),
            new Rectangle(78, 11, 21, 24),
            new Rectangle(78, 11, 21, 24),
            new Rectangle(53, 11, 21, 24) };
        int totalFrames = refRectangle.Length;
        public LeftIdle() { }
        public IMegamanState Idle()
        {
            return this;
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
            mmb.Attack(false);
            return new LeftIdleShooting();
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
