using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.Objects.Items;
using Sprint2.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerItemCollisions
{
    class PlayerMushroomCollision : ICollision
    {
        IPlayer player;
        IItem mushroom;
        RemoveElementList toRemove = new RemoveElementList();
        public PlayerMushroomCollision(IPlayer p, IItem m)
        {
            player = p;
            mushroom = m;
        }

        public void ExecuteCommand()
        {
            player.Mushroom();
            player.AddScore(1000);
            Console.WriteLine("Player got a Mushroom");
            toRemove.Add(mushroom);
        }
    }
}
