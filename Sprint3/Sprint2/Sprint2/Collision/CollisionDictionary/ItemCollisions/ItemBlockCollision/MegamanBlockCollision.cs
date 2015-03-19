using Sprint2.Objects.MegmanBullet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemBlockCollision
{
    class MegamanBlockCollision : ICollision
    {
         MegamanBullet megamanBullet;

         public MegamanBlockCollision(MegamanBullet mmb)
        {
            megamanBullet = mmb;
        }
        public void ExecuteCommand()
        {
            megamanBullet.Collision();
        }
    }
}
