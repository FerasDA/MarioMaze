using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerEnemyCollisions.Goomba
{
    class PlayerGoombaCollision : ICollision
    {
        IPlayer player;
        IEnemy goomba;

        public PlayerGoombaCollision(IPlayer p, IEnemy g)
        {
            player = p;
            goomba = g;
        }
        public void ExecuteCommand()
        {
            if (player.IsStar())
            {
                goomba.Killed(CollisionType.Collision.none, player);
            }
            else
                if (!goomba.ToString().Equals("Dead"))
                    player.Damaged();
        }
    }
}
