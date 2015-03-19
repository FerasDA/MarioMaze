using Microsoft.Xna.Framework;
using Sprint2.Enemies;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.koopaShell
{
    class PlayerKoopaShellStomp : ICollision
    {
        IPlayer player;
        KoopaShell koopa;
        Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastCollisions;
        public PlayerKoopaShellStomp(IPlayer p, KoopaShell k, Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastCollisions)
        {
            player = p;
            koopa = k;
            this.pastCollisions = pastCollisions;
        }

        public void ExecuteCommand()
        {
            Tuple<IPlayer, IEnemy> key = Tuple.Create<IPlayer, IEnemy>(player, koopa);
            if (player.IsStar())
                koopa.Killed(CollisionType.Collision.none, player);
            else if (pastCollisions.ContainsKey(key))
            {
                if (pastCollisions[key].Equals(CollisionType.Collision.none))
                {
                    if (koopa.IsMoving())
                    {
                        koopa.Stomp();
                        player.Bounce();
                    }
                    else
                    {
                        CollisionType ct = new CollisionType();
                        Rectangle pRec = player.GetRectangle();
                        Rectangle enemyRec = koopa.GetRectangle();
                        CollisionType.Collision c = ct.GetCollisionSide(pRec, enemyRec);
                        if (!c.Equals(Collision.CollisionType.Collision.none))
                        {
                            koopa.Kick(c, player);
                            player.AddScore(500);
                        }
                    }
                }
            }
        }
    }
}
