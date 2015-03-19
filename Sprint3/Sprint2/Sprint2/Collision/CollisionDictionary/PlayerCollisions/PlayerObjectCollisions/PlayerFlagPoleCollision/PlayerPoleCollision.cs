using Sprint2.GameState;
using Sprint2.Objects;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.PlayerCollisions.PlayerObjectCollisions.PlayerFlagPoleCollision
{
    class PlayerPoleCollision : ICollision
    {
        IPlayer player;
        IObject pole;
        int poleSections = 20;
        int scoreMultiplyer= 100;

        public PlayerPoleCollision(IPlayer p, IObject o)
        {
            player = p;
            pole = o;
        }
        public void ExecuteCommand()
        {
            //scoreing
            double playerY = player.GetRectangle().Y;
            double playerHeigth = player.GetRectangle().Height;
            double poleY = pole.GetRectangle().Y;
            double poleHeight = pole.GetRectangle().Height;
            double percentOfPole = (poleHeight - playerY + poleY - playerHeigth) / (poleHeight-playerHeigth);
            int score = (int)((percentOfPole) * poleSections) + 1;
            score *= scoreMultiplyer;
            //player.AddScore(score);

            player.Flagpole(score);
            pole.Collision();
        }
    }
}
