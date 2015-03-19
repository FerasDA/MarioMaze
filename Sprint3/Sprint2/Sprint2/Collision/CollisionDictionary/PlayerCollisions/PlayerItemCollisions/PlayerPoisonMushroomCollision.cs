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
    class PlayerPoisonMushroomCollision : ICollision
    {
        IPlayer player;
        IItem poisionMushroom;
        RemoveElementList toRemove = new RemoveElementList();
        public PlayerPoisonMushroomCollision(IPlayer p, IItem pm)
        {
            player = p;
            poisionMushroom = pm;
        }

        public void ExecuteCommand()
        {
            player.Damaged();
            Console.WriteLine("Player got a Poison Mushroom");
            toRemove.Add(poisionMushroom);
        }
    }
}
