using Sprint2.Objects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemBlockCollision
{
    class ItemWallCollision : ICollision
    {
        IItem item;
        public ItemWallCollision(IItem i)
        {
            item = i;
        }
        public void ExecuteCommand()
        {
            item.TurnAround();
        }
    }
}
