using Sprint2.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Commands.CharacterSelectCommands
{
    class CharSelectRightCommand : ICommand 
    {
        CharacterSelect cs;
        public CharSelectRightCommand()
        {
            cs = new CharacterSelect();
        }
        public void ExecuteCommand()
        {
            cs.Right();
        }
    }
}
