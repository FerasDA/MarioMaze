using Sprint2.HUD;
using Sprint2.LevelData;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.GameState
{
    class PlayerFlagpoleState
    {
        static bool inTransition = false;
        static IPlayer player;
        static int transitionCoolDown = 0;
        LevelAssets assets;
        LevelClock clock = new LevelClock();
        public PlayerFlagpoleState(LevelAssets a){
        assets = a;
        }
        public PlayerFlagpoleState(IPlayer m)
        {
            clock.LevelVictory();
            inTransition = true;
            player = m;
            transitionCoolDown = 160;
        }

        public void Update()
        {
            if(inTransition)
            {
                if(transitionCoolDown > 70)
                { }
                else if(transitionCoolDown > 10)
                {
                    player.Right();
                    if (clock.GetTime() > 0)
                    {
                        player.AddScore(50);
                        clock.DecreaseOneSecond();
                    }
                }
                else
                {
                    if (clock.GetTime() > 0)
                    {
                        player.AddScore(50);
                        clock.DecreaseOneSecond();
                    }
                }
                if(transitionCoolDown>10 || clock.GetTime() <= 0)
                    transitionCoolDown--;
                if (transitionCoolDown < 0)
                {
                    inTransition = false;
                    assets.LoadNextLevel();
                }
            }

        }

        public bool InTransistion()
        {
            return inTransition;
        }

        public IPlayer PlayerInTransition()
        {
            return player;
        }
    }
}
