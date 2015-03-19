using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Pipes.PipeState
{
    class MediumPipe : IPipeState
    {
        Rectangle refRectangle = new Rectangle(Rec.MPIPE_X, Rec.MPIPE_Y, Rec.MPIPE_W, Rec.MPIPE_H);
        public MediumPipe() { }
        public void Update() { }
        public IPipeState Collision()
        {
            return this;
        }
        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }
        public Rectangle GetWeakSpot()
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }
}
