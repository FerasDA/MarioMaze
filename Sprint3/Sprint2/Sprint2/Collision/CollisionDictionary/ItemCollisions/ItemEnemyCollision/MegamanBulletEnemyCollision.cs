using Sprint2.Objects.MegmanBullet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemEnemyCollision
{
    class MegamanBulletEnemyCollision : ICollision
    {
        IEnemy enemy;
        MegamanBullet megamanBullet;

        public MegamanBulletEnemyCollision(MegamanBullet f, IEnemy e)
        {
            enemy = e;
            megamanBullet = f;
        }
        public void ExecuteCommand()
        {

            CollisionType.Collision c = CollisionType.Collision.right;
            if (megamanBullet.IsMovingRight())
                c = CollisionType.Collision.left;
            enemy.Killed(c, megamanBullet.ThrownByPlayer());
            megamanBullet.Collision();
        }
    }
}
