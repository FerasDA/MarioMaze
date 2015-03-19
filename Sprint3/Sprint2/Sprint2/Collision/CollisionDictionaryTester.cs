using Microsoft.Xna.Framework;
using Sprint2.Collision.CollisionDictionary;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.Collision.CollisionDictionary.PlayerBlockCollisions;
using Sprint2.Collision.CollisionDictionary.PlayerCollisions.PlayerObjectCollisions.PlayerPipeCollisions;
using Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.Goomba;
using Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.Koopa;
using Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.koopaShell;
using Sprint2.Collision.CollisionDictionary.PlayerItemCollisions;
using Sprint2.Enemies;
using Sprint2.Enemies.KoopaState;
using Sprint2.LevelData;
using Sprint2.Objects;
using Sprint2.Objects.Blocks;
using Sprint2.Objects.FireBall;
using Sprint2.Objects.Items;
using Sprint2.Objects.MegmanBullet;
using Sprint2.Objects.Pipes;
using Sprint2.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision
{
    class CollisionDictionaryTester
    {
        static ArrayList playerList;
        static ArrayList enemyList;
        static ArrayList objectList;
        static ArrayList itemList;
        LevelAssets info;

        ArrayList Collisions = new ArrayList();
        ArrayList modifiedElements = new ArrayList();

        Dictionary<Tuple<Object, object, CollisionType.Collision>, ICollision> collisionMap;
        Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastPlayerEnemyCollisions;
        Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> nextPastPlayerEnemyCollisions;

        CollisionDictionaryModifier modifier;
        public CollisionDictionaryTester() 
        {
            collisionMap = new Dictionary<Tuple<object, object, CollisionType.Collision>, ICollision> { };
            pastPlayerEnemyCollisions = new Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> { };
            nextPastPlayerEnemyCollisions = new Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> { };
        }

        public void BuildDictionary()
        {
            CollisionDictionaryBuilder builder = new CollisionDictionaryBuilder(info,modifiedElements,pastPlayerEnemyCollisions);
            builder.Build(collisionMap);
            modifier = new CollisionDictionaryModifier(info, collisionMap, pastPlayerEnemyCollisions);
        }

        public void SetLevelInfo(LevelAssets info)
        {
            this.info = info;
            playerList = info.GetPlayerList();
            enemyList = info.GetEnemyList();
            objectList = info.GetObjectList();
            itemList = info.GetItemList();
        }

        public void Update()
        {
            modifiedElements.Clear();
            ICollision toExecute;

            getCollisions(Collisions);

            foreach (Tuple<Object, Object, CollisionType.Collision> key in Collisions)
            {
                if (collisionMap.ContainsKey(key))
                {
                    toExecute = collisionMap[key];
                    toExecute.ExecuteCommand();
                }
            }

            modifier.Modify(modifiedElements);
            populatePasterPlayerEnemyCollisions();
        }

        private void populatePasterPlayerEnemyCollisions()
        {
            pastPlayerEnemyCollisions.Clear();
            foreach (Tuple<IPlayer, IEnemy> key in nextPastPlayerEnemyCollisions.Keys)
                pastPlayerEnemyCollisions.Add(key, nextPastPlayerEnemyCollisions[key]);
            nextPastPlayerEnemyCollisions.Clear();
        }

        private void getCollisions(ArrayList Collisions)
        {
            CollisionType ct =  new CollisionType();
            Collisions.Clear();
            foreach (IPlayer p in playerList)
            {
                foreach (IItem i in itemList)
                {
                    Rectangle pRec = p.GetRectangle();
                    Rectangle iRec = i.GetRectangle();
                    CollisionType.Collision c = ct.GetCollisionType(pRec,iRec);
                    if (!c.Equals(CollisionType.Collision.none))
                        Collisions.Add(Tuple.Create<Object, Object, CollisionType.Collision>(p, i, c));
                }

                foreach (IObject obj in objectList)
                {
                    Rectangle pRec = p.GetRectangle();
                    Rectangle objRec = obj.GetRectangle();
                    CollisionType.Collision c = ct.GetCollisionType(pRec, objRec);
                    if (!c.Equals(CollisionType.Collision.none))
                        Collisions.Add(Tuple.Create<Object, Object, CollisionType.Collision>(p, obj, c));
                }
                foreach (IEnemy e in enemyList)
                {
                    Rectangle pRec = p.GetRectangle();
                    Rectangle eRec = e.GetRectangle();
                    CollisionType.Collision c = ct.GetCollisionType(pRec, eRec);
                    if (!c.Equals(CollisionType.Collision.none))
                        Collisions.Add(Tuple.Create<Object, Object, CollisionType.Collision>(p, e, c));
                    nextPastPlayerEnemyCollisions.Add(Tuple.Create<IPlayer, IEnemy>(p, e), c);
                }
            }

            foreach (IEnemy enemy in enemyList)
            {
                foreach (IObject obj in objectList)
                {
                    Rectangle enemyRec = enemy.GetRectangle();
                    Rectangle objRec = obj.GetRectangle();
                    CollisionType.Collision c = ct.GetCollisionType(enemyRec, objRec);
                    if (!c.Equals(CollisionType.Collision.none))
                        Collisions.Add(Tuple.Create<Object, Object, CollisionType.Collision>(enemy, obj, c));
                }
                foreach (IEnemy e in enemyList)
                {
                    Rectangle enemyRec = enemy.GetRectangle();
                    Rectangle eRec = e.GetRectangle();
                    CollisionType.Collision c = ct.GetCollisionType(enemyRec, eRec);
                    if(!c.Equals(CollisionType.Collision.none))
                        Collisions.Add(Tuple.Create<Object, Object, CollisionType.Collision>(enemy, e, c));
                }
            }

            foreach (IObject o in objectList)
            {
                FireBall f = o as FireBall;
                if (f != null)
                {
                    foreach (IObject obj in objectList)
                    {
                        if (f != obj)
                        {
                            Rectangle fRec = f.GetRectangle();
                            Rectangle objRec = obj.GetRectangle();
                            CollisionType.Collision c = ct.GetCollisionType(fRec, objRec);
                            if (!c.Equals(CollisionType.Collision.none))
                                Collisions.Add(Tuple.Create<Object, Object, CollisionType.Collision>(f, obj, c));
                        }
                    }
                    foreach (IEnemy e in enemyList)
                    {
                        Rectangle fRec = f.GetRectangle();
                        Rectangle eRec = e.GetRectangle();
                        CollisionType.Collision c = ct.GetCollisionType(fRec, eRec);
                        if (!c.Equals(CollisionType.Collision.none))
                            Collisions.Add((Tuple.Create<Object, Object, CollisionType.Collision>(f, e, c)));
                    }
                }

                MegamanBullet mmb = o as MegamanBullet;
                if (mmb != null)
                {
                    foreach (IObject obj in objectList)
                    {
                        if (mmb != obj)
                        {
                            Rectangle mmbRec = mmb.GetRectangle();
                            Rectangle objRec = obj.GetRectangle();
                            CollisionType.Collision c = ct.GetCollisionType(mmbRec, objRec);
                            if (!c.Equals(CollisionType.Collision.none))
                                Collisions.Add(Tuple.Create<Object, Object, CollisionType.Collision>(mmb, obj, c));
                        }
                    }
                    foreach (IEnemy e in enemyList)
                    {
                        Rectangle mmbRec = mmb.GetRectangle();
                        Rectangle eRec = e.GetRectangle();
                        CollisionType.Collision c = ct.GetCollisionType(mmbRec, eRec);
                        if (!c.Equals(CollisionType.Collision.none))
                            Collisions.Add((Tuple.Create<Object, Object, CollisionType.Collision>(mmb, e, c)));
                    }
                }
            }

            foreach( IItem i in itemList)
            {
                foreach (IObject obj in objectList)
                {
                    {
                        Rectangle iRec = i.GetRectangle();
                        Rectangle objRec = obj.GetRectangle();
                        CollisionType.Collision c = ct.GetCollisionType(iRec, objRec);
                        if (!c.Equals(CollisionType.Collision.none))
                            Collisions.Add(Tuple.Create<Object, Object, CollisionType.Collision>(i, obj, c));
                    }
                }
            }
        }
    }
}
