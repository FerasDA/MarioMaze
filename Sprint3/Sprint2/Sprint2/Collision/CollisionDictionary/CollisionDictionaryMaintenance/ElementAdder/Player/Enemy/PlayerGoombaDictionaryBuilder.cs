using Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.Goomba;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Player.Enemy
{
    class PlayerGoombaDictionaryBuilder
    {
        public static void AddPlayerGoombaCollision(Dictionary<Tuple<object, Object, CollisionType.Collision>, ICollision> collisionMap, IPlayer p, IEnemy e, Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastPlayerEnemyCollisions)
        {
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.left), new PlayerGoombaCollision(p, e));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.right), new PlayerGoombaCollision(p, e));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.top), new PlayerGoombaStomp(p, e, pastPlayerEnemyCollisions));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.bottom), new PlayerGoombaCollision(p, e));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.inside), new PlayerGoombaCollision(p, e));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.consumed), new PlayerGoombaCollision(p, e));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.none), new NoCollision());
        }
    }
}
