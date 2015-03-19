using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint2.Player;

namespace Sprint2.Commands
{
    class ResetCommand : ICommand
    {
        Game1 game1;
        public ResetCommand(Game1 game)
        {
            game1 = game;
        }
        public void ExecuteCommand()
        {
            game1.Reset();
        }
    }
}