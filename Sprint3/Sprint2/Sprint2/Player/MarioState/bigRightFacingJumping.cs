using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Constants;

namespace Sprint2.Player.MarioState
{
    class bigRightFacingJumping : IMarioState
    {
        Rectangle refRectangle = new Rectangle(Rec.BRFJUMPING_X, Rec.BIGJUMPING_Y, Rec.BIGJUMPING_W, Rec.BIGJUMPING_H);
        public bigRightFacingJumping() {}
        public IMarioState Idle() {
            return new bigRightFacingIdle();
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
            return new fireRightFacingJumping();
        }

        public IMarioState damaged() {
            return new smallRightFacingJumping();
        }
        public IMarioState Flagpole()
        {
            return new bigRightFacingFlagPole();
        }
        public void update() {}

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
