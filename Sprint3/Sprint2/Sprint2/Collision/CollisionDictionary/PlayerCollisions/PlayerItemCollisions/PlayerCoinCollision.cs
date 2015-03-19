using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.Objects;
using Sprint2.Objects.Items;
using Sprint2.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerItemCollisions
{
    class PlayerCoinCollision : ICollision
    {
        IPlayer player;
        IItem coin;
        RemoveElementList toRemove = new RemoveElementList();
        public PlayerCoinCollision(IPlayer p, IItem c)
        {
            player = p;
            coin = c;      
        }

        public void ExecuteCommand()
        {
            coin.Collision(player);
            toRemove.Add(coin);
        }
    }
}
