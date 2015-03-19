using Microsoft.Xna.Framework;
using Sprint2.Objects;
using Sprint2.Objects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemBlockCollision
{
    class ItemFloorCollision : ICollision
    {
        IItem item;
        IObject block;
        public ItemFloorCollision(IItem i, IObject b)
        {
            item = i;
            block = b;
        }
        public void ExecuteCommand()
        {
            CollisionType ct = new CollisionType();
            Rectangle iRec = item.GetRectangle();
            Rectangle objRec = block.GetRectangle();
            CollisionType.Collision c = ct.GetCollisionType(iRec, objRec);
            while (!c.Equals(CollisionType.Collision.none))
            {
                item.ShiftUp();
                iRec = item.GetRectangle();
                objRec = block.GetRectangle();
                c = ct.GetCollisionType(iRec, objRec);
            }
        }
    }
}
