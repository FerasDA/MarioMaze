using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Player.MarioState
{
    class bigLeftFacingFlagPole : IMarioState
    {
        Rectangle refRectangle = new Rectangle(Rec.BLFFLAGPOLE_X, Rec.BIGFLAGPOLE_Y, Rec.BIGFLAGPOLE_W, Rec.BIGFLAGPOLE_H);
        public bigLeftFacingFlagPole() { }
        public IMarioState Idle() {
            return new bigLeftFacingIdle();
        }

        public IMarioState Jump() {
            return new bigLeftFacingIdle();
        }

        public IMarioState Crouch() {
            return new bigLeftFacingCrouching();
        }

        public IMarioState Left() {
            return new bigLeftFacingIdle();
        }

        public IMarioState Right() {
            return new bigRightFacingFlagPole();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return this;
        }

        public IMarioState Fire() {
            return new fireLeftFacingFlagPole();
        }

        public IMarioState damaged() {
            return new smallLeftFacingFlagPole();
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
