using Microsoft.Xna.Framework;
using Sprint2.Objects;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerCollisions.PlayerObjectCollisions.PlayerPipeCollisions
{
    class PlayerPipeCollisionBottom : ICollision
    {
        IPlayer player;
        IObject pipe;

        public PlayerPipeCollisionBottom(IPlayer p, IObject o)
        {
            player = p;
            pipe = o;
        }
        public void ExecuteCommand()
        {
            CollisionType ct = new CollisionType();
            Rectangle pRec = player.GetRectangle();
            Rectangle objRec = pipe.GetRectangle();
            CollisionType.Collision c = ct.GetCollisionType(pRec, objRec);
            while(!c.Equals(CollisionType.Collision.none))
            {
                player.ShiftUp();
                pRec = player.GetRectangle();
                objRec = pipe.GetRectangle();
                c = ct.GetCollisionType(pRec, objRec);
            }
        }
    }
}
