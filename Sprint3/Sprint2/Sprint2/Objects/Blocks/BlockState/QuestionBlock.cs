using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Blocks.BlockState
{
    public class QuestionBlock : IBlockState
    {
        double currentFrame = 0;
        static Rectangle[] spriteRef = new Rectangle[] { 
            new Rectangle(Rec.QUESTIONBLOCK_X0, Rec.QUESTIONBLOCK_Y, Rec.BLOCK_W, Rec.BLOCK_H), 
            new Rectangle(Rec.QUESTIONBLOCK_X1, Rec.QUESTIONBLOCK_Y, Rec.BLOCK_W, Rec.BLOCK_H), 
            new Rectangle(Rec.QUESTIONBLOCK_X2, Rec.QUESTIONBLOCK_Y, Rec.BLOCK_W, Rec.BLOCK_H), 
            new Rectangle(Rec.QUESTIONBLOCK_X1, Rec.QUESTIONBLOCK_Y, Rec.BLOCK_W, Rec.BLOCK_H), 
            new Rectangle(Rec.QUESTIONBLOCK_X0, Rec.QUESTIONBLOCK_Y, Rec.BLOCK_W, Rec.BLOCK_H) };
        int totalFrames = spriteRef.Length;
        public QuestionBlock() { }
        public void Update() {
            currentFrame = (currentFrame + .15) % totalFrames;
        }
        public IBlockState Collision()
        {
            return new UsedQuestionBlock();
        }
        public Rectangle getReferenceRectangle()
        {
            return spriteRef[(int) currentFrame];
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
            return (obj as QuestionBlock != null);
        }
    }
}
