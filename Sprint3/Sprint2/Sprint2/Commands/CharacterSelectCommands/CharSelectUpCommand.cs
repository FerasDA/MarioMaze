using Sprint2.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Commands.CharacterSelectCommands
{
    class CharSelectUpCommand : ICommand
    {
        CharacterSelect cs;
        public CharSelectUpCommand()
        {
            cs = new CharacterSelect();
        }
        public void ExecuteCommand()
        {
            cs.Up();
        }
    }
}
