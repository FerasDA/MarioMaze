using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;
using Sprint2.Commands;
using Sprint2.LevelData;
using Sprint2.Player;
using Sprint2.GameState;

namespace Sprint2.Controllers
{
    class GamePadController : IController
    {
        private Game1 theGame;
        private LevelAssets levelAssets;
        private IPlayer player1;
        private Dictionary<GamePadButtons, ICommand> buttonMap;
        private StateController stateConroller;

        public GamePadController(Game1 game, LevelAssets assets, StateController sc)
        {
            theGame = game;
            // Associate button presses to commands
            buttonMap = new Dictionary<GamePadButtons, ICommand>();
            // button mapping dictionary to be added when needed
            levelAssets = assets;
            stateConroller = sc;

            ArrayList pList = assets.GetPlayerList();
            player1 = pList[0] as IPlayer;
        }

        public void Update()
        {
            ICommand toExecute;

            // Get Y position of thumbstick and move in that direction
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0 && stateConroller.PlayerControlledState())
            {
                toExecute = new JumpCommand(player1);

                toExecute.ExecuteCommand();
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && stateConroller.PlayerControlledState())
            {
                toExecute = new JumpCommand(player1);

                toExecute.ExecuteCommand();
            }
            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0 && stateConroller.PlayerControlledState())
            {
                toExecute = new CrouchCommand(player1);

                toExecute.ExecuteCommand();
            }

            // Get X position of thumbstick and move in that direction
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0 && stateConroller.PlayerControlledState())
            {
                toExecute = new TurnRightCommand(player1);

                toExecute.ExecuteCommand();
            }
            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0 && stateConroller.PlayerControlledState())
            {
                toExecute = new TurnLeftCommand(player1);

                toExecute.ExecuteCommand();
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed && stateConroller.PlayerControlledState())
            {
                toExecute = new AttackCommand(player1);

                toExecute.ExecuteCommand();
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
            {
                toExecute = new PauseCommand();

                toExecute.ExecuteCommand();
            }
        }
    }
}
