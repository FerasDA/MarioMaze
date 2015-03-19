using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Player.MarioState
{
    class bigRightFacingFlagPole : IMarioState
    {
        Rectangle refRectangle = new Rectangle(Rec.BRFFLAGPOLE_X, Rec.BIGFLAGPOLE_Y, Rec.BIGFLAGPOLE_W, Rec.BIGFLAGPOLE_H);
        public bigRightFacingFlagPole() { }
        public IMarioState Idle() {
            return new bigRightFacingIdle();
        }

        public IMarioState Jump() {
            return new bigRightFacingIdle();
        }

        public IMarioState Crouch() {
            return new bigRightFacingCrouching();
        }

        public IMarioState Left() {
            return new bigLeftFacingFlagPole();
        }

        public IMarioState Right() {
            return new bigRightFacingIdle();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return this;
        }

        public IMarioState Fire() {
            return new fireRightFacingFlagPole();
        }

        public IMarioState damaged() {
            return new dead();
        }
        public IMarioState Flagpole()
        {
            return this;
        }
        public void update() {}

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
