using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MarioState
{
    class smallRightFacingFlagPole : IMarioState
    {
        Rectangle refRectangle = new Rectangle(374,45,12,15);
        public smallRightFacingFlagPole() { }
        public IMarioState Idle()
        {
            return new smallRightFacingIdle();
        }

        public IMarioState Jump()
        {
            return new smallRightFacingJumping();
        }

        public IMarioState Crouch()
        {
            return new smallRightFacingIdle();
        }

        public IMarioState Left()
        {
            return new smallLeftFacingIdle();
        }

        public IMarioState Right()
        {
            return new smallRightFacingRunning();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom()
        {
            return new bigRightFacingFlagPole();
        }

        public IMarioState Fire()
        {
            return new fireRightFacingFlagPole();
        }

        public IMarioState damaged()
        {
            return new dead();
        }
        public IMarioState Flagpole()
        {
            return this;
        }
        public void update() { }

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
