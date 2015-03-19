using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint2.Objects.Blocks;
using Sprint2.Objects;

namespace Sprint2.Commands
{
    class QuestionCommand : ICommand
    {
        Game1 game1;
        public QuestionCommand(Game1 game)
        {
            game1 = game;
        }
        public void ExecuteCommand()
        {
         //   ((IBlock)game1.BlockList[0]).QuestionBlock();
        }
    }
}