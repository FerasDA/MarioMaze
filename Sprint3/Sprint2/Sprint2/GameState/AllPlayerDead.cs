using Sprint2.LevelData;
using Sprint2.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.GameState
{
    class AllPlayerDead
    {
        ArrayList playerList;
        LevelClock clock = new LevelClock();
        public AllPlayerDead(LevelAssets assets)
        {
            playerList = assets.GetPlayerList();
        }

        public bool AllDead()
        {
            bool output = true;

            if (clock.GetTime() < 0)
            {
                foreach (IPlayer p in playerList)
                {
                    p.Death();
                }
            }

            foreach(IPlayer p in playerList)
            {
                if(!p.ToString().Equals("dead"))
                {
                    output = false;
                    break;
                }
            }
            if(!output && clock.GetTime() < 0)
                output = true;
            return output;
        }
    }
}
