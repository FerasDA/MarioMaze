using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Constants;

namespace Sprint2.Enemies.KoopaState
{
    class ShellKoopa : IKoopa
    {
        Rectangle refRectangle = new Rectangle(Rec.SHELLKOOPA_X, Rec.SHELLKOOPA_Y, Rec.SHELLKOOPA_W, Rec.SHELLKOOPA_H);

        public ShellKoopa(){}

        public void Update()
        {

        }

        public IKoopa Damage()
        {
            return this;
        }

        public Rectangle getRefRectangle()
        {
            return refRectangle;
        }


        public Rectangle GetWeakSpot()
        {
            return new Rectangle(0, refRectangle.Height, refRectangle.Width, 1);
        }


        public IKoopa TurnAround()
        {
            return this;
        }
    }
}
