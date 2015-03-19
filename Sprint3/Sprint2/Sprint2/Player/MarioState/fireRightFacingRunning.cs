using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Player.Attacks;

namespace Sprint2.Player.MarioState
{
    class fireRightFacingRunning : IMarioState
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { new Rectangle(296, 127, 16, 30), new Rectangle(315, 126, 14, 31), new Rectangle(331, 125, 16, 32) };
        int totalFrames = refRectangle.Length;
        public fireRightFacingRunning() { }
        public IMarioState Idle() {
            return new fireRightFacingIdle();
        }

        public IMarioState Jump() {
            return new fireRightFacingJumping();
        }

        public IMarioState Crouch() {
            return new fireRightFacingCrouching();
        }

        public IMarioState Left() {
            return new fireRightFacingIdle();
        }

        public IMarioState Right() {
            return this;
        }

        public void Attack(Attacks.MariosFireBall fb)
        {
            fb.Attack(true);
        }

        public IMarioState Mushroom() {
            return this;
        }

        public IMarioState Fire() {
            return this;
        }

        public IMarioState damaged() {
            return new bigRightFacingRunning();
        }
        public IMarioState Flagpole()
        {
            return new fireRightFacingFlagPole();
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
