using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MarioState
{
    class smallLeftFacingFlagPole : IMarioState
    {
        Rectangle refRectangle = new Rectangle(127,45,12,15);
        public smallLeftFacingFlagPole() { }
        public IMarioState Idle() {
            return new smallLeftFacingIdle();
        }

        public IMarioState Jump() {
            return new smallLeftFacingJumping();
        }

        public IMarioState Crouch() {
            return new smallLeftFacingIdle();
        }

        public IMarioState Left() {
            return new smallLeftFacingRunning();
        }

        public IMarioState Right() {
            return new smallRightFacingIdle();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return new bigLeftFacingFlagPole();
        }

        public IMarioState Fire() {
            return new fireLeftFacingFlagPole();
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
