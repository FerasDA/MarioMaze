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
    class PosionMushroomCollisionAdder
    {
        public static void AddPosionMushroom(Dictionary<Tuple<object, object, CollisionType.Collision>, ICollision> collisionMap, LevelAssets assets, PoisonMushroom pm)
        {
            //add player collision
            foreach (IPlayer p in assets.GetPlayerList())
            {
                PlayerPoisonMushroomDictionaryBuilder.AddPlayerPoisonMushroomCollision(collisionMap, p, pm);
            }

            //add object collision
            foreach (IObject o in assets.GetObjectList())
            {
                ItemBlockDictionaryBuilder.AddItemBlockCollision(collisionMap, pm, o);
            }
        }
    }
}
