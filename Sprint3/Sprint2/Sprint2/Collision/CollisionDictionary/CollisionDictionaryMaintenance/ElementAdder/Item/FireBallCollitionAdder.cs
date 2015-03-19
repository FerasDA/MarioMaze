using Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemBlockCollision;
using Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemEnemyCollision;
using Sprint2.Objects;
using Sprint2.Objects.FireBall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Item
{
    class FireBallCollitionAdder
    {
        public static void AddFireBall(Dictionary<Tuple<object, object, CollisionType.Collision>, ICollision> collisionMap, LevelData.LevelAssets assets, Objects.FireBall.FireBall fb)
        {
            ArrayList enemyList = assets.GetEnemyList();
            ArrayList objectList = assets.GetObjectList();

            foreach(IEnemy e in enemyList)
            {
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, e, CollisionType.Collision.left), new FireBallEnemyCollision(fb, e));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, e, CollisionType.Collision.right), new FireBallEnemyCollision(fb, e));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, e, CollisionType.Collision.top), new FireBallEnemyCollision(fb, e));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, e, CollisionType.Collision.bottom), new FireBallEnemyCollision(fb, e));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, e, CollisionType.Collision.inside), new FireBallEnemyCollision(fb, e));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, e, CollisionType.Collision.consumed), new FireBallEnemyCollision(fb, e));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, e, CollisionType.Collision.none), new NoCollision());
            }

            foreach (IObject o in objectList)
            {
                if( o != fb)
                {
                    FireBall fb2 = o as FireBall;
                    if(fb2 == null)
                    {
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, o, CollisionType.Collision.left), new FireBallWallCollision(fb));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, o, CollisionType.Collision.right), new FireBallWallCollision(fb));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, o, CollisionType.Collision.top), new FireBallFloorCollision(fb));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, o, CollisionType.Collision.bottom), new FireBallWallCollision(fb));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, o, CollisionType.Collision.inside), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, o, CollisionType.Collision.consumed), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(fb, o, CollisionType.Collision.none), new NoCollision());
                    }
                }


            }
        }
    }
}
