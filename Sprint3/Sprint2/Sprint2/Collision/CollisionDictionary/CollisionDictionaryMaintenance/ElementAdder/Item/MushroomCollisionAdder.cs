using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Player.Items;
using Sprint2.LevelData;
using Sprint2.Objects;
using Sprint2.Objects.Items;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance.ElementAdder.Item
{
    class MushroomCollisionAdder
    {
        public static void AddMushroom(Dictionary<Tuple<object, object, CollisionType.Collision>, ICollision> collisionMap, LevelAssets assets, Mushroom m)
        {
            //add player collision
            foreach (IPlayer p in assets.GetPlayerList())
            {
                PlayerMushroomDictionaryBuilder.AddPlayerMushroomCollision(collisionMap, p, m);
            }

            //add object collision
            foreach (IObject o in assets.GetObjectList())
            {
                ItemBlockDictionaryBuilder.AddItemBlockCollision(collisionMap, m, o);
            }

        }
    }
}
