using Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemBlockCollision;
using Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemEnemyCollision;
using Sprint2.Objects;
using Sprint2.Objects.MegmanBullet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Item
{
    class MegamanBulletCollisionAdder
    {
        public static void AddMegamanBullet(Dictionary<Tuple<object, object, CollisionType.Collision>, ICollision> collisionMap, LevelData.LevelAssets assets, MegamanBullet mmb)
        {
            ArrayList enemyList = assets.GetEnemyList();
            ArrayList objectList = assets.GetObjectList();

            foreach (IEnemy e in enemyList)
            {
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, e, CollisionType.Collision.left), new MegamanBulletEnemyCollision(mmb, e));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, e, CollisionType.Collision.right), new MegamanBulletEnemyCollision(mmb, e));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, e, CollisionType.Collision.top), new MegamanBulletEnemyCollision(mmb, e));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, e, CollisionType.Collision.bottom), new MegamanBulletEnemyCollision(mmb, e));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, e, CollisionType.Collision.inside), new MegamanBulletEnemyCollision(mmb, e));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, e, CollisionType.Collision.consumed), new MegamanBulletEnemyCollision(mmb, e));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, e, CollisionType.Collision.none), new NoCollision());
            }

            foreach (IObject o in objectList)
            {
                if (o != mmb)
                {
                    MegamanBullet mmb2 = o as MegamanBullet;
                    if (mmb2 == null)
                    {
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, o, CollisionType.Collision.left), new MegamanBlockCollision(mmb));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, o, CollisionType.Collision.right), new MegamanBlockCollision(mmb));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, o, CollisionType.Collision.top), new MegamanBlockCollision(mmb));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, o, CollisionType.Collision.bottom), new MegamanBlockCollision(mmb));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, o, CollisionType.Collision.inside), new MegamanBlockCollision(mmb));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, o, CollisionType.Collision.consumed), new MegamanBlockCollision(mmb));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(mmb, o, CollisionType.Collision.none), new NoCollision());
                    }
                }


            }
        }
    }
}
