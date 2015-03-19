using DataTypes;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.LevelData
{
    class NextLevelLoader
    {
        ContentManager manager;
        public NextLevelLoader(ContentManager cm) 
        {
            manager = cm;
        }

        public void LoadNextLevel()
        {
            LevelAssets assets = new LevelAssets();
            Levels level1 = assets.GetLevel();
            String nextLevel = level1.nextLevel.name;
            assets.SetLevel1(manager.Load<Levels>(nextLevel));
            assets.Reset();
        }
    }
}
