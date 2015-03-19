using Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.koopaShell;
using Sprint2.Enemies;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Player.Enemy
{
    class PlayerKoopaShellDictionaryBuilder
    {
        public static void AddPlayerKoopaShellCollision(Dictionary<Tuple<object, Object, CollisionType.Collision>, ICollision> collisionMap, IPlayer p, KoopaShell ks, Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastPlayerEnemyCollisions)
        {
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.left), new PlayerKoopaShellCollision(p, ks, pastPlayerEnemyCollisions));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.right), new PlayerKoopaShellCollision(p, ks, pastPlayerEnemyCollisions));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.top), new PlayerKoopaShellStomp(p, ks, pastPlayerEnemyCollisions));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.bottom), new PlayerKoopaShellCollision(p, ks, pastPlayerEnemyCollisions));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.inside), new PlayerKoopaShellCollision(p, ks, pastPlayerEnemyCollisions));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.consumed), new PlayerKoopaShellCollision(p, ks, pastPlayerEnemyCollisions));
            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.none), new NoCollision());
        }
    }
}
