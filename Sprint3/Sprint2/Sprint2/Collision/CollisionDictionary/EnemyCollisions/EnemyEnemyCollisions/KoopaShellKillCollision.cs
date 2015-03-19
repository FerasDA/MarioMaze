using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.EnemyCollisions.EnemyEnemyCollisions
{
    class KoopaShellKillCollision : ICollision
    {
        IEnemy enemy;
        KoopaShell koopaShell;
        public KoopaShellKillCollision(IEnemy ks, IEnemy e)
        {
            enemy = e;
            koopaShell = ks as KoopaShell;
        }

        public void ExecuteCommand()
        {
            if (koopaShell.IsMoving())
            {
                CollisionType.Collision c = CollisionType.Collision.right;
                if (koopaShell.IsMovingRight())
                {
                    c = CollisionType.Collision.left;
                }
                enemy.Killed(c, koopaShell.KickedBy());
            }
        }
    }
}
