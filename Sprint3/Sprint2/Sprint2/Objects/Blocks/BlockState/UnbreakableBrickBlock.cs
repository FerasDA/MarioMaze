using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Blocks.BlockState
{
    class UnbreakableBrickBlock : IBlockState
    {
        Rectangle refRectangle = new Rectangle(Rec.BRICKBLOCK_X, Rec.BRICKBLOCK_Y, Rec.BLOCK_W, Rec.BLOCK_H);
        int bumpCount = 5;

        public UnbreakableBrickBlock() { }
        public void Update() { }
        public IBlockState Collision()
        {
            if (bumpCount <= 0)
                return new UsedBlock();
            bumpCount--;
            return this;
        }
        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }

        public Rectangle getWeakSpot()
        {
            return new Rectangle(1, 1, 14, 1);
        }

        public bool IsBumpable()
        {
            return true;
        }


        public bool IsBreakable()
        {
            return false;
        }

        public override bool Equals(object obj)
        {
            return (obj as UnbreakableBrickBlock != null);
        }
    }
}
