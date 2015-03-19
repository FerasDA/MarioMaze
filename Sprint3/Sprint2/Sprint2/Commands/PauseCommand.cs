using Sprint2.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Commands
{
    class PauseCommand: ICommand
    {
        GamePause gp = new GamePause();
        public PauseCommand()
        {}

        public void ExecuteCommand()
        {
            gp.Pause();
        }
   }
}
