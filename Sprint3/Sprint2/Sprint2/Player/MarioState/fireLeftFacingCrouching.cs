using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Player.Attacks;

namespace Sprint2.Player.MarioState
{
    class fireLeftFacingCrouching : IMarioState
    {
        Rectangle refRectangle = new Rectangle(220, 135, 16, 22);
        public fireLeftFacingCrouching() {}
        public IMarioState Idle() {
            return new fireLeftFacingIdle();
        }

        public IMarioState Jump() {
            return new fireLeftFacingIdle();
        }

        public IMarioState Crouch() {
            return this;
        }

        public IMarioState Left() {
            return new fireLeftFacingIdle();
        }

        public IMarioState Right() {
            return new fireRightFacingCrouching();
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
            return new bigLeftFacingCrouching();
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
