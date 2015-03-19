using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Player.Attacks;

namespace Sprint2.Player.MarioState
{
    interface IMarioState
    {
        IMarioState Idle();

        IMarioState Jump();

        IMarioState Crouch();

        IMarioState Left();

        IMarioState Right();

        void Attack(MariosFireBall fb);

        IMarioState Mushroom();

        IMarioState Fire();

        IMarioState damaged();

        IMarioState Flagpole();

        void update();

        Rectangle getReferenceRectangle();
    }
}
