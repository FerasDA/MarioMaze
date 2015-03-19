using Sprint2.Collision.CollisionDictionary.PlayerItemCollisions;
using Sprint2.Objects.Items;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Player.Items
{
    class PlayerStarDictionaryBuilder
    {
        public static void AddPlayerStarCollision(Dictionary<Tuple<object, Object, CollisionType.Collision>, ICollision> collisionMap, IPlayer p, IItem i)
        {
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.left), new PlayerStarCollision(p, i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.right), new PlayerStarCollision(p, i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.top), new PlayerStarCollision(p, i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.bottom), new PlayerStarCollision(p, i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.inside), new PlayerStarCollision(p, i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.consumed), new PlayerStarCollision(p, i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.none), new NoCollision());
        }
    }
}
