using Microsoft.Xna.Framework;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Item;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementRemover;
using Sprint2.Collision.CollisionDictionary.EnemyCollisions.EnemyEnemyCollisions;
using Sprint2.Collision.CollisionDictionary.EnemyCollisions.EnemyObjectCollision;
using Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.koopaShell;
using Sprint2.Enemies;
using Sprint2.Enemies.KoopaState;
using Sprint2.LevelData;
using Sprint2.Objects;
using Sprint2.Objects.FireBall;
using Sprint2.Objects.Items;
using Sprint2.Objects.MegmanBullet;
using Sprint2.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance
{
    class CollisionDictionaryModifier
    {
        static ArrayList enemyList;
        static ArrayList playerList;
        static ArrayList itemList;
        static ArrayList objectList;
        RemoveElementList toRemove = new RemoveElementList();
        AddElementList toAdd = new AddElementList();
        LevelAssets assets;
        Dictionary<Tuple<Object, Object, CollisionType.Collision>, ICollision> collisionMap;
        Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastPlayerEnemyCollisions;

        public CollisionDictionaryModifier(LevelAssets assets, Dictionary<Tuple<Object, Object, CollisionType.Collision>, ICollision> collisionMap, Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastPlayerEnemyCollisions)
        {
            this.collisionMap = collisionMap;
            this.pastPlayerEnemyCollisions = pastPlayerEnemyCollisions;
            this.assets = assets;
            enemyList = assets.GetEnemyList();
            playerList = assets.GetPlayerList();
            itemList = assets.GetItemList();
            objectList = assets.GetObjectList();
        }

        public void Modify(ArrayList modifiedElements)
        {
            foreach (Object o in modifiedElements)
            {
                IItem i = o as IItem;
                if (itemList.Contains(o))
                    itemList.Remove(o);

                IObject b = o as IObject;
                if (objectList.Contains(b))
                    objectList.Remove(b);

                IEnemy e = o as IEnemy;
                if (enemyList.Contains(e))
                {
                    Koopa k = e as Koopa;
                    koopaToKoopaShell(k);
                }
            }


            foreach (Object o in toRemove.GetList())
            {
                IItem i = o as IItem;
                if (itemList.Contains(o))
                    itemList.Remove(o);

                IObject b = o as IObject;
                if (objectList.Contains(b))
                {
                    objectList.Remove(b);
                    RemoveElementFromDictionary.RemoveDefinition(collisionMap, b, assets);
                }

                IEnemy e = o as IEnemy;
                if (enemyList.Contains(e))
                {
                    enemyList.Remove(e);
                    //Goomba g = e as Goomba;
                    //if (g != null)
                    //    enemyList.Remove(g);
                    //Koopa k = e as Koopa;
                    //if (k != null)
                    //    enemyList.Remove(k);//koopaToKoopaShell(k);
                    //KoopaShell ks = e as KoopaShell
                }
            }

            foreach( object o in toAdd.GetList())
            {
                IItem i = o as IItem;
                if (i != null)
                {
                    itemList.Add(o);

                    //add star
                    Star s = i as Star;
                    if(s != null)
                    {
                        StarCollisionAdder.AddStar(collisionMap, assets, s);
                    }

                    //add mushroom
                    Mushroom m = i as Mushroom;
                    if (m != null)
                    {
                        MushroomCollisionAdder.AddMushroom(collisionMap,assets,m);
                    }
                    //add poision
                    PoisonMushroom pm = i as PoisonMushroom;
                    if(pm != null)
                    {
                        PosionMushroomCollisionAdder.AddPosionMushroom(collisionMap,assets,pm);
                    }

                    //add fireflower
                    FireFlower ff = i as FireFlower;
                    if( ff != null)
                    {
                        FireFlowerCollisionAdder.AddFireFlower(collisionMap, assets, ff);
                    }
                }

                IObject b = o as IObject;
                if (b != null)
                { 
                    objectList.Add(b);
                    FireBall fb = b as FireBall;
                    if(fb != null)
                    {
                        FireBallCollitionAdder.AddFireBall(collisionMap, assets, fb);
                    }

                    MegamanBullet mmb = b as MegamanBullet;
                    if(mmb != null)
                    {
                        MegamanBulletCollisionAdder.AddMegamanBullet(collisionMap, assets, mmb);
                    }
                }

                IEnemy e = o as IEnemy;
                if (e!= null)
                {
                    enemyList.Add(e);
                }
            }
            toRemove.Clear();
            toAdd.Clear();
        }

        private void koopaToKoopaShell(Koopa k)
        {
            Rectangle koopaRectangle = k.GetRectangle();
            int koopaX = koopaRectangle.X;
            int koopaY = koopaRectangle.Y + koopaRectangle.Height;
            KoopaShell ks = new KoopaShell(assets.GetEnemiesTexture(), koopaX, koopaY, new ShellKoopa());

            enemyList.Remove(k);
            enemyList.Add(ks);

            RemoveElementFromDictionary.RemoveDefinition(collisionMap,k,assets);
            foreach (IPlayer p in playerList)
            {
                //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(p, k, CollisionType.Collision.left));
                //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(p, k, CollisionType.Collision.right));
                //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(p, k, CollisionType.Collision.top));
                //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(p, k, CollisionType.Collision.bottom));
                //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(p, k, CollisionType.Collision.inside));
                //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(p, k, CollisionType.Collision.consumed));
                //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(p, k, CollisionType.Collision.none));

                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.left), new PlayerKoopaShellCollision(p, ks, pastPlayerEnemyCollisions));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.right), new PlayerKoopaShellCollision(p, ks, pastPlayerEnemyCollisions));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.top), new PlayerKoopaShellStomp(p, ks, pastPlayerEnemyCollisions));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.bottom), new PlayerKoopaShellCollision(p, ks, pastPlayerEnemyCollisions));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.inside), new PlayerKoopaShellCollision(p, ks, pastPlayerEnemyCollisions));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.consumed), new PlayerKoopaShellCollision(p, ks, pastPlayerEnemyCollisions));
                collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, ks, CollisionType.Collision.none), new NoCollision());
            }
            IEnemy enemy = ks;
            foreach (IEnemy e in enemyList)
                {
                    if (!(e == enemy))
                    {
                        //RemoveFromDictionary.RemoveDefinition(collisionMap, k, e);

                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.left), new KoopaShellKillCollision(ks, e));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.right), new KoopaShellKillCollision(ks, e));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.top), new KoopaShellKillCollision(ks, e));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.bottom), new KoopaShellKillCollision(ks, e));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.inside), new KoopaShellKillCollision(ks, e));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.consumed), new KoopaShellKillCollision(ks, e));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.none), new NoCollision());

                        //Fallowing adds need to be changed to allow for other enemy differences such as koopashell being different from goomba

                        KoopaShell k2 = e as KoopaShell;
                        if (k2 != null)
                        {
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.left), new KoopaShellKillCollision(k2, enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.right), new KoopaShellKillCollision(k2, enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.top), new KoopaShellKillCollision(k2, enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.bottom), new KoopaShellKillCollision(k2, enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.inside), new KoopaShellKillCollision(k2, enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.consumed), new KoopaShellKillCollision(k2, enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.none), new NoCollision());
                        }
                        else
                        {
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.left), new EnemyEnemyCollisionTurnAround(e));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.right), new EnemyEnemyCollisionTurnAround(e));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.top), new EnemyEnemyCollisionTurnAround(e));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.bottom), new EnemyEnemyCollisionTurnAround(e));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.inside), new EnemyEnemyCollisionTurnAround(e));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.consumed), new EnemyEnemyCollisionTurnAround(e));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(e, enemy, CollisionType.Collision.none), new NoCollision());
                        }
                    }
                }
           foreach (IObject o in objectList)
           {
               //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(k, o, CollisionType.Collision.left));
               //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(k, o, CollisionType.Collision.right));
               //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(k, o, CollisionType.Collision.top));
               //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(k, o, CollisionType.Collision.bottom));
               //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(k, o, CollisionType.Collision.inside));
               //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(k, o, CollisionType.Collision.consumed));
               //collisionMap.Remove(Tuple.Create<object, object, CollisionType.Collision>(k, o, CollisionType.Collision.none));

               collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.top), new EnemyObjectCollisionTop(enemy,o));
               collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.bottom), new EnemyObjectCollisionTurnAround(enemy));
               collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.left), new EnemyObjectCollisionTurnAround(enemy));
               collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.right), new EnemyObjectCollisionTurnAround(enemy));
               collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.inside), new NoCollision());
               collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.consumed), new NoCollision());
               collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.none), new NoCollision());
           }
        }
    }
}
