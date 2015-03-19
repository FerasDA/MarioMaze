using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Constants;

namespace Sprint2.Player.MarioState
{
    class bigRightFacingRunning : IMarioState
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { 
            new Rectangle(Rec.BRFRUNNING_X0, Rec.BIGRUNNING_Y0, Rec.BIGRUNNING_W0, Rec.BIGRUNNING_H0), 
            new Rectangle(Rec.BRFRUNNING_X1, Rec.BIGRUNNING_Y1, Rec.BIGRUNNING_W1, Rec.BIGRUNNING_H1), 
            new Rectangle(Rec.BRFRUNNING_X2, Rec.BIGRUNNING_Y2, Rec.BIGRUNNING_W2, Rec.BIGRUNNING_H2) };
        int totalFrames = refRectangle.Length;
        public bigRightFacingRunning() { }
        public IMarioState Idle() {
            return new bigRightFacingIdle();
        }

        public IMarioState Jump() {
            return new bigRightFacingJumping();
        }

        public IMarioState Crouch() {
            return new bigRightFacingCrouching();
        }

        public IMarioState Left() {
            return new bigRightFacingIdle();
        }

        public IMarioState Right() {
            return this;
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return this;
        }

        public IMarioState Fire() {
            return new fireRightFacingRunning();
        }

        public IMarioState damaged() {
            return new smallRightFacingRunning();
        }
        public IMarioState Flagpole()
        {
            return new bigRightFacingFlagPole();
        }
        public void update() {
            currentFrame = (currentFrame + .1) % totalFrames;
        }

        public Rectangle getReferenceRectangle()
        {
            return refRectangle[(int)currentFrame];
        }
    }
}
