using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Player.Attacks;

namespace Sprint2.Player.MarioState
{
    class fireLeftFacingRunning : IMarioState
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { new Rectangle(201, 127, 16, 30), new Rectangle(184, 126, 14, 31), new Rectangle(166, 125, 16, 32) };
        int totalFrames = refRectangle.Length;
        public fireLeftFacingRunning() { }
        public IMarioState Idle() {
            return new fireLeftFacingIdle();
        }

        public IMarioState Jump() {
            return new fireLeftFacingJumping();
        }

        public IMarioState Crouch() {
            return new fireLeftFacingCrouching();
        }

        public IMarioState Left() {
            return this;
        }

        public IMarioState Right() {
            return new fireLeftFacingIdle();
        }

        public void Attack(Attacks.MariosFireBall fb)
        {
            fb.Attack(false);
        }

        public IMarioState Mushroom() {
            return this;
        }

        public IMarioState Fire() {
            return this;
        }

        public IMarioState damaged() {
            return new bigLeftFacingRunning();
        }
        public IMarioState Flagpole()
        {
            return new fireLeftFacingFlagPole();
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
