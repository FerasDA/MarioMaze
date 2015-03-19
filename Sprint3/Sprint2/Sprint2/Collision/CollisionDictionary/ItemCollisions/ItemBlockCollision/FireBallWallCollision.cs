using Sprint2.Objects.FireBall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemBlockCollision
{
    class FireBallWallCollision : ICollision
    {        
        FireBall fireBall;

        public FireBallWallCollision(FireBall f)
        {
            fireBall = f;
        }
        public void ExecuteCommand()
        {
            fireBall.Collision();
        }
    }
}
