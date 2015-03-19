using Sprint2.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Commands.CharacterSelectCommands
{
    class CharSelectLeftCommand :ICommand 
    {
        CharacterSelect cs;
        public CharSelectLeftCommand()
        {
            cs = new CharacterSelect();
        }
        public void ExecuteCommand()
        {
            cs.Left();
        }
    }
}
