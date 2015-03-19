using Sprint2.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Commands.CharacterSelectCommands
{
    class CharSelectSelectCommand : ICommand
    {
        CharacterSelect cs;
        public CharSelectSelectCommand()
        {
            cs = new CharacterSelect();
        }
        public void ExecuteCommand()
        {
            if(cs.InChracterSelection())
            cs.Select();
        }
    }
}
