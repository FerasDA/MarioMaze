using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint2.Objects;
using Sprint2.Objects.Blocks;

namespace Sprint2.Commands
{
    class UsedCommand : ICommand
    {
        Game1 game1;
        public UsedCommand(Game1 game)
        {
            game1 = game;
        }
        public void ExecuteCommand()
        {
           // ((IBlock)game1.BlockList[0]).UsedBlock();
        }
    }
}