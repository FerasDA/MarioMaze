using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Pipes.PipeState
{
    class ShortPipe : IPipeState
    {
        Rectangle refRectangle = new Rectangle(Rec.SPIPE_X, Rec.SPIPE_Y, Rec.SPIPE_W, Rec.SPIPE_H);
        public ShortPipe() { }
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
