using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint2.Player;

namespace Sprint2.Commands
{
    class ChangeToFire : ICommand
    {
        IPlayer player;
        public ChangeToFire(IPlayer p)
        {
            player = p;
        }
        public void ExecuteCommand()
        {
            if (player != null)
                player.Fire();
        }
    }
}