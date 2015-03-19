using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Pipes.PipeState
{
    class TallUndergroundPipe : IPipeState
    {
        Rectangle refRectangle = new Rectangle(Rec.TUPIPE_X, Rec.TUPIPE_Y, Rec.TUPIPE_W, Rec.TUPIPE_H);
        public TallUndergroundPipe() { }
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
