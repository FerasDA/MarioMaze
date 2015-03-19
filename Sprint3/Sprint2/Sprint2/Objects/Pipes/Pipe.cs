using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Cameras;
using Sprint2.GameState;
using Sprint2.LevelData;
using Sprint2.Objects.Pipes;
using Sprint2.Objects.Pipes.PipeState;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Objects.Pipes
{
    class Pipe : IObject
    {
        Rectangle refRectangle = new Rectangle(Rec.PIPE_X, Rec.PIPE_Y, Rec.PIPE_W, Rec.PIPE_H);
        private int xPos;
        private int yPos;
        private bool hasDestination = false;
        private char destination = '0';
        private int xPosDestination;
        private int yPosDestination;
        IPipeState pipeState;
        Texture2D pipeTexture;

        public Pipe(Texture2D texture, int x, int y, IPipeState state)
        {
            pipeTexture = texture;
            xPos = x;
            yPos = y;
            pipeState = state;
        }

        public Pipe(Texture2D texture, int x, int y, IPipeState state, char destination, int dx, int dy)
        {
            pipeTexture = texture;
            xPos = x;
            yPos = y;
            pipeState = state;
            hasDestination = true;
            this.destination = destination;
            xPosDestination = dx;
            yPosDestination = dy;
        }
        public void Update()
        {
            pipeState.Update();
        }
        public void Collision()
        {
            pipeState = pipeState.Collision();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle spriteRef = pipeState.getReferenceRectangle();
            Camera camera = new Camera();
            spriteBatch.Draw(pipeTexture, new Rectangle(xPos - camera.GetCameraOffset(), yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
        }
        public Rectangle GetRectangle()
        {
            Rectangle spriteRef = pipeState.getReferenceRectangle();
            return new Rectangle(xPos, yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height);
        }
        public Rectangle GetWeakSpot()
        {
            // Not weak spot, but mario should be able to go down in
            Rectangle spriteRef = pipeState.getReferenceRectangle();
            Rectangle weakRef = pipeState.GetWeakSpot();
            return new Rectangle(xPos + weakRef.X, yPos - weakRef.Y, weakRef.Width, weakRef.Height);
        }

        public bool CanEnterFromTop()
        {
            LeftFacingPipe lfp = pipeState as LeftFacingPipe;
            return (hasDestination && lfp == null);
        }

        public bool CanEnterFromLeft()
        {
            LeftFacingPipe lfp = pipeState as LeftFacingPipe;
            return (hasDestination && lfp != null);
        }

        public void PlayerEnters(IPlayer p)
        {
            PlayerPipeTransition ppt = new PlayerPipeTransition(p, this);
        }

        public Tuple<int, int> GetDestination()
        {
            return Tuple.Create<int,int>(xPosDestination,yPosDestination);
        }
    }
}
