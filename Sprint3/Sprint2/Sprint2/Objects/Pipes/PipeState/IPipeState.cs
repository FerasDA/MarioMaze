using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Objects.Pipes.PipeState
{
    public interface IPipeState
    {
        void Update();
        IPipeState Collision();
        Rectangle getReferenceRectangle();
        Rectangle GetWeakSpot();
    }
}
