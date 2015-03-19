using Sprint2.Cameras;
using Sprint2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.PlayerPhysics
{
    class MegamanPhysics
    {
        Megaman megaman;
        bool isJumping = false;
        bool canJump;
        double xPos;
        double yPos;

        double xVelos=0;
        double yVelos=0;

        bool isRunning = false;
        double xVelosMinRunning = -2.5;
        double xVelosMaxRunning = 2.7;
        double xVelosMinWalking = -1.3;
        double xVelosMaxWalking = 1.7;
        double xVelosMin = -1.5;
        double xVelosMax = 1.5;

        double yVelosMin = -5.30;
        double yVelosMax = 5;
        double bounceVelos = -4;

        double jumpingDeltaY = 0.20;
        double fallingDeltaY = 0.55;

        double yVelosMinFlagPole= -2;
        double yVelosMaxFlagPole= 2;

        bool wasPressingUp = false;
        bool wasPressingRight = false;
        bool wasPressingLeft = false;
        bool wasPressingAttack = false;
        int AttackCoolDown = 0;

        bool isPressingUp = false;
        bool isPressingDown = false;
        bool isPressingLeft = false;
        bool isPressingRight = false;
        bool isPressingAttack = false;

        Camera camera = new Camera();

        SoundController sc = new SoundController();

        public MegamanPhysics(Megaman p, int x, int y)
        {
            megaman = p;
            xPos = x;
            yPos = y;
        }

        public Tuple<int, int> GetLocation()
        {
            return Tuple.Create<int,int>((int)xPos,(int)yPos);
        }

        public void Update()
        {
            xVelosBoundsUpdate();

            DisableCounterKeyPresses();
            if ((!(( (isPressingUp && !wasPressingUp) || isPressingDown) || (isPressingLeft || isPressingRight))) && !isJumping && AttackCoolDown==0) 
                megaman.Idle();

            if (megaman.ToString().Equals("dead"))
            {
                xVelosMax = 0;
                xVelosMin = 0;
                yVelosMax = 0;
                yVelosMin = 0;
            }

            //jumping
            if (isPressingUp)
            {
                if (!(isJumping) && canJump)
                {
                    sc.Jump();
                    megaman.state = megaman.state.Jump();
                    isJumping = true;
                    canJump = false;
                    yVelos = yVelosMin;
                }
                else
                {
                    if (yVelos < 0)
                        yVelos += jumpingDeltaY;
                    else
                        yVelos += fallingDeltaY;
                }
            }
            //gravity
            else
                yVelos += fallingDeltaY;

            //cant jump if he is falling
                //mario will fall at constantly into the ground, he can get a falling velos of up to 1.1 while just standing on the ground
                //so since 1.2 > 1.1 this will test to see if he is actually falling
            if (yVelos > 1.2)
                canJump = false;


            //left right motion
            if (isPressingRight && !isPressingDown)
                xVelos += .13;
            else if (isPressingLeft && !isPressingDown)
                xVelos -= .13;
            else
            {
                if (xVelos > 0.15)
                    xVelos -= .13;
                else if (xVelos < -0.15)
                    xVelos += .13;
                else
                    xVelos = 0;
            }

            velosBoundTest();
            xPos += xVelos;
            yPos += yVelos;


          //  if (isPressingUp || isPressingDown || isPressingLeft || isPressingRight)
          //      Console.WriteLine("Marios velocity is " + xVelos + " in the X demension and " + yVelos + " in the Y demesion.");

            if(xPos < camera.GetCameraOffset())
            {
                xPos = camera.GetCameraOffset();
                xVelos = 0;
            }

            wasPressingUp = isPressingUp;
            wasPressingRight = isPressingRight;
            wasPressingLeft = isPressingLeft;
            wasPressingAttack = isPressingAttack;

            isPressingUp = false;
            isPressingDown = false;
            isPressingLeft = false;
            isPressingRight = false;
            isPressingAttack = false;
            isRunning = false;

            if (AttackCoolDown >= 1)
                AttackCoolDown--;
        }

        private void xVelosBoundsUpdate()
        {
            if (isRunning && canJump)
            { 
                xVelosMin =xVelosMinRunning;
                xVelosMax = xVelosMaxRunning;
            }
            else if (!isRunning && canJump)
            {
                xVelosMin = xVelosMinWalking;
                xVelosMax = xVelosMaxWalking;
            }
        }

        private void velosBoundTest()
        {
            if (xVelos > xVelosMax)
                xVelos = xVelosMax;
            else if (xVelos < xVelosMin)
                xVelos = xVelosMin;

            if (yVelos > yVelosMax)
                yVelos = yVelosMax;
            else if (yVelos < yVelosMin)
                yVelos = yVelosMin;
        }

        public void PressingUp()
        {
            isPressingUp = true;
        }

        public void PressingDown()
        {
            isPressingDown = true;
        }

        public void PressingLeft()
        {
            isPressingLeft = true;
        }

        public void PressingRight()
        {
            isPressingRight = true;
        }

        public void Running()
        {
            isRunning = true;
        }

        private void DisableCounterKeyPresses()
        {
            if (isPressingUp == isPressingDown)
            {
                isPressingUp = false;
                isPressingDown = false;
            }
            if (isPressingLeft == isPressingRight)
            {
                isPressingLeft = false;
                isPressingRight = false;
            }
        }

        public void ShiftLeft()
        {
            if (!canJump && wasPressingRight && !wasPressingLeft)
                xVelos = 0;
            xPos--;
        }

        public void ShiftRight()
        {
            if (!canJump && wasPressingLeft && !wasPressingRight)
                xVelos = 0;
            xPos++;
        }
        public void ShiftUp()
        {
            if (isJumping)
                megaman.Idle();
            isJumping = false;
            if(!wasPressingUp)
                canJump = true;
            yVelos = 0;
            yPos--;
        }
        public void ShiftDown()
        {
            yVelos = 0;
            yPos++;
        }

        public bool IsJumping()
        {
            Console.WriteLine("I'm jumping");
            return isJumping;
        }

        public void Bounce()
        {
            yVelos = bounceVelos;
        }

        public void Flagpole()
        {
            xVelos = 0;
            xPos += 6;
            yVelosMin = yVelosMinFlagPole;
            yVelosMax = yVelosMaxFlagPole;
        }

        internal void PressedAttack()
        {
            isPressingAttack = true;
            wasPressingAttack = true;
            AttackCoolDown = 20;
        }
    }
}
