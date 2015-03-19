using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementRemover
{
    class RemoveFromDictionary
    {
        public static void RemoveDefinition(Dictionary<Tuple<object, Object, CollisionType.Collision>, ICollision> collisionMap, Object object1, Object object2)
        {
            if (collisionMap.ContainsKey(Tuple.Create<object, object, CollisionType.Collision>(object2, object1, CollisionType.Collision.left)))
            {
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object2, object1, CollisionType.Collision.left));
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object2, object1, CollisionType.Collision.right));
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object2, object1, CollisionType.Collision.top));
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object2, object1, CollisionType.Collision.bottom));
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object2, object1, CollisionType.Collision.inside));
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object2, object1, CollisionType.Collision.consumed));
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object2, object1, CollisionType.Collision.none));
            }
            if (collisionMap.ContainsKey(Tuple.Create<object, object, CollisionType.Collision>(object1, object2, CollisionType.Collision.left)))
            {
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object1, object2, CollisionType.Collision.left));
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object1, object2, CollisionType.Collision.right));
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object1, object2, CollisionType.Collision.top));
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object1, object2, CollisionType.Collision.bottom));
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object1, object2, CollisionType.Collision.inside));
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object1, object2, CollisionType.Collision.consumed));
                collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(object1, object2, CollisionType.Collision.none));
            }
        }
    }
}
