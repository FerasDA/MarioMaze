using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Pipes.PipeState
{
    class LeftFacingPipe : IPipeState
    {
        Rectangle refRectangle = new Rectangle(Rec.LFPIPE_X, Rec.LFPIPE_Y, Rec.LFPIPE_W, Rec.LFPIPE_H);
        public LeftFacingPipe() { }
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
