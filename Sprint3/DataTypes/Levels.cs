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

namespace DataTypes
{
    public class Levels
    {
        public List<BackgroundData> backgrounds;
        public List<BlockData> blocks;
        public List<EnemyData> enemies;
        public List<ItemsData> items;
        public List<PipeData> pipes;
        public List<FlagpoleData> flagpole;
        public List<PlayerData> players;
        public NextLevel nextLevel;
        public CurrentLevelData currentLevel;
     }
}
