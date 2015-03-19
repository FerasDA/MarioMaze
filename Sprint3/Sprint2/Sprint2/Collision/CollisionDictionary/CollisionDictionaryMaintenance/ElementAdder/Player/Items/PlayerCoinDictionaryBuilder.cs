using Sprint2.Collision.CollisionDictionary.PlayerItemCollisions;
using Sprint2.Objects.Items;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Player.Items
{
    class PlayerCoinDictionaryBuilder
    {
        public static void AddPlayerCoinCollision(Dictionary<Tuple<object, Object, CollisionType.Collision>, ICollision> collisionMap, IPlayer p, IItem i)
        {
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.left), new PlayerCoinCollision(p, i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.right), new PlayerCoinCollision(p, i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.top), new PlayerCoinCollision(p, i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.bottom), new PlayerCoinCollision(p, i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.inside), new PlayerCoinCollision(p, i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.consumed), new PlayerCoinCollision(p, i));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, i, CollisionType.Collision.none), new NoCollision());
        }
    }
}
