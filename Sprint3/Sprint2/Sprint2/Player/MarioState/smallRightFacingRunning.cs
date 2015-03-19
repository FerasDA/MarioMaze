using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2.Player.MarioState
{
    class smallRightFacingRunning : IMarioState
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { new Rectangle(292, 45, 12, 15), new Rectangle(307, 44, 11, 16), new Rectangle(321, 44, 15, 16) };
        int totalFrames = refRectangle.Length;
        public smallRightFacingRunning() {}
        public IMarioState Idle() {
            return new smallRightFacingIdle();
        }

        public IMarioState Jump() {
            return new smallRightFacingJumping();
        }

        public IMarioState Crouch() {
            return new smallRightFacingIdle();
        }

        public IMarioState Left() {
            return new smallRightFacingIdle();
        }

        public IMarioState Right() {
            return this;
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return new bigRightFacingRunning();
        }

        public IMarioState Fire() {
            return new fireRightFacingRunning();
        }

        public IMarioState damaged() {
            return new dead();
        }
        public IMarioState Flagpole()
        {
            return new smallRightFacingFlagPole();
        }
        public void update() {
            currentFrame = (currentFrame + .1) % totalFrames;
        }

        public Rectangle getReferenceRectangle()
        {
            return refRectangle[(int)currentFrame];
        }
    }
}
