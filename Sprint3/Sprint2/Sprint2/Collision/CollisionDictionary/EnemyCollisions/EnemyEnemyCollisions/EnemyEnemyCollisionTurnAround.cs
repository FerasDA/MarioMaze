using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.EnemyCollisions.EnemyEnemyCollisions
{
    class EnemyEnemyCollisionTurnAround : ICollision
    {
        IEnemy enemy;
        public EnemyEnemyCollisionTurnAround(IEnemy e)
        {
            enemy = e;
        }
        public void ExecuteCommand()
        {
            enemy.TurnAround();
        }
    }
}
