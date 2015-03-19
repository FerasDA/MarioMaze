using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.LevelData;
using Sprint2.Player.Attacks;

namespace Sprint2.Player.MarioState
{
    class fireRightFacingIdle : IMarioState
    {
        Rectangle refRectangle = new Rectangle(258, 125, 16, 32);
        int fireBallCoolDown = 0;
        public fireRightFacingIdle() {}
        public IMarioState Idle() {
            return this;
        }

        public IMarioState Jump() {
            return new fireRightFacingJumping();
        }

        public IMarioState Crouch() {
            return new fireRightFacingCrouching();
        }

        public IMarioState Left() {
            return new fireLeftFacingIdle();
        }

        public IMarioState Right() {
            return new fireRightFacingRunning();
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
            return new bigRightFacingIdle();
        }
        public IMarioState Flagpole()
        {
            return new fireRightFacingFlagPole();
        }
        public void update() {
            fireBallCoolDown--;
        }

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
    }
}
