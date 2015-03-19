using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MarioState
{
    class fireLeftFacingFlagPole : IMarioState
    {
        Rectangle refRectangle = new Rectangle(94,130,14,27);
        public fireLeftFacingFlagPole() { }
        public IMarioState Idle() {
            return new fireLeftFacingIdle();
        }

        public IMarioState Jump() {
            return new fireLeftFacingIdle();
        }

        public IMarioState Crouch() {
            return new fireLeftFacingCrouching();
        }

        public IMarioState Left() {
            return new fireLeftFacingIdle();
        }

        public IMarioState Right() {
            return new fireRightFacingFlagPole();
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
            return new bigLeftFacingFlagPole();
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
