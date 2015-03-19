using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2.Player.MarioState
{
    class smallRightFacingIdle : IMarioState
    {
        Rectangle refRectangle = new Rectangle(277, 44, 12, 16);
        public smallRightFacingIdle() {}
        public IMarioState Idle() {
            return this;
        }

        public IMarioState Jump() {
            return new smallRightFacingJumping();
        }

        public IMarioState Crouch() {
            return this;
        }

        public IMarioState Left() {
            return new smallLeftFacingIdle();
        }

        public IMarioState Right() {
            return new smallRightFacingRunning();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return new bigRightFacingIdle();
        }

        public IMarioState Fire() {
            return new fireRightFacingIdle();
        }

        public IMarioState damaged() {
            return new dead();
        }
        public IMarioState Flagpole()
        {
            return new smallRightFacingFlagPole();
        }
        public void update() {}

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
