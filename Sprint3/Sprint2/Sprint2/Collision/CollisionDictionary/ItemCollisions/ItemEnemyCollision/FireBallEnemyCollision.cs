using Microsoft.Xna.Framework;
using Sprint2.Objects.FireBall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemEnemyCollision
{
    class FireBallEnemyCollision : ICollision
    {
        IEnemy enemy;
        FireBall fireBall;

        public FireBallEnemyCollision(FireBall f, IEnemy e)
        {
            enemy = e;
            fireBall = f;
        }
        public void ExecuteCommand()
        {

            CollisionType.Collision c = CollisionType.Collision.right;
            if (fireBall.IsMovingRight())
                c = CollisionType.Collision.left;
            enemy.Killed(c, fireBall.ThrownByPlayer());
            fireBall.Collision();
        }
    }
}
