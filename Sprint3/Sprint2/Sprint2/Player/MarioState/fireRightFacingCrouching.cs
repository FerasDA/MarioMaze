using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Player.Attacks;

namespace Sprint2.Player.MarioState
{
    class fireRightFacingCrouching : IMarioState
    {
        Rectangle refRectangle = new Rectangle(277, 135, 16, 22);
        public fireRightFacingCrouching() {}
        public IMarioState Idle() {
            return new fireRightFacingIdle();
        }

        public IMarioState Jump() {
            return new fireRightFacingIdle();
        }

        public IMarioState Crouch() {
            return this;
        }

        public IMarioState Left() {
            return new fireLeftFacingCrouching();
        }

        public IMarioState Right() {
            return new fireRightFacingIdle();
        }

        public void Attack(Attacks.MariosFireBall fb)
        {
            fb.Attack(true);
        }

        public IMarioState Mushroom() {
            return this;
        }

        public IMarioState Fire() {
            return this;
        }

        public IMarioState damaged() {
            return new bigRightFacingCrouching();
        }
        public IMarioState Flagpole()
        {
            return new fireRightFacingFlagPole();
        }
        public void update() {}

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
