using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Enemies.KoopaState
{
    class RightWalkingKoopa : IKoopa
    {
        double currentFrame = 0;
        static Rectangle[] refRectangle = new Rectangle[] { 
            new Rectangle(Rec.RWALKINGKOOPA_X0, Rec.RWALKINGKOOPA_Y, Rec.RWALKINGKOOPA_W, Rec.RWALKINGKOOPA_H0), 
            new Rectangle(Rec.RWALKINGKOOPA_X1, Rec.RWALKINGKOOPA_Y, Rec.RWALKINGKOOPA_W, Rec.RWALKINGKOOPA_H1) };
        int totalFrames = refRectangle.Length;

        public RightWalkingKoopa(){}

        public void Update()
        {
            currentFrame = (currentFrame + .1) % totalFrames;
        }

        public IKoopa Damage()
        {
            return new ShellKoopa();
        }

        public Rectangle getRefRectangle()
        {
            return refRectangle[(int)currentFrame];
        }


        public Rectangle GetWeakSpot()
        {
            return new Rectangle(0, refRectangle[(int)currentFrame].Height, refRectangle[(int)currentFrame].Width, 1);
        }


        public IKoopa TurnAround()
        {
            return new LeftWalkingKoopa();
        }
    }
}
