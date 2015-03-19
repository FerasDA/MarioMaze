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
    class PlayerStarCollision : ICollision
    {
        IPlayer player;
        IItem star;
        RemoveElementList toRemove = new RemoveElementList();
        public PlayerStarCollision(IPlayer p, IItem s)
        {
            player = p;
            star = s;
        }

        public void ExecuteCommand()
        {
            player.Star();
            player.AddScore(1000);
            Console.WriteLine("Player got a Star");
            toRemove.Add(star);
        }
    }
}
