using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Sprint2.Commands
{
    class QuitCommand : ICommand
    {

        Game1 game1;
        public QuitCommand(Game1 game)
        {
            game1 = game;
        }

        public void ExecuteCommand()
        {
            game1.Exit();
        }
    }

}
