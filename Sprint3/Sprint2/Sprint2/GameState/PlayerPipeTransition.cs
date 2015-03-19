using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.LevelData;
using Sprint2.Objects.Pipes;
using Sprint2.Player;
using Sprint2.Player.MarioState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.GameState
{
    class PlayerPipeTransition
    {
        static bool inTransition = false;
        static IPlayer player;
        static Pipe pipe;
        static bool UpwardsFacingPipe;
        static int transitionCoolDown = 0;
        static double xOffset;
        static double yOffset;

        LevelAssets assets;
        public PlayerPipeTransition(LevelAssets a){
        assets = a;

        

        }
        public PlayerPipeTransition(IPlayer m, Pipe p)
        {
            inTransition = true;
            player = m;
            pipe = p;
            UpwardsFacingPipe = p.CanEnterFromTop();
            transitionCoolDown = 90;
            xOffset = 0;
            yOffset = 0;
        }

        public void Update()
        {
            if(inTransition)
            {
                transitionCoolDown--;
                if (UpwardsFacingPipe)
                {
                    yOffset += 0.5;
                }
                else
                {
                    xOffset += 0.5;
                }
                if (transitionCoolDown < 0)
                {
                    inTransition = false;
                    Tuple<int, int> Destination = pipe.GetDestination();
                    player.SetXYPos(Destination.Item1, Destination.Item2);
                    Camera camera = new Camera();
                    camera.Reset();
                }
            }

        }

        public bool InTransistion()
        {
            return inTransition;
        }

        public IPlayer PlayerInTransition()
        {
            return player;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            Rectangle refRec = player.GetRectangle();
            int xPos = refRec.X;
            int yPos = refRec.Y;
            Camera camera = new Camera();
            spritebatch.Draw(player.GetTexture(), new Rectangle(xPos - camera.GetCameraOffset() + (int)xOffset, yPos + (int)yOffset, refRec.Width, refRec.Height), player.GetSpriteRefRectangle(), Color.White);
        }
    }
}
