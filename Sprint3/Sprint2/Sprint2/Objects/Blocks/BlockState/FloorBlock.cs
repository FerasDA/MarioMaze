﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Blocks.BlockState
{
    class FloorBlock : IBlockState
    {
        Rectangle refRectangle = new Rectangle(Rec.FLOORBLOCK_X, Rec.FLOORBLOCK_Y, Rec.BLOCK_W, Rec.BLOCK_H);

        public FloorBlock() { }
        public void Update() { }
        public IBlockState Collision()
        {
            return this;
        }
        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }

        public Rectangle getWeakSpot()
        {
            return new Rectangle(0,0,0,0);
        }

        public bool IsBumpable()
        {
            return false;
        }


        public bool IsBreakable()
        {
            return false;
        }

        public override bool Equals(object obj)
        {
            return (obj as FloorBlock != null);
        }
    }
}
