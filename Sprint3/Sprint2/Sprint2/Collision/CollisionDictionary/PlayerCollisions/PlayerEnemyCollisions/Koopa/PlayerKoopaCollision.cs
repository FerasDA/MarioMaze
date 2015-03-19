using Sprint2.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.Koopa
{
    class PlayerKoopaCollision : ICollision 
    {
        IPlayer player;
        IEnemy koopa;

        public PlayerKoopaCollision(IPlayer p, IEnemy k, ArrayList modifiedElements)
        {
            player = p;
            koopa = k;
        }
        public void ExecuteCommand()
        {
            if (player.IsStar())
            {
                koopa.Killed(CollisionType.Collision.none, player);
            }
            else
                player.Damaged();
        }
    }
}
