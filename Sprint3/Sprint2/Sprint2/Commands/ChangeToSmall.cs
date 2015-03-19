using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint2.Player;


namespace Sprint2.Commands
{
    class ChangeToSmall : ICommand
    {
        IPlayer player;
        public ChangeToSmall(IPlayer p)
        {
            player = p;
        }
        public void ExecuteCommand()
        {
            if (player != null)
            {
                player.Mushroom();
                player.Damaged();
            }
        }
    }
}
