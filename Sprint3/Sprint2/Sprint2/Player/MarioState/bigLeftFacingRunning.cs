using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Constants;

namespace Sprint2.Player.MarioState
{
    class bigLeftFacingRunning : IMarioState
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { 
            new Rectangle(Rec.BLFRUNNING_X0, Rec.BIGRUNNING_Y0, Rec.BIGRUNNING_W0, Rec.BIGRUNNING_H0), 
            new Rectangle(Rec.BLFRUNNING_X1, Rec.BIGRUNNING_Y1, Rec.BIGRUNNING_W1, Rec.BIGRUNNING_H1), 
            new Rectangle(Rec.BLFRUNNING_X2, Rec.BIGRUNNING_Y2, Rec.BIGRUNNING_W2, Rec.BIGRUNNING_H2) };
        int totalFrames = refRectangle.Length;
        public bigLeftFacingRunning() { }
        public IMarioState Idle() {
            return new bigLeftFacingIdle();
        }

        public IMarioState Jump() {
            return new bigLeftFacingJumping();
        }

        public IMarioState Crouch() {
            return new bigLeftFacingCrouching();
        }

        public IMarioState Left() {
            return this;
        }

        public IMarioState Right() {
            return new bigLeftFacingIdle();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return this;
        }

        public IMarioState Fire() {
            return new fireLeftFacingRunning();
        }

        public IMarioState damaged() {
            return new smallLeftFacingRunning();
        }
        public IMarioState Flagpole()
        {
            return new bigLeftFacingFlagPole();
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
