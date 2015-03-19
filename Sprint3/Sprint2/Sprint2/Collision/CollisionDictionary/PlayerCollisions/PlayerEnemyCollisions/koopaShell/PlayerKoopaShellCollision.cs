using Microsoft.Xna.Framework;
using Sprint2.Enemies;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.koopaShell
{
    class PlayerKoopaShellCollision : ICollision
    {
        IPlayer player;
        KoopaShell koopaShell;
        Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastCollisions;

        public PlayerKoopaShellCollision(IPlayer p, IEnemy k, Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastCollisions)
        {
            player = p;
            koopaShell = k as KoopaShell;
            this.pastCollisions = pastCollisions;
        }
        public void ExecuteCommand()
        {
            Tuple<IPlayer, IEnemy> key = Tuple.Create<IPlayer, IEnemy>(player, koopaShell);
            if (player.IsStar())
                koopaShell.Killed(CollisionType.Collision.none, player);
            else if (pastCollisions.ContainsKey(key) && pastCollisions[key].Equals(CollisionType.Collision.none))
            {
                if (koopaShell.IsMoving())
                    player.Damaged();
                else
                {
                    CollisionType ct = new CollisionType();
                    Rectangle pRec = player.GetRectangle();
                    Rectangle enemyRec = koopaShell.GetRectangle();
                    CollisionType.Collision c = ct.GetCollisionSide(pRec, enemyRec);
                    if (!c.Equals(Collision.CollisionType.Collision.none))
                    {
                        koopaShell.Kick(c, player);
                        player.AddScore(500);
                    }
                }
            }
        }
    }
}
