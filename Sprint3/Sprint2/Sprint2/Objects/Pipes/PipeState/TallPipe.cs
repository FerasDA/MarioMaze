using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Pipes.PipeState
{
    class TallPipe : IPipeState
    {
        Rectangle refRectangle = new Rectangle(Rec.TPIPE_X, Rec.TPIPE_Y, Rec.TPIPE_W, Rec.TPIPE_H);
        public TallPipe() { }
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
