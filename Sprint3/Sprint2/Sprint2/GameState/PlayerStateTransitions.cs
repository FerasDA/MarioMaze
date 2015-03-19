using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.LevelData;
using Sprint2.Player;
using Sprint2.Player.MarioState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.GameState
{
    class PlayerStateTransitions
    {
        static bool inTransition = false;
        static IPlayer mario;
        static IMarioState oldState;
        static IMarioState newState;
        static int transitionCoolDown = 0;
        LevelAssets assets;
        public PlayerStateTransitions(LevelAssets a){
        assets = a;
        }
        public PlayerStateTransitions(Mario m, IMarioState oS, IMarioState nS)
        {
            inTransition = true;
            mario = m;
            oldState = oS;
            newState = nS;
            transitionCoolDown = 30;

        }

        public void Update()
        {
            if(inTransition)
            {
                transitionCoolDown--;
                if (transitionCoolDown < 0)
                    inTransition = false;
            }

        }

        public bool InTransistion()
        {
            return inTransition;
        }

        public IPlayer PlayerInTransition()
        {
            return mario;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            Rectangle refRec = mario.GetRectangle();
            int xPos = refRec.X;
            int yPos = refRec.Y + refRec.Height;
            Camera camera = new Camera();
            
            if((transitionCoolDown/5)%2==1 && transitionCoolDown != 0)
            {
                Rectangle oldRec = oldState.getReferenceRectangle();
                spritebatch.Draw(mario.GetTexture(), new Rectangle(xPos - camera.GetCameraOffset(), yPos - oldRec.Height, oldRec.Width, oldRec.Height), oldRec, Color.White);
            }
            else
            {
                Rectangle newRec = newState.getReferenceRectangle();
                spritebatch.Draw(mario.GetTexture(), new Rectangle(xPos - camera.GetCameraOffset(), yPos - newRec.Height, newRec.Width, newRec.Height), newRec, Color.White);
            }
        }
    }
}
