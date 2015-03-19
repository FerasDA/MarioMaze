using Microsoft.Xna.Framework;
using Sprint2.Objects;
using Sprint2.Objects.Blocks;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerBlockCollisions
{
    class PlayerBlockCollisionBottom : ICollision
    {
        IPlayer player;
        Block block;

        public PlayerBlockCollisionBottom(IPlayer p, IObject o)
        {
            player = p;
            block = o as Block;
        }
        public void ExecuteCommand()
        {
            block.Collision(player);
            CollisionType ct = new CollisionType();
            Rectangle pRec = player.GetRectangle();
            Rectangle objRec = block.GetRectangle();
            CollisionType.Collision c = ct.GetCollisionType(pRec, objRec);
            while(!c.Equals(CollisionType.Collision.none))
            {
                player.ShiftDown();
                pRec = player.GetRectangle();
                objRec = block.GetRectangle();
                c = ct.GetCollisionType(pRec, objRec);
            }
        }
    }
}
