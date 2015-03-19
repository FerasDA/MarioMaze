using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Player.Attacks;

namespace Sprint2.Player.MarioState
{
    class fireLeftFacingIdle : IMarioState
    {
        Rectangle refRectangle = new Rectangle(239, 125, 16, 32);
        public fireLeftFacingIdle() {}
        public IMarioState Idle() {
            return this;
        }

        public IMarioState Jump() {
            return new fireLeftFacingJumping();
        }

        public IMarioState Crouch() {
            return new fireLeftFacingCrouching();
        }

        public IMarioState Left() {
            return new fireLeftFacingRunning();
        }

        public IMarioState Right() {
            return new fireRightFacingIdle();
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
            return new bigLeftFacingIdle();
        }
        public IMarioState Flagpole()
        {
            return new fireLeftFacingFlagPole();
        }

        public void update() {}

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
