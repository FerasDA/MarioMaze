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
    class PlayerFireFlowerCollision:ICollision
    {
        IPlayer player;
        IItem fireflower;
        RemoveElementList toRemove = new RemoveElementList();
        public PlayerFireFlowerCollision(IPlayer p, IItem f)
        {
            player = p;
            fireflower = f;
        }

        public void ExecuteCommand()
        {
            player.Fire();
            player.AddScore(1000);
            Console.WriteLine("Player got a FireFlower");
            toRemove.Add(fireflower);
        }
    }
}
