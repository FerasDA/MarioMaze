using Sprint2.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.Koopa
{
    class PlayerKoopaStomp : ICollision
    {
        IPlayer player;
        IEnemy koopa;
        Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastCollisions;
        ArrayList modifiedElements;
        public PlayerKoopaStomp(IPlayer p, IEnemy k, Dictionary<Tuple<IPlayer, IEnemy>, CollisionType.Collision> pastCollisions, ArrayList modifiedElements)
        {
            player = p;
            koopa = k;
            this.pastCollisions = pastCollisions;
            this.modifiedElements = modifiedElements;
        }

        public void ExecuteCommand()
        {
            Tuple<IPlayer, IEnemy> key = Tuple.Create<IPlayer, IEnemy>(player, koopa);
            if (player.IsStar())
            {
                koopa.Killed(CollisionType.Collision.none, player);
            }
            else if (pastCollisions.ContainsKey(key))
            {
                if (pastCollisions[key].Equals(CollisionType.Collision.none) || player.IsStar())
                {
                    koopa.Damage();
                    player.AddScore(100);
                    player.Bounce();
                    modifiedElements.Add(koopa);
                }
                else
                    player.Damaged();
            }
            else
            {
                koopa.Damage();
                player.AddScore(100);
                player.Bounce();
            }
        }
    }
}
