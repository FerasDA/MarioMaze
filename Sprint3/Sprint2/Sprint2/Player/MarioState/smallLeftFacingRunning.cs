using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2.Player.MarioState
{
    class smallLeftFacingRunning : IMarioState
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { new Rectangle(209, 45, 12, 15), new Rectangle(195, 44, 11, 16), new Rectangle(177, 44, 15, 16) };
        int totalFrames = refRectangle.Length;
        public smallLeftFacingRunning() {}
        public IMarioState Idle() {
            return new smallLeftFacingIdle();
        }

        public IMarioState Jump() {
            return new smallLeftFacingJumping();
        }

        public IMarioState Crouch() {
            return new smallLeftFacingIdle();
        }

        public IMarioState Left() {
            return this;
        }

        public IMarioState Right() {
            return new smallLeftFacingIdle();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return new bigLeftFacingRunning();
        }

        public IMarioState Fire() {
            return new fireLeftFacingRunning();
        }

        public IMarioState damaged() {
            return new dead();
        }
        public IMarioState Flagpole()
        {
            return new smallLeftFacingFlagPole();
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
