using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MarioState
{
    class fireRightFacingFlagPole : IMarioState
    {
        Rectangle refRectangle = new Rectangle(405,130,14,27);
        public fireRightFacingFlagPole() { }
        public IMarioState Idle() {
            return new fireRightFacingIdle();
        }

        public IMarioState Jump() {
            return new fireRightFacingIdle();
        }

        public IMarioState Crouch() {
            return new fireRightFacingCrouching();
        }

        public IMarioState Left() {
            return new fireLeftFacingCrouching();
        }

        public IMarioState Right() {
            return new fireRightFacingIdle();
        }

        public void Attack(Attacks.MariosFireBall fb)
        {
        }

        public IMarioState Mushroom() {
            return this;
        }

        public IMarioState Fire() {
            return this;
        }

        public IMarioState damaged() {
            return new bigRightFacingFlagPole();
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
