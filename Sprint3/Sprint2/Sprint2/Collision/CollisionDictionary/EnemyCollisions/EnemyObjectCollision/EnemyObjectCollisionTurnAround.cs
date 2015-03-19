using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.EnemyCollisions.EnemyObjectCollision
{
    class EnemyObjectCollisionTurnAround : ICollision
    {
        IEnemy enemy;
        public EnemyObjectCollisionTurnAround(IEnemy e)
        {
            enemy = e;
        }
        public void ExecuteCommand()
        {
            enemy.TurnAround();
        }
    }
}
