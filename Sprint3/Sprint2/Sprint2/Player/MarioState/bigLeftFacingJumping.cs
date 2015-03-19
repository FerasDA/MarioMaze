using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Constants;

namespace Sprint2.Player.MarioState
{
    class bigLeftFacingJumping : IMarioState
    {
        Rectangle refRectangle = new Rectangle(Rec.BLFJUMPING_X, Rec.BIGJUMPING_Y, Rec.BIGJUMPING_W, Rec.BIGJUMPING_H);
        public bigLeftFacingJumping() {}
        public IMarioState Idle() {
            return new bigLeftFacingIdle();
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
            return this;
        }

        public IMarioState Fire() {
            return new fireLeftFacingJumping();
        }

        public IMarioState damaged() {
            return new smallLeftFacingJumping();
        }
        public IMarioState Flagpole()
        {
            return new bigLeftFacingFlagPole();
        }

        public void update() {}

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
