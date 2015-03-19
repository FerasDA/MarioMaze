using Microsoft.Xna.Framework;
using Sprint2.Player.Attacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.MegamanState
{
    interface IMegamanState
    {
        IMegamanState Idle();

        IMegamanState Jump();

        IMegamanState Left();

        IMegamanState Right();

        IMegamanState Attack(MegamansBullet mmb);

        IMegamanState Flagpole();

        IMegamanState Death();

        IMegamanState Update();

        Rectangle getReferenceRectangle();
    }
}
