using Sprint2.Objects.FireBall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.ItemCollisions.ItemBlockCollision
{
    class FireBallOutOfCameraCollison : ICollision
    {
        FireBall fireBall;
        public FireBallOutOfCameraCollison(FireBall f)
        {
            fireBall = f;
        }
        public void ExecuteCommand()
        {
            fireBall.Exit();
        }
    }
}
