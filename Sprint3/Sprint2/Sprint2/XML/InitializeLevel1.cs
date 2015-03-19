using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DataTypes;
using Sprint2.BackgroundItems;
using Sprint2.Objects.Blocks;
using Sprint2.Objects.Blocks.BlockState;
using Sprint2.Objects.Items;
using Sprint2.Enemies;
using Sprint2.Enemies.GoombaState;
using Sprint2.Enemies.KoopaState;
using Sprint2.Player;
using Sprint2.Player.MarioState;
using Sprint2.Objects.Pipes;
using Sprint2.Objects.Pipes.PipeState;
using Sprint2.LevelData;
using Sprint2.Objects.Flagpole;
using Sprint2.Objects.Blocks.BlockState.Underworld;

namespace Sprint2.XML
{
    public class InitializeLevel1 
    {
        public void PopulateLevelAssets(LevelAssets levelAssets)
        {
            Texture2D blockTexture = levelAssets.GetObjectTexutre();
            Texture2D staticItemsTexture = levelAssets.GetBackGroundTexture();
            Texture2D enemiesTexture = levelAssets.GetEnemiesTexture();
            Texture2D marioTexture = levelAssets.GetMarioTexture();
            Levels level1 = levelAssets.GetLevel();
            ArrayList ItemsL = levelAssets.GetItemList();
            ArrayList ObjectL = levelAssets.GetObjectList();
            ArrayList BackgroundL = levelAssets.GetBackGroundList();
            ArrayList EnemiesL = levelAssets.GetEnemyList();
            ArrayList PlayerL = levelAssets.GetPlayerList();

            foreach(BackgroundData backgroundItem in level1.backgrounds) 
            {
                if (backgroundItem.name.Equals("Cloud1"))
                {
                    BackgroundL.Add(new Cloud1(blockTexture, backgroundItem.PosX, backgroundItem.PosY));
                }
                else if (backgroundItem.name.Equals("Cloud2"))
                {
                    BackgroundL.Add(new Cloud2(staticItemsTexture, backgroundItem.PosX, backgroundItem.PosY));
                }
                else if (backgroundItem.name.Equals("Cloud3"))
                {
                    BackgroundL.Add(new Cloud3(staticItemsTexture, backgroundItem.PosX, backgroundItem.PosY));
                }
                else if (backgroundItem.name.Equals("Mountains"))
                {
                    BackgroundL.Add(new Mountains(staticItemsTexture, backgroundItem.PosX, backgroundItem.PosY));
                }
                else if (backgroundItem.name.Equals("Bush3"))
                {
                    BackgroundL.Add(new Bush3(staticItemsTexture, backgroundItem.PosX, backgroundItem.PosY));
                }
                else if (backgroundItem.name.Equals("SmallMountain"))
                {
                    BackgroundL.Add(new SmallMountain(staticItemsTexture, backgroundItem.PosX, backgroundItem.PosY));
                }
                else if (backgroundItem.name.Equals("Bush1"))
                {
                    BackgroundL.Add(new Bush1(staticItemsTexture, backgroundItem.PosX, backgroundItem.PosY));
                }
                else if (backgroundItem.name.Equals("Bush2"))
                {
                    BackgroundL.Add(new Bush2(staticItemsTexture, backgroundItem.PosX, backgroundItem.PosY));
                }
                else if( backgroundItem.name.Equals("Castle1"))
                {
                    BackgroundL.Add(new Level1Castle(blockTexture, backgroundItem.PosX, backgroundItem.PosY));
                }
                else if (backgroundItem.name.Equals("Black"))
                {
                    BackgroundL.Add(new Black(blockTexture, backgroundItem.PosX, backgroundItem.PosY));
                }
            }
            foreach (BlockData block in level1.blocks)
            {
                if (block.name.Equals("BrickBlock"))
                {
                    ObjectL.Add(new Block(blockTexture, block.PosX, block.PosY, new BrickBlock(),block.Contains));
                }
                else if (block.name.Equals("FloorBlock"))
                {
                    ObjectL.Add(new Block(blockTexture, block.PosX, block.PosY, new FloorBlock(),block.Contains));
                }
                else if (block.name.Equals("QuestionBlock"))
                {
                    ObjectL.Add(new Block(blockTexture, block.PosX, block.PosY, new QuestionBlock(),block.Contains));
                }
                else if (block.name.Equals("StepBlock"))
                {
                    ObjectL.Add(new Block(blockTexture, block.PosX, block.PosY, new StepBlock(),block.Contains));
                }
                else if (block.name.Equals("UsedBlock"))
                {
                    ObjectL.Add(new Block(blockTexture, block.PosX, block.PosY, new UsedBlock(),block.Contains));
                }
                else if (block.name.Equals("UnbreakableBrickBlock"))
                {
                    ObjectL.Add(new Block(blockTexture, block.PosX, block.PosY, new UnbreakableBrickBlock(),block.Contains));
                }
                else if (block.name.Equals("UseableBrickBlock"))
                {
                    ObjectL.Add(new Block(blockTexture, block.PosX, block.PosY, new UseableBrickBlock(), block.Contains));
                }
                else if (block.name.Equals("UnderworldBrickBlock"))
                {
                    ObjectL.Add(new Block(blockTexture, block.PosX, block.PosY, new UnderworldBrickBlock(),block.Contains));
                }
                else if (block.name.Equals("UnderworldFloorBlock"))
                {
                    ObjectL.Add(new Block(blockTexture, block.PosX, block.PosY, new UnderworldFloorBlock(),block.Contains));
                }
            }

            //Optimize blocks in objectL
            ArrayList ObjectLOptimized = new ArrayList();
            ArrayList blocksRemoved = new ArrayList();
            foreach (Object o in ObjectL)
            {

                Block b = o as Block;
                if (!blocksRemoved.Contains(b))
                {
                    foreach (Object o2 in ObjectL)
                    {
                        Block b2 = o2 as Block;
                        if(b.Combinable(b2))
                        {
                            b.Combine(b2);
                            blocksRemoved.Add(b2);
                        }
                    }
                    if (!ObjectLOptimized.Contains(b))
                        ObjectLOptimized.Add(b);
                }
            }
            
            ObjectL.Clear();
            foreach (Object o in ObjectLOptimized)
            {
                ObjectL.Add(o);
            }
            

            foreach (EnemyData enemy in level1.enemies)
            {
                if (enemy.name.Equals("Goomba"))
                {
                    EnemiesL.Add(new Goomba(enemiesTexture, enemy.PosX, enemy.PosY, new WalkingGoomba()));
                }
                else if (enemy.name.Equals("Koopa")) {
                    EnemiesL.Add(new Koopa(enemiesTexture, enemy.PosX, enemy.PosY, new LeftWalkingKoopa()));
                }
                else if (enemy.name.Equals("KoopaShell"))
                {
                    EnemiesL.Add(new KoopaShell(enemiesTexture, enemy.PosX, enemy.PosY, new ShellKoopa()));
                }
            }
            foreach(ItemsData item in level1.items) {

                if (item.name.Equals("Coin"))
                {
                    ItemsL.Add(new Coin(blockTexture, item.PosX, item.PosY));
                }
                else if (item.name.Equals("FireFlower"))
                {
                    ItemsL.Add(new FireFlower(blockTexture, item.PosX, item.PosY));
                }
                else if (item.name.Equals("Mushroom"))
                {
                    ItemsL.Add(new Mushroom(blockTexture, item.PosX, item.PosY));
                }
                else if (item.name.Equals("PoisonMushroom"))
                {
                    ItemsL.Add(new PoisonMushroom(blockTexture, item.PosX, item.PosY));
                }
                else if (item.name.Equals("Star"))
                {
                    ItemsL.Add(new Star(blockTexture, item.PosX, item.PosY));
                }    
            }
            foreach (PipeData pipe in level1.pipes)
            {
                if (pipe.HasDestination)
                {
                    if (pipe.name.Equals("Pipe1"))
                    {
                        ObjectL.Add(new Pipe(blockTexture, pipe.PosX, pipe.PosY, new ShortPipe(),'0',pipe.DestinationX,pipe.DestinationY));
                    }
                    else if (pipe.name.Equals("Pipe2"))
                    {
                        ObjectL.Add(new Pipe(blockTexture, pipe.PosX, pipe.PosY, new MediumPipe(), '0', pipe.DestinationX, pipe.DestinationY));
                    }
                    else if (pipe.name.Equals("Pipe3"))
                    {
                        ObjectL.Add(new Pipe(blockTexture, pipe.PosX, pipe.PosY, new TallPipe(), '0', pipe.DestinationX, pipe.DestinationY));
                    }
                    else if (pipe.name.Equals("Pipe4"))
                    {
                        ObjectL.Add(new Pipe(blockTexture, pipe.PosX, pipe.PosY, new LeftFacingPipe(), '0', pipe.DestinationX, pipe.DestinationY));
                    }
                    else if (pipe.name.Equals("Pipe5"))
                    {
                        ObjectL.Add(new Pipe(blockTexture, pipe.PosX, pipe.PosY, new TallUndergroundPipe(), '0', pipe.DestinationX, pipe.DestinationY));
                    }
                }
                else
                {
                    if (pipe.name.Equals("Pipe1"))
                    {
                        ObjectL.Add(new Pipe(blockTexture, pipe.PosX, pipe.PosY, new ShortPipe()));
                    }
                    else if (pipe.name.Equals("Pipe2"))
                    {
                        ObjectL.Add(new Pipe(blockTexture, pipe.PosX, pipe.PosY, new MediumPipe()));
                    }
                    else if (pipe.name.Equals("Pipe3"))
                    {
                        ObjectL.Add(new Pipe(blockTexture, pipe.PosX, pipe.PosY, new TallPipe()));
                    }
                    else if (pipe.name.Equals("Pipe4"))
                    {
                        ObjectL.Add(new Pipe(blockTexture, pipe.PosX, pipe.PosY, new LeftFacingPipe()));
                    }
                    else if (pipe.name.Equals("Pipe5"))
                    {
                        ObjectL.Add(new Pipe(blockTexture, pipe.PosX, pipe.PosY, new TallUndergroundPipe()));
                    }
                }
            }
            foreach(FlagpoleData flagpole in level1.flagpole)
            {
                if (flagpole.name.Equals("Flagpole"))
                    ObjectL.Add(new Pole(blockTexture, flagpole.PosX, flagpole.PosY));
            }
            
            if(PlayerL.Count == 0)
                foreach (PlayerData player in level1.players)
                {
                    if (player.name.Equals("Mario"))
                    {
                        PlayerL.Add(new Mario(marioTexture, player.PosX, player.PosY, new smallRightFacingIdle()));
                    }
                }
            else
            {
                PlayerData player = level1.players[0];
                foreach(IPlayer p in PlayerL)
                {
                    p.SetXYPos(player.PosX, player.PosY);
                    if (p.IsDead())
                        p.Reset();
                }
            }
        }
    }
}
