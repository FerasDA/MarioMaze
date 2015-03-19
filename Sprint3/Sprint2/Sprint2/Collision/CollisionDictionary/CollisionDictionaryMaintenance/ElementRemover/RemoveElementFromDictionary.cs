using Sprint2.LevelData;
using Sprint2.Objects;
using Sprint2.Objects.Items;
using Sprint2.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementRemover
{
    class RemoveElementFromDictionary
    {
        public static void RemoveDefinition(Dictionary<Tuple<object, Object, CollisionType.Collision>, ICollision> collisionMap, Object object1, LevelAssets assets)
        {
            ArrayList playerList = assets.GetPlayerList();
            ArrayList enemyList = assets.GetEnemyList();
            ArrayList objectList = assets.GetObjectList();
            ArrayList itemList = assets.GetItemList();

            foreach (IPlayer p in playerList)
            {
                if(p != object1)
                {
                    RemoveFromDictionary.RemoveDefinition(collisionMap, object1, p);
                }
            }

            foreach(IEnemy e in enemyList)
            {
                if(e != object1)
                {
                    RemoveFromDictionary.RemoveDefinition(collisionMap, object1, e);
                }
            }

            foreach(IObject o in objectList)
            {
                if(o != object1)
                {
                    RemoveFromDictionary.RemoveDefinition(collisionMap, object1, o);
                }
            }

            foreach(IItem i in itemList)
            {
                if(i != object1){
                    RemoveFromDictionary.RemoveDefinition(collisionMap, object1, i);
                }
            }
        }
    }
}
