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
using Sprint2.Commands.CharacterSelectCommands;

namespace Sprint2.Controllers
{
    class KeyboardController : IController
    {
        private Game1 theGame;
        private LevelAssets levelAssets;
        private Dictionary<Keys, ICommand> keyMap;
        private Dictionary<Keys, ICommand> characterSelectkeyMap;
        private Dictionary<Keys, ICommand> currentMap;
        private StateController stateConroller;
        public KeyboardController(Game1 game, LevelAssets assets, StateController sc)
        {
            theGame = game;
            levelAssets = assets;
            stateConroller = sc;

            ArrayList pList = assets.GetPlayerList();
            IPlayer player1 = pList[0] as IPlayer;

            // Associate button presses to commands
            keyMap = new Dictionary<Keys, ICommand>();
            keyMap.Add(Keys.Q, new QuitCommand(theGame));
            keyMap.Add(Keys.R, new ResetCommand(theGame));
            keyMap.Add(Keys.W, new JumpCommand(player1));
            keyMap.Add(Keys.Up, new JumpCommand(player1));
            keyMap.Add(Keys.S, new CrouchCommand(player1));
            keyMap.Add(Keys.Down, new CrouchCommand(player1));
            keyMap.Add(Keys.A, new TurnLeftCommand(player1));
            keyMap.Add(Keys.Left, new TurnLeftCommand(player1));
            keyMap.Add(Keys.D, new TurnRightCommand(player1));
            keyMap.Add(Keys.Right, new TurnRightCommand(player1));
            keyMap.Add(Keys.B, new AttackCommand(player1));
            keyMap.Add(Keys.Escape, new PauseCommand());

            characterSelectkeyMap = new Dictionary<Keys, ICommand>();
            characterSelectkeyMap.Add(Keys.Q, new QuitCommand(theGame));
            characterSelectkeyMap.Add(Keys.Up, new CharSelectUpCommand());
            characterSelectkeyMap.Add(Keys.Down, new CharSelectDownCommand());
            characterSelectkeyMap.Add(Keys.Left, new CharSelectLeftCommand());
            characterSelectkeyMap.Add(Keys.Right, new CharSelectRightCommand());
            characterSelectkeyMap.Add(Keys.Enter, new CharSelectSelectCommand());
            characterSelectkeyMap.Add(Keys.Escape, new QuitCommand(theGame));

            currentMap = characterSelectkeyMap;
        }

        public void Update()
        {
            ICommand toExecute;
            Keys[] pressedkeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedkeys)
            {
                if (currentMap.ContainsKey(key) && (key.Equals(Keys.Escape) || stateConroller.PlayerControlledState()))
                {
                    {
                        toExecute = currentMap[key];
                        toExecute.ExecuteCommand();
                    }
                }
                //if (currentMap == characterSelectkeyMap && pressedkeys.Contains(Keys.Enter) && stateConroller.InCharacterSelect())
                //    currentMap = keyMap;
            }

            if (currentMap == characterSelectkeyMap && !stateConroller.InCharacterSelect())
                currentMap = keyMap;
        }
    }
}
