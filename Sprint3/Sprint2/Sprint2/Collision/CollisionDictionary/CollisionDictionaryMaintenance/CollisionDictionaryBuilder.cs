using Sprint2.Enemies;
using Sprint2.Collision.CollisionDictionary;
using Sprint2.Collision.CollisionDictionary.PlayerBlockCollisions;
using Sprint2.Collision.CollisionDictionary.PlayerCollisions.PlayerObjectCollisions.PlayerPipeCollisions;
using Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.Goomba;
using Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.Koopa;
using Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.koopaShell;
using Sprint2.Collision.CollisionDictionary.PlayerItemCollisions;
using Sprint2.LevelData;
using Sprint2.Objects;
using Sprint2.Objects.Blocks;
using Sprint2.Objects.Items;
using Sprint2.Objects.Pipes;
using Sprint2.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Collision.CollisionDictionary.EnemyCollisions.EnemyEnemyCollisions;
using Sprint2.Collision.CollisionDictionary.EnemyCollisions.EnemyObjectCollision;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Player.Items;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Player.Enemy;
using Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemBlockCollision;
using Sprint2.Objects.Flagpole;
using Sprint2.Collision.CollisionDictionary.PlayerCollisions.PlayerObjectCollisions.PlayerFlagPoleCollision;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Item;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance
{
    class CollisionDictionaryBuilder
    {
        ArrayList playerList;
        ArrayList enemyList;
        ArrayList objectList;
        ArrayList itemList;
        ArrayList modifiedElements;
        Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastPlayerEnemyCollisions;
        public CollisionDictionaryBuilder(LevelAssets assets, ArrayList modifiedElements, Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastPlayerEnemyCollisions) 
        {
            playerList = assets.GetPlayerList();
            enemyList = assets.GetEnemyList();
            objectList = assets.GetObjectList();
            itemList = assets.GetItemList();

            this.modifiedElements = modifiedElements;
            this.pastPlayerEnemyCollisions = pastPlayerEnemyCollisions;
        }

        public void Build(Dictionary<Tuple<object, Object, CollisionType.Collision>, ICollision> collisionMap)
        {
            //Player collisions
            foreach (IPlayer p in playerList)
            {
                foreach (IItem i in itemList)
                {
                    Coin c = i as Coin;
                    if (c != null)
                    {
                        PlayerCoinDictionaryBuilder.AddPlayerCoinCollision(collisionMap, p, i);
                    }

                    FireFlower f = i as FireFlower;
                    if (f != null)
                    {
                        PlayerFireFlowerDictionaryBuilder.AddPlayerFireFlowerCollision(collisionMap, p, i);
                    }

                    Mushroom m = i as Mushroom;
                    if (m != null)
                    {
                        PlayerMushroomDictionaryBuilder.AddPlayerMushroomCollision(collisionMap, p, i);
                    }

                    PoisonMushroom pm = i as PoisonMushroom;
                    if (pm != null)
                    {
                        PlayerPoisonMushroomDictionaryBuilder.AddPlayerPoisonMushroomCollision(collisionMap, p, i);
                    }

                    Star star = i as Star;
                    if (star != null)
                    {
                        PlayerStarDictionaryBuilder.AddPlayerStarCollision(collisionMap, p, i);
                    }
                }

                foreach (IEnemy e in enemyList)
                {
                    Goomba g = e as Goomba;
                    if (g != null)
                    {
                        PlayerGoombaDictionaryBuilder.AddPlayerGoombaCollision(collisionMap, p, e, pastPlayerEnemyCollisions);
                    }

                    Koopa k = e as Koopa;
                    if (k != null)
                    {
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.left), new PlayerKoopaCollision(p, e, modifiedElements));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.right), new PlayerKoopaCollision(p, e, modifiedElements));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.top), new PlayerKoopaStomp(p, e, pastPlayerEnemyCollisions, modifiedElements));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.bottom), new PlayerKoopaCollision(p, e, modifiedElements));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.inside), new PlayerKoopaCollision(p, e, modifiedElements));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.consumed), new PlayerKoopaCollision(p, e, modifiedElements));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, e, CollisionType.Collision.none), new NoCollision());
                    }

                    KoopaShell ks = e as KoopaShell;
                    if (ks != null)
                    {
                        PlayerKoopaShellDictionaryBuilder.AddPlayerKoopaShellCollision(collisionMap, p, ks, pastPlayerEnemyCollisions);
                    }
                }
                foreach (IObject o in objectList)
                {
                    Pipe pipe = o as Pipe;
                    if (pipe != null)
                    {
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, pipe, CollisionType.Collision.top), new PlayerPipeCollisionTop(p, pipe));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, pipe, CollisionType.Collision.bottom), new PlayerPipeCollisionBottom(p, pipe));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, pipe, CollisionType.Collision.left), new PlayerPipeCollisionLeft(p, pipe));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, pipe, CollisionType.Collision.right), new PlayerPipeCollisionRight(p, pipe));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, pipe, CollisionType.Collision.inside), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, pipe, CollisionType.Collision.consumed), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, pipe, CollisionType.Collision.none), new NoCollision());
                    }
                    Block b = o as Block;
                    if (b != null)
                    {
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.top), new PlayerBlockCollisionTop(p, o));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.bottom), new PlayerBlockCollisionBottom(p, o));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.left), new PlayerBlockCollisionLeft(p, o));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.right), new PlayerBlockCollisionRight(p, o));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.inside), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.consumed), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.none), new NoCollision());
                    }
                    Pole pole = o as Pole;
                    if (pole!= null)
                    {
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.top), new PlayerPoleCollision(p, o));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.bottom), new PlayerPoleCollision(p, o));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.left), new PlayerPoleCollision(p, o));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.right), new PlayerPoleCollision(p, o));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.inside), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.consumed), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(p, o, CollisionType.Collision.none), new NoCollision());
                    }
                }
            }

            //Enemy Collisions
            foreach (IEnemy enemy in enemyList)
            {
                foreach (IItem i in itemList)
                {
                    Coin c = i as Coin;
                    if (c != null)
                    {
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, c, CollisionType.Collision.left), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, c, CollisionType.Collision.right), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, c, CollisionType.Collision.top), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, c, CollisionType.Collision.bottom), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, c, CollisionType.Collision.inside), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, c, CollisionType.Collision.consumed), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, c, CollisionType.Collision.none), new NoCollision());
                    }

                    FireFlower f = i as FireFlower;
                    if (f != null)
                    {
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, f, CollisionType.Collision.left), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, f, CollisionType.Collision.right), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, f, CollisionType.Collision.top), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, f, CollisionType.Collision.bottom), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, f, CollisionType.Collision.inside), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, f, CollisionType.Collision.consumed), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, f, CollisionType.Collision.none), new NoCollision());
                    }

                    Mushroom m = i as Mushroom;
                    if (m != null)
                    {
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, m, CollisionType.Collision.left), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, m, CollisionType.Collision.right), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, m, CollisionType.Collision.top), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, m, CollisionType.Collision.bottom), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, m, CollisionType.Collision.inside), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, m, CollisionType.Collision.consumed), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, m, CollisionType.Collision.none), new NoCollision());
                    }

                    PoisonMushroom pm = i as PoisonMushroom;
                    if (pm != null)
                    {
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, pm, CollisionType.Collision.left), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, pm, CollisionType.Collision.right), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, pm, CollisionType.Collision.top), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, pm, CollisionType.Collision.bottom), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, pm, CollisionType.Collision.inside), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, pm, CollisionType.Collision.consumed), new NoCollision());
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, pm, CollisionType.Collision.none), new NoCollision());
                    }

                    Star star = i as Star;
                    if (star != null)
                    {
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, star, CollisionType.Collision.left), new EnemyEnemyCollisionTurnAround(enemy));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, star, CollisionType.Collision.right), new EnemyEnemyCollisionTurnAround(enemy));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, star, CollisionType.Collision.top), new EnemyEnemyCollisionTurnAround(enemy));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, star, CollisionType.Collision.bottom), new EnemyEnemyCollisionTurnAround(enemy));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, star, CollisionType.Collision.inside), new EnemyEnemyCollisionTurnAround(enemy));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, star, CollisionType.Collision.consumed), new EnemyEnemyCollisionTurnAround(enemy));
                        collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, star, CollisionType.Collision.none), new NoCollision());
                    }
                }
                KoopaShell koopashell = enemy as KoopaShell;
                if(koopashell != null)
                {
                    foreach (IEnemy e in enemyList)
                    {
                        if(!(e == enemy))
                        {
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.left), new KoopaShellKillCollision(koopashell, e));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.right), new KoopaShellKillCollision(koopashell, e));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.top), new KoopaShellKillCollision(koopashell, e));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.bottom), new KoopaShellKillCollision(koopashell, e));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.inside), new KoopaShellKillCollision(koopashell, e));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.consumed), new KoopaShellKillCollision(koopashell, e));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, e, CollisionType.Collision.none), new NoCollision());
                        }
                    }
                }

                else foreach (IEnemy e in enemyList)
                {
                    if (!(e == enemy))
                    {
                        Goomba g = e as Goomba;
                        if (g != null)
                        {
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, g, CollisionType.Collision.left), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, g, CollisionType.Collision.right), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, g, CollisionType.Collision.top), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, g, CollisionType.Collision.bottom), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, g, CollisionType.Collision.inside), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, g, CollisionType.Collision.consumed), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, g, CollisionType.Collision.none), new NoCollision());
                        }

                        Koopa k = e as Koopa;
                        if (k != null)
                        {
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, k, CollisionType.Collision.left), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, k, CollisionType.Collision.right), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, k, CollisionType.Collision.top), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, k, CollisionType.Collision.bottom), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, k, CollisionType.Collision.inside), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, k, CollisionType.Collision.consumed), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, k, CollisionType.Collision.none), new NoCollision());
                        }

                        KoopaShell ks = e as KoopaShell;
                        if (ks != null)
                        {
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, ks, CollisionType.Collision.left), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, ks, CollisionType.Collision.right), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, ks, CollisionType.Collision.top), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, ks, CollisionType.Collision.bottom), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, ks, CollisionType.Collision.inside), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, ks, CollisionType.Collision.consumed), new EnemyEnemyCollisionTurnAround(enemy));
                            collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, ks, CollisionType.Collision.none), new NoCollision());
                        }
                    }
                }
                foreach (IObject o in objectList)
                {
                    collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.top), new EnemyObjectCollisionTop(enemy,o));
                    collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.bottom), new NoCollision());
                    collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.left), new EnemyObjectCollisionTurnAround(enemy));
                    collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.right), new EnemyObjectCollisionTurnAround(enemy));
                    collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.inside), new NoCollision());
                    collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.consumed), new NoCollision());
                    collisionMap.Add(Tuple.Create<object, object, CollisionType.Collision>(enemy, o, CollisionType.Collision.none), new NoCollision());
                }
            }

            foreach (IItem i in itemList)
            {
                foreach (IObject o in objectList)
                {
                    ItemBlockDictionaryBuilder.AddItemBlockCollision(collisionMap, i, o);
                }
            }
        }
    }
}
