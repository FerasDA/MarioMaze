using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Constants;

namespace Sprint2.Player.MarioState
{
    class bigRightFacingCrouching : IMarioState
    {
        Rectangle refRectangle = new Rectangle(Rec.BRFCROUCHING_X, Rec.BIGCROUCHING_Y, Rec.BIGCROUCHING_W, Rec.BIGCROUCHING_H);
        public bigRightFacingCrouching() {}
        public IMarioState Idle() {
            return new bigRightFacingIdle();
        }

        public IMarioState Jump() {
            return new bigRightFacingIdle();
        }

        public IMarioState Crouch() {
            return this;
        }

        public IMarioState Left() {
            return new bigLeftFacingCrouching();
        }

        public IMarioState Right() {
            return new bigRightFacingIdle();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return this;
        }

        public IMarioState Fire() {
            return new fireRightFacingCrouching();
        }

        public IMarioState damaged() {
            return new dead();
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
