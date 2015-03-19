using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Player.Attacks;

namespace Sprint2.Player.MarioState
{
    class fireRightFacingJumping : IMarioState
    {
        Rectangle refRectangle = new Rectangle(369, 126, 16, 31);
        public fireRightFacingJumping() {}
        public IMarioState Idle() {
            return new fireRightFacingIdle();
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
            return new bigRightFacingJumping();
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
