using Sprint2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.GameState
{
    class GamePause
    {
        static bool paused = false;
        static bool wasPressingPause;
        static bool pressedPause;
        static SoundController sound = new SoundController();

        public GamePause() {}

        public void Update()
        {
            wasPressingPause = pressedPause;
            pressedPause = false;
        }
        public void Pause()
        {
            if (!wasPressingPause)
            {
                paused = !paused;
                sound.Pause();
            }
            pressedPause = true;
            wasPressingPause = true;
            
        }

        public bool IsPaused()
        {
            return paused;
        }

        public void Reset()
        {
            paused = false;
        }
    }
}
