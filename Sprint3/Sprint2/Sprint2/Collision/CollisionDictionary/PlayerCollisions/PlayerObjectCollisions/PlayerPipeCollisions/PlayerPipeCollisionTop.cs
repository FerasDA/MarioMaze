using Microsoft.Xna.Framework;
using Sprint2.Objects;
using Sprint2.Objects.Pipes;
using Sprint2.Objects.Pipes.PipeState;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerCollisions.PlayerObjectCollisions.PlayerPipeCollisions
{
    class PlayerPipeCollisionTop : ICollision
    {
        IPlayer player;
        Pipe pipe;

        public PlayerPipeCollisionTop(IPlayer p, Pipe o)
        {
            player = p;
            pipe = o;
        }
        public void ExecuteCommand()
        {
            CollisionType ct = new CollisionType();
            Rectangle pRec = player.GetRectangle();
            Rectangle objRec = pipe.GetRectangle();
            objRec = new Rectangle(objRec.X + objRec.Width / 2 - 5, objRec.Y - 1, 10, 1);
            Rectangle r = Rectangle.Intersect(pRec, objRec);
            CollisionType.Collision c = ct.GetCollisionType(pRec, objRec);
            if (pipe.CanEnterFromTop() && (r.Width * r.Height >= 10) && player.IsPressingDown())
            {
                pipe.PlayerEnters(player);
            }
            else{
                pRec = player.GetRectangle();
                objRec = pipe.GetRectangle();
                c = ct.GetCollisionType(pRec, objRec);
                while (!c.Equals(CollisionType.Collision.none))
                {
                    player.ShiftUp();
                    pRec = player.GetRectangle();
                    objRec = pipe.GetRectangle();
                    c = ct.GetCollisionType(pRec, objRec);
                }
            }
        }
    }
}
