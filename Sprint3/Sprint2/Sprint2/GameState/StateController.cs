using Microsoft.Xna.Framework.Graphics;
using Sprint2.LevelData;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Cameras;
using System.Collections;

namespace Sprint2.GameState
{
    class StateController
    {
        LevelAssets assets;
        static Game1 game;
        PlayerStateTransitions pst;
        PlayerPipeTransition ppt;
        PlayerFlagpoleState pfs;
        AllPlayerDead apd;
        int restartCounter = 180;
        Camera camera = new Camera();
        GamePause gp = new GamePause();
        LevelClock clock;
        ArrayList playerstats;
        CharacterSelect cs;
        public StateController(LevelAssets a, Game1 g)
        {
            assets = a;
            game = g;
            apd = new AllPlayerDead(a);
            pst = new PlayerStateTransitions(a);
            ppt = new PlayerPipeTransition(a);
            pfs = new PlayerFlagpoleState(a);
            gp.Reset();
            clock = new LevelClock(300);
            cs = new CharacterSelect(a);
        }

        public StateController() {}

        public void Update()
        {
            if (!gp.IsPaused())
            {
                cs.Update();
                pst.Update();
                ppt.Update();
                pfs.Update();
                if (apd.AllDead())
                {
                    restartCounter--;
                }
                if (restartCounter < 0)
                {
                    playerstats = assets.GetPlayerStats();
                    PlayerStats ps = playerstats[playerstats.Count - 1] as PlayerStats;
                    if (ps.GetLivesLeft() < 0)
                        game.Reset();
                    else
                        assets.Reset();
                }
                clock.Update();
            }
            gp.Update();
        }

        public bool InTransitionsState()
        {
            return pst.InTransistion() || ppt.InTransistion();
        }

        public void Draw(SpriteBatch sb)
        {
            if (cs.InChracterSelection())
                cs.Draw(sb);
            else
            {
                foreach (IPlayer p in assets.GetPlayerList())
                {
                    if (p == pst.PlayerInTransition() && pst.InTransistion())
                    {
                        pst.Draw(sb);
                    }
                    else if (p == ppt.PlayerInTransition() && ppt.InTransistion())
                    {
                        ppt.Draw(sb);
                    }
                    else
                        p.Draw(sb);
                }
            }
            
        }

        internal bool InPauseState()
        {
            return gp.IsPaused();
        }

        public bool InCharacterSelect()
        {
            return cs.InChracterSelection();
        }

        public bool PlayerControlledState()
        {
            return !(gp.IsPaused() || pst.InTransistion() || ppt.InTransistion() || pfs.InTransistion());
        }
    }
}
