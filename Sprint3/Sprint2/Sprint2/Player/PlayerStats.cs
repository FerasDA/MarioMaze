using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player
{
    class PlayerStats
    {
        int Score;
        int livesLeft;
        int CoinCount;

        public PlayerStats() 
        {
            Score = 0;
            livesLeft = 3;
            CoinCount = 0;
        }

        public void AddScore(int newPoints)
        {
            Score += newPoints;
        }

        public int GetScore()
        {
            return Score;
        }

        public void Died()
        {
            livesLeft--;
        }

        public int GetLivesLeft()
        {
            return livesLeft;
        }

        public void GetCoin()
        {
            CoinCount++;
        }

        public int GetCoinCount()
        {
            return CoinCount;
        }
    }
}
