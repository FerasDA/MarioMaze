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
using Sprint2.Player;
using Sprint2.Enemies;
using Sprint2.Controllers;
using Sprint2.Objects;
using Sprint2.Objects.Blocks;
using Sprint2.Collision;
using Sprint2.Objects.Items;
using Sprint2.BackgroundItems;
using Sprint2.Objects.Blocks.BlockState;
using Sprint2.Objects.Pipes;
using DataTypes;
using Sprint2.XML;
using Sprint2.LevelData;
using Sprint2.Cameras;
using Sprint2.Sound;

namespace Sprint2
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        internal LevelAssets assets;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            assets.SetGame(this);
            assets.Initialize();
        }

        protected internal void Reset()
        {
            this.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            assets = new LevelAssets();
            SoundController sound = new SoundController();
            assets.SetNextLevelLoader(new NextLevelLoader(Content));
            sound.SetSong(Content.Load<Song>("Sound/Super Spice Bros 2"));
            sound.SetPause(Content.Load<SoundEffect>("Sound/smb_pause"));
            sound.SetPlayerDeath(Content.Load<SoundEffect>("Sound/smb_mariodie"));
            sound.SetJump(Content.Load<SoundEffect>("Sound/smb_jump"));
            sound.SetCoin(Content.Load<SoundEffect>("Sound/smb_coin"));
            sound.SetBump(Content.Load<SoundEffect>("Sound/smb_bump"));
            sound.SetFireBall(Content.Load<SoundEffect>("Sound/smb_fireball"));
            assets.SetLevel1(Content.Load<Levels>("LevelData1"));
            assets.SetObjectTexture(Content.Load<Texture2D>("objects1"));
            assets.SetEnemiesTexture(Content.Load<Texture2D>("enemies"));
            assets.SetMarioTexture(Content.Load<Texture2D>("marioSprites"));
            assets.SetLuigiTexture(Content.Load<Texture2D>("luigiSprites"));
            assets.SetMegamanTexture(Content.Load<Texture2D>("megamanSprites"));
            assets.SetBackGroundTextures(Content.Load<Texture2D>("background1"));     
            assets.SetFont(Content.Load<SpriteFont>("HUDFont"));
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            assets.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();

            assets.Draw(spriteBatch);
           
            spriteBatch.End();           
            base.Draw(gameTime);
        }
    }
}
