using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.GameState;
using Sprint2.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.HUD
{
    class HUDController
    {
        SpriteFont font;
        LevelClock clock = new LevelClock();
        String worldName ="";

        public HUDController(SpriteFont sf)
        {
            font = sf;
        }
        public void Update(){

        }
        public void Draw(SpriteBatch spriteBatch, ArrayList playerStats)
        {

            PlayerStats ps = playerStats[0] as PlayerStats;
            Vector2 ScorePos = new Vector2( 0f, 0f);
            String scoreOuput = "SCORE: " + ps.GetScore();
            spriteBatch.DrawString(font, scoreOuput, ScorePos, Color.White);

            String CoinCountOuput = "COINS: " + ps.GetCoinCount();
            Vector2 CoinCountPos = new Vector2((float)(160), 0f);
            spriteBatch.DrawString(font, CoinCountOuput, CoinCountPos, Color.White);

            String LevelNameOuput = "WORLD: " + worldName;
            Vector2 LevelNamePos = new Vector2((float)(480 - font.MeasureString(LevelNameOuput).X), 0f);
            spriteBatch.DrawString(font, LevelNameOuput, LevelNamePos, Color.White);

            int livesLeft = ps.GetLivesLeft();
            livesLeft = (livesLeft > 0 ? livesLeft : 0);
            String LivesLeftOuput = "LIVES: " + livesLeft;
            Vector2 LivesLeftPos = new Vector2((float)(640 - font.MeasureString(LivesLeftOuput).X), 0f);
            spriteBatch.DrawString(font, LivesLeftOuput, LivesLeftPos, Color.White);

            String ClockOuput = clock.GetTime().ToString();
            Vector2 ClockPos = new Vector2((float)(800 - font.MeasureString(ClockOuput).X), 0f);
            spriteBatch.DrawString(font, ClockOuput, ClockPos, Color.White);
        }

        internal void SetLevelName(string p)
        {
            worldName = p;
        }
    }
}
