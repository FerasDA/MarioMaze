using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Enemies.GoombaState
{
    class WalkingGoomba : IGoomba
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { 
            new Rectangle(Rec.WALKINGGOOMBA_X0, Rec.WALKINGGOOMBA_Y, Rec.WALKINGGOOMBA_W, Rec.WALKINGGOOMBA_H), 
            new Rectangle(Rec.WALKINGGOOMBA_X1, Rec.WALKINGGOOMBA_Y, Rec.WALKINGGOOMBA_W, Rec.WALKINGGOOMBA_H) };
        int totalFrames = refRectangle.Length;

        public WalkingGoomba(){}

        public void Update()
        {
            currentFrame = (currentFrame + .1) % totalFrames;
        }

        public IGoomba Damage()
        {
            return new DeadGoomba();
        }

        public Rectangle getRefRectangle()
        {
            return refRectangle[(int)currentFrame];
        }


        public Rectangle GetWeakSpot()
        {
            return new Rectangle(0, refRectangle[(int)currentFrame].Height, refRectangle[(int)currentFrame].Width, 1);
        }
    }
}
