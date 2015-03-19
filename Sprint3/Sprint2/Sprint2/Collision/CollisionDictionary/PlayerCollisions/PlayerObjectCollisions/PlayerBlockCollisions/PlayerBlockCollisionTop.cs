using Microsoft.Xna.Framework;
using Sprint2.Objects;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerBlockCollisions
{
    class PlayerBlockCollisionTop : ICollision
    {
        IPlayer player;
        IObject block;

        public PlayerBlockCollisionTop (IPlayer p, IObject o)
        {
            player = p;
            block = o;
        }
        public void ExecuteCommand()
        {
            CollisionType ct = new CollisionType();
            Rectangle pRec = player.GetRectangle();
            Rectangle objRec = block.GetRectangle();
            CollisionType.Collision c = ct.GetCollisionType(pRec, objRec);
            while(!c.Equals(CollisionType.Collision.none))
            {
                player.ShiftUp();
                pRec = player.GetRectangle();
                objRec = block.GetRectangle();
                c = ct.GetCollisionType(pRec, objRec);
            }
        }
    }
}
