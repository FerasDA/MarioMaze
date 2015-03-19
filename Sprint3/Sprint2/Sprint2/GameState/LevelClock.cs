using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.GameState
{
    class LevelClock
    {
        static int SecondsTillDeath;
        static int ticksThisSecond = 0;
        static bool clockPaused = false;
        static bool levelVictory = false;
        public LevelClock(int s){
            SecondsTillDeath = s;
            levelVictory = false;
        }
        public LevelClock() { }

        public void Update()
        {
            if(!clockPaused && !levelVictory)
                ticksThisSecond++;
            if(ticksThisSecond >= 60)
            {
                SecondsTillDeath--;
                ticksThisSecond = 0;
            }
        }

        public int GetTime()
        {
            return SecondsTillDeath;
        }

        public void Pause() 
        {
            clockPaused = !clockPaused;
        }

        public void LevelVictory()
        {
            levelVictory = true;
        }

        public void DecreaseOneSecond()
        {
            SecondsTillDeath--;
        }
    }
}
