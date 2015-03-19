using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    class RightIdle : IMegamanState
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { 
            new Rectangle(236, 11, 21, 24), 
            new Rectangle(236, 11, 21, 24), 
            new Rectangle(236, 11, 21, 24), 
            new Rectangle(236, 11, 21, 24), 
            new Rectangle(236, 11, 21, 24), 
            new Rectangle(236, 11, 21, 24), 
            new Rectangle(236, 11, 21, 24), 
            new Rectangle(236, 11, 21, 24), 
            new Rectangle(236, 11, 21, 24), 
            new Rectangle(236, 11, 21, 24), 
            new Rectangle(236, 11, 21, 24),
            new Rectangle(261, 11, 21, 24) };
        int totalFrames = refRectangle.Length;
        public RightIdle() { }
        public IMegamanState Idle()
        {
            return this;
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
            mmb.Attack(true);
            return new RightIdleShooting();
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
