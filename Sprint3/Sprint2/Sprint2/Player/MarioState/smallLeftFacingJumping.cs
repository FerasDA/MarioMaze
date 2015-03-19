using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2.Player.MarioState
{
    class smallLeftFacingJumping : IMarioState
    {
        Rectangle refRectangle = new Rectangle(142, 44, 16, 16);
        public smallLeftFacingJumping() {}
        public IMarioState Idle() {
            return new smallLeftFacingIdle();
        }

        public IMarioState Jump() {
            return this;
        }

        public IMarioState Crouch() {
            return this;
        }

        //mario cant turn left or right when jumping
        public IMarioState Left() {
            return this;
        }

        //mario cant turn left or right when jumping
        public IMarioState Right() {
            return this;
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return new bigLeftFacingJumping();
        }

        public IMarioState Fire() {
            return new fireLeftFacingJumping();
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
