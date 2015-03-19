using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.BackgroundItems;
using Sprint2.HUD;
using Sprint2.LevelData;
using Sprint2.Player;
using Sprint2.Player.MarioState;
using Sprint2.Player.MegamanState;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.GameState
{
    class CharacterSelect
    {
        static int maxPlayers = 1;
        static int playerSelectionIndex = 0;
        static bool CharacterSelected = false;
        static int SelectionLocation =0;
        static IPlayer selectedChar;
        static IPlayer currenctChar;
        static LevelAssets assets;
        static ArrayList playableCharacters;
        static ArrayList playableCharactersNames;
        static ArrayList background;
        static HUDCharacterSelect hud;
        static int screenWidth = 800;

        static bool wasPressingLeft;
        static bool isPressingLeft;
        static bool wasPressingRight;
        static bool isPressingRight;


        public CharacterSelect(LevelAssets la)
        {
            assets = la;
            playableCharacters = new ArrayList();
            playableCharactersNames = new ArrayList();

            background = new ArrayList();
            background.Add(new Black(la.GetObjectTexutre(), 0, 0));
            
            //adding playable characters to playablechar list
            int numberOfPlayableCharacter = 3;
            int charOffset = screenWidth/(numberOfPlayableCharacter + 1);

            playableCharacters.Add(new Mario(la.GetMarioTexture(), charOffset *(playableCharacters.Count +1), 300, new smallRightFacingIdle()));
            playableCharactersNames.Add("Mario");
            playableCharacters.Add(new Mario(la.GetLuigiTexture(), charOffset * (playableCharacters.Count + 1), 300, new smallRightFacingIdle()));
            playableCharactersNames.Add("Luigi");
            playableCharacters.Add(new Megaman(la.GetMegamanTexture(), charOffset * (playableCharacters.Count + 1), 300, new RightIdle()));
            playableCharactersNames.Add("Megaman");

            currenctChar = playableCharacters[0] as IPlayer;

            hud = new HUDCharacterSelect(la.GetFont());
        }

        public CharacterSelect(){}

        private void SelectedCharacter()
        {
            Mario m = selectedChar as Mario;
            if (m != null)
            {
                IPlayer p = (IPlayer)(assets.GetPlayerList())[playerSelectionIndex];
                assets.GetPlayerList().RemoveAt(playerSelectionIndex);
                m.SetXYPos(p.GetRectangle().X,p.GetRectangle().Y);
                assets.GetPlayerList().Insert(playerSelectionIndex,m);
                Console.WriteLine("Selected Chacater");
            }
            Megaman mega = selectedChar as Megaman;
            if (mega != null)
            {
                IPlayer p = (IPlayer)(assets.GetPlayerList())[playerSelectionIndex];
                assets.GetPlayerList().RemoveAt(playerSelectionIndex);
                mega.SetXYPos(p.GetRectangle().X, p.GetRectangle().Y);
                assets.GetPlayerList().Insert(playerSelectionIndex, mega);
                Console.WriteLine("Selected Chacater");
            }
        }
        public bool InChracterSelection()
        {
            return !CharacterSelected;
        }

        public void Up() { }
        public void Down() { }
        public void Left() {
            isPressingLeft = true;
            if (SelectionLocation - 1 >= 0 && !wasPressingLeft)
                SelectionLocation--;
            currenctChar = playableCharacters[SelectionLocation] as IPlayer;
        }
        public void Right() {
            isPressingRight = true;
            if (SelectionLocation + 1 <= playableCharacters.Count - 1 && !wasPressingRight)
                SelectionLocation++;
            currenctChar = playableCharacters[SelectionLocation] as IPlayer;
        }
        public void Select() {
            selectedChar = currenctChar;
            SelectedCharacter();
            playerSelectionIndex++;

            CharacterSelected = playerSelectionIndex >= maxPlayers;
            if (CharacterSelected)
                assets.Reset();
        }

        public void Update() 
        {
            wasPressingLeft = isPressingLeft;
            wasPressingRight = isPressingRight;
            isPressingLeft = false;
            isPressingRight = false;
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (IBackground b in background)
                b.Draw(sb);

            foreach (IPlayer p in playableCharacters)
                p.Draw(sb);

            hud.Draw(sb, playableCharactersNames[SelectionLocation] as String);
        }

        internal void Reset()
        {
            CharacterSelected = false;
            playerSelectionIndex = 0;
            maxPlayers = 1;
            SelectionLocation = 0;
        }
    }

}
