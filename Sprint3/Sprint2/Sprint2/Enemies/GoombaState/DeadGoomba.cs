using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Enemies.GoombaState
{
    class DeadGoomba : IGoomba
    {
        static Rectangle refRectangle = new Rectangle(Rec.DEADGOOMBA_X, Rec.DEADGOOMBA_Y, Rec.DEADGOOMBA_W, Rec.DEADGOOMBA_H);

        public DeadGoomba(){}

        public void Update()
        {
        }

        public IGoomba Damage()
        {
            return this;
        }

        public Rectangle getRefRectangle()
        {
            return refRectangle;
        }

        public Rectangle GetWeakSpot()
        {
            return new Rectangle(0,refRectangle.Height, refRectangle.Width, refRectangle.Height);
        }

        public override string ToString()
        {
            return "Dead";
        }
    }
}
