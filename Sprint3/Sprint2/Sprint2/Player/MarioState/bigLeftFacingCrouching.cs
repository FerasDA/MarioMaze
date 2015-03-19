using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Constants;

namespace Sprint2.Player.MarioState
{
    class bigLeftFacingCrouching : IMarioState
    {
        Rectangle refRectangle = new Rectangle(Rec.BLFCROUCHING_X, Rec.BIGCROUCHING_Y, Rec.BIGCROUCHING_W, Rec.BIGCROUCHING_H);
        public bigLeftFacingCrouching() {}
        public IMarioState Idle() {
            return new bigLeftFacingIdle();
        }

        public IMarioState Jump() {
            return new bigLeftFacingIdle();
        }

        public IMarioState Crouch() {
            return this;
        }

        public IMarioState Left() {
            return new bigLeftFacingIdle();
        }

        public IMarioState Right() {
            return new bigRightFacingCrouching();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return this;
        }

        public IMarioState Fire() {
            return new fireLeftFacingCrouching();
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
