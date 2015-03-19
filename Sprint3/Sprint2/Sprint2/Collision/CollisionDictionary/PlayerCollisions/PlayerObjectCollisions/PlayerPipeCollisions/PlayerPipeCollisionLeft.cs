using Microsoft.Xna.Framework;
using Sprint2.Objects;
using Sprint2.Objects.Pipes;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerCollisions.PlayerObjectCollisions.PlayerPipeCollisions
{
    class PlayerPipeCollisionLeft : ICollision
    {
        IPlayer player;
        Pipe pipe;
        public PlayerPipeCollisionLeft(IPlayer p, Pipe o)
        {
            player = p;
            pipe = o;
        }
        public void ExecuteCommand()
        {
            CollisionType ct = new CollisionType();
            Rectangle pRec = player.GetRectangle();
            Rectangle objRec = pipe.GetRectangle();
            Rectangle objRec2 = new Rectangle(objRec.X, objRec.Y + objRec.Height - 5, 1, 5);
            Rectangle r = Rectangle.Intersect(pRec, objRec2);
            if (pipe.CanEnterFromLeft() && (r.Width * r.Height >=5))
            {
                pipe.PlayerEnters(player);
            }
            objRec = pipe.GetRectangle();
            CollisionType.Collision c = ct.GetCollisionType(pRec, objRec);
            while(!c.Equals(CollisionType.Collision.none))
            {
                player.ShiftLeft();
                pRec = player.GetRectangle();
                objRec = pipe.GetRectangle();
                c = ct.GetCollisionType(pRec, objRec);
            }
        }
    }
}
