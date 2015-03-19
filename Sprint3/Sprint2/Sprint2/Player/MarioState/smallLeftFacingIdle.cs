using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2.Player.MarioState
{
    class smallLeftFacingIdle : IMarioState
    {
        Rectangle refRectangle = new Rectangle(224, 44, 12, 16);
        public smallLeftFacingIdle() {}
        public IMarioState Idle() {
            return this;
        }

        public IMarioState Jump() {
            return new smallLeftFacingJumping();
        }

        public IMarioState Crouch() {
            return this;
        }

        public IMarioState Left() {
            return new smallLeftFacingRunning();
        }

        public IMarioState Right() {
            return new smallRightFacingIdle();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return new bigLeftFacingIdle();
        }

        public IMarioState Fire() {
            return new fireLeftFacingIdle();
        }

        public IMarioState damaged() {
            return new dead();
        }
        public IMarioState Flagpole()
        {
            return new smallLeftFacingFlagPole();
        }
        public void update() {}

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
