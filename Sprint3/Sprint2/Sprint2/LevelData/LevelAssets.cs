using DataTypes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Sprint2.BackgroundItems;
using Sprint2.Collision;
using Sprint2.Controllers;
using Sprint2.GameState;
using Sprint2.Objects;
using Sprint2.Objects.Items;
using Sprint2.Player;
using Sprint2.XML;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Cameras;
using Sprint2.HUD;
using Sprint2.Sound;

namespace Sprint2.LevelData
{
    public class LevelAssets
    {
        static Game1 game;

        static Levels level1;

        static ArrayList ControllerList;

        static Texture2D ObjectTexture;
        static Texture2D enemiesTexture;
        static Texture2D marioTexture;
        static Texture2D luigiTexture;
        static Texture2D megamanTexture;
        static Texture2D backgroundTexture;

        static SpriteFont font;
        static HUDController HUD;

        static ArrayList BackgroundList;
        static ArrayList EnemyList;
        static ArrayList ItemList;
        static ArrayList PlayerList;
        static ArrayList PlayerStats;
        static ArrayList ObjectsList;

        static CollisionDictionaryTester CDT;

        static SoundController soundController = new SoundController();
        static InitializeLevel1 item1;
        static NextLevelLoader nextLevelLoader;

        StateController sc;

        static Camera camera;
        public LevelAssets() { }

        public void Initialize()
        {

            item1 = new InitializeLevel1();
            BackgroundList = new ArrayList();
            ObjectsList = new ArrayList();
            EnemyList = new ArrayList();
            ItemList = new ArrayList();
            PlayerList = new ArrayList();
            PlayerStats = new ArrayList();
            PlayerList.Clear();

            item1.PopulateLevelAssets(this);

            populatePlayerStatsList();
            linkPlayerStatsWithPlayers();

            soundController.PlaySong();

            sc = new StateController(this, game);
            CharacterSelect cs = new CharacterSelect();
            cs.Reset();

            ControllerList = new ArrayList();
            ControllerList.Add(new KeyboardController(game , this, sc));
            ControllerList.Add(new GamePadController(game, this, sc));

            CDT = new CollisionDictionaryTester();
            CDT.SetLevelInfo(this);
            CDT.BuildDictionary();

            camera = new Camera();
            camera.Reset();
            HUD = new HUDController(font);


        }

        private void populatePlayerStatsList()
        {
            foreach(IPlayer p in PlayerList)
            {
                PlayerStats.Add(new PlayerStats());
            }
        }

        private void linkPlayerStatsWithPlayers()
        {
            for (int i = 0; i< PlayerList.Count;i++)
            {
                IPlayer p = PlayerList[i] as IPlayer;
                PlayerStats ps = PlayerStats[i] as PlayerStats;
                p.SetPlayerStats(ps);
            }
        }

        public void Reset()
        {
            item1 = new InitializeLevel1();
            BackgroundList.Clear();
            ObjectsList.Clear();
            EnemyList.Clear();
            ItemList.Clear();
            //PlayerList.Clear();

            item1.PopulateLevelAssets(this);

            linkPlayerStatsWithPlayers();

            //soundController.PlaySong();

            sc = new StateController(this, game);

            ControllerList = new ArrayList();
            ControllerList.Add(new KeyboardController(game, this, sc));
            ControllerList.Add(new GamePadController(game, this, sc));

            CDT = new CollisionDictionaryTester();
            CDT.SetLevelInfo(this);
            CDT.BuildDictionary();

            camera.Reset();
            HUD.SetLevelName(level1.currentLevel.levelName);
        }

        public void Update()
        {
            foreach (IController controller in ControllerList)
            {
                controller.Update();
            }
            if (!sc.InCharacterSelect())
            {
                foreach (IController controller in ControllerList)
                {
                    controller.Update();
                }
                if (!sc.InTransitionsState() && !sc.InPauseState())
                {
                    foreach (IPlayer player in PlayerList)
                    {
                        player.Update();
                    }

                    foreach (IEnemy enemy in EnemyList)
                    {
                        if (camera.InsideCamraUpdateBounds(enemy.GetRectangle()))
                            enemy.update();
                    }

                    foreach (IObject levelObject in ObjectsList)
                    {
                        levelObject.Update();
                    }

                    foreach (IItem item in ItemList)
                    {
                        if (camera.InsideCamraUpdateBounds(item.GetRectangle()))
                            item.Update();
                    }

                    CDT.Update();
                }

                camera.Update(PlayerList);
                
            }
            sc.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (sc.InCharacterSelect())
                sc.Draw(spriteBatch);
            else
            {
                foreach (IBackground item in BackgroundList)
                {
                    item.Draw(spriteBatch);
                }
                if (sc.PlayerControlledState())
                {
                    foreach (IPlayer player in PlayerList)
                    {
                        player.Draw(spriteBatch);
                    }
                }
                else
                {
                    sc.Draw(spriteBatch);
                }

                foreach (IEnemy enemy in EnemyList)
                {
                    enemy.Draw(spriteBatch);
                }
                foreach (IObject block in ObjectsList)
                {
                    block.Draw(spriteBatch);
                }
                foreach (IItem item in ItemList)
                {
                    item.Draw(spriteBatch);
                }

                HUD.Draw(spriteBatch, PlayerStats);
            }
        }

        public void SetLevel1(DataTypes.Levels levels)
        {
            level1 = levels;
        }

        public Levels GetLevel()
        {
            return level1;
        }

        public void SetObjectTexture(Texture2D texture2D)
        {
            ObjectTexture = texture2D;
        }

        public Texture2D GetObjectTexutre()
        {
            return ObjectTexture;
        }

        public void SetEnemiesTexture(Texture2D texture2D)
        {
            enemiesTexture = texture2D;
        }

        public Texture2D GetEnemiesTexture()
        {
            return enemiesTexture;
        }

        public void SetMarioTexture(Texture2D texture2D)
        {
            marioTexture = texture2D;
        }

        public Texture2D GetMarioTexture()
        {
            return marioTexture;
        }

        public void SetBackGroundTextures(Texture2D texture2D)
        {
            backgroundTexture = texture2D;
        }

        public Texture2D GetBackGroundTexture()
        {
            return backgroundTexture;
        }

        public void SetGame(Game1 game1)
        {
            game = game1;
        }

        internal ArrayList GetItemList()
        {
            return ItemList;
        }

        internal ArrayList GetObjectList()
        {
            return ObjectsList;
        }

        internal ArrayList GetBackGroundList()
        {
            return BackgroundList;
        }

        internal ArrayList GetEnemyList()
        {
            return EnemyList;
        }

        internal ArrayList GetPlayerList()
        {
            return PlayerList;
        }

        internal void SetFont(SpriteFont spriteFont)
        {
            font = spriteFont;
        }

        public SpriteFont GetFont()
        {
            return font;
        }

        internal ArrayList GetPlayerStats()
        {
            return PlayerStats;
        }

        public void SetLuigiTexture(Texture2D texture2D)
        {
            luigiTexture = texture2D;
        }

        public Texture2D GetLuigiTexture()
        {
            return luigiTexture;
        }

        internal void SetMegamanTexture(Texture2D texture2D)
        {
            megamanTexture = texture2D;
        }

        internal Texture2D GetMegamanTexture()
        {
            return megamanTexture;
        }

        internal void SetNextLevelLoader(NextLevelLoader nll)
        {
            nextLevelLoader = nll;
        }

        public void LoadNextLevel()
        {
            nextLevelLoader.LoadNextLevel();
        }
    }
}
