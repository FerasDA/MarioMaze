using Microsoft.Xna.Framework;
using Sprint2.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.EnemyCollisions.EnemyObjectCollision
{
    class EnemyObjectCollisionTop : ICollision
    {
        IEnemy enemy;
        IObject block;

        public EnemyObjectCollisionTop(IEnemy e, IObject b)
        {
            enemy = e;
            block = b;
        }
        public void ExecuteCommand()
        {
            CollisionType ct = new CollisionType();
            Rectangle eRec = enemy.GetRectangle();
            Rectangle objRec = block.GetRectangle();
            CollisionType.Collision c = ct.GetCollisionType(eRec, objRec);
            while (!c.Equals(CollisionType.Collision.none))
            {
                enemy.ShiftUp();
                eRec = enemy.GetRectangle();
                objRec = block.GetRectangle();
                c = ct.GetCollisionType(eRec, objRec);
            }
        }
    }
}
