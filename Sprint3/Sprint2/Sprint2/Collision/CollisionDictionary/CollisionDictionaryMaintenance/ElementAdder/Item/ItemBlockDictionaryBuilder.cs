using Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemBlockCollision;
using Sprint2.Objects;
using Sprint2.Objects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Item
{
    class ItemBlockDictionaryBuilder
    {
        public static void AddItemBlockCollision(Dictionary<Tuple<object, Object, CollisionType.Collision>, ICollision> collisionMap, IItem i, IObject o)
        {
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(i, o, CollisionType.Collision.top), new ItemFloorCollision(i, o));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(i, o, CollisionType.Collision.bottom), new NoCollision());
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(i, o, CollisionType.Collision.left), new ItemWallCollision(i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(i, o, CollisionType.Collision.right), new ItemWallCollision(i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(i, o, CollisionType.Collision.inside), new NoCollision());
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(i, o, CollisionType.Collision.consumed), new NoCollision());
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(i, o, CollisionType.Collision.none), new NoCollision());
        }
    }
}
