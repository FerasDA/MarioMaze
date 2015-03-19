using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Objects.Blocks.BlockState
{
    public interface IBlockState
    {
        void Update();

        IBlockState Collision();

        Rectangle getReferenceRectangle();

        Rectangle getWeakSpot();

        bool IsBumpable();

        bool IsBreakable();
    }
}
