using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Constants;

namespace Sprint2.Player.MarioState
{
    class bigLeftFacingIdle : IMarioState
    {
        Rectangle refRectangle = new Rectangle(Rec.BLFIDLE_X, Rec.BIGIDLE_Y, Rec.BIGIDLE_W, Rec.BIGIDLE_H);
        public bigLeftFacingIdle() {}
        public IMarioState Idle() {
            return this;
        }

        public IMarioState Jump() {
            return new bigLeftFacingJumping();
        }

        public IMarioState Crouch() {
            return new bigLeftFacingCrouching();
        }

        public IMarioState Left() {
            return new bigLeftFacingRunning();
        }

        public IMarioState Right() {
            return new bigRightFacingIdle();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return this;
        }

        public IMarioState Fire() {
            return new fireLeftFacingIdle();
        }

        public IMarioState damaged() {
            return new smallLeftFacingIdle();
        }
        public IMarioState Flagpole()
        {
            return new bigLeftFacingFlagPole();
        }

        public void update() {}

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
