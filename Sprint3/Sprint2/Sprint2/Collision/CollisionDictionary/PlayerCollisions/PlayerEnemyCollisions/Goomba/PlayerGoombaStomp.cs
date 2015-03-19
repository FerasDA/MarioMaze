using Sprint2.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.Goomba
{
    class PlayerGoombaStomp : ICollision
    {
        IPlayer player;
        IEnemy goomba;
        Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastCollisions;
        public PlayerGoombaStomp(IPlayer p, IEnemy g, Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastCollisions)
        {
            player = p;
            goomba = g;
            this.pastCollisions = pastCollisions;
        }

        public void ExecuteCommand()
        {
            Tuple<IPlayer, IEnemy> key = Tuple.Create<IPlayer, IEnemy>(player, goomba);

            if (pastCollisions.ContainsKey(key))
            {
                if ((pastCollisions[key].Equals(CollisionType.Collision.none) || player.IsStar()) && !(goomba.ToString().Equals("Dead")))
                {
                    goomba.Damage();
                    player.Bounce();
                    player.AddScore(100);
                }
                else
                    if (!goomba.ToString().Equals("Dead"))
                        player.Damaged();
            }
            else if (!goomba.ToString().Equals("Dead"))
            {
                goomba.Damage();
                player.AddScore(100);
                player.Bounce();
            }
        }
    }
}
