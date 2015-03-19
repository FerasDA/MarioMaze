using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint2.Player;

namespace Sprint2.Commands
{
    class JumpCommand : ICommand
    {
        IPlayer player;
        public JumpCommand(IPlayer p)
        {
            player = p;
        }
        public void ExecuteCommand()
        {
            if (player != null)
                player.Jump();
        }
    }
}

