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
    class StarCollisionAdder
    {
        public static void AddStar(Dictionary<Tuple<object, object, CollisionType.Collision>, ICollision> collisionMap, LevelAssets assets, Star s)
        {
            //add player collision
            foreach (IPlayer p in assets.GetPlayerList())
            {
                PlayerStarDictionaryBuilder.AddPlayerStarCollision(collisionMap, p, s);
            }

            //add object collision
            foreach (IObject o in assets.GetObjectList())
            {
                ItemBlockDictionaryBuilder.AddItemBlockCollision(collisionMap, s, o);
            }

        }
    }
}
