using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Constants;

namespace Sprint2.Player.MarioState
{
    class bigRightFacingIdle : IMarioState
    {
        Rectangle refRectangle = new Rectangle(Rec.BRFIDLE_X, Rec.BIGIDLE_Y, Rec.BIGIDLE_W, Rec.BIGIDLE_H);
        public bigRightFacingIdle() {}
        public IMarioState Idle() {
            return this;
        }

        public IMarioState Jump() {
            return new bigRightFacingJumping();
        }

        public IMarioState Crouch() {
            return new bigRightFacingCrouching();
        }

        public IMarioState Left() {
            return new bigLeftFacingIdle();
        }

        public IMarioState Right() {
            return new bigRightFacingRunning();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return this;
        }

        public IMarioState Fire() {
            return new fireRightFacingIdle();
        }

        public IMarioState damaged() {
            return new smallRightFacingIdle();
        }
        public IMarioState Flagpole()
        {
            return new bigRightFacingFlagPole();
        }
        public void update() {}

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
