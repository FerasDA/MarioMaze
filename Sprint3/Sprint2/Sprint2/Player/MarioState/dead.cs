using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2.Player.MarioState
{
    class dead : IMarioState
    {
        Rectangle refRectangle = new Rectangle(0,0,0,0);
        public dead() {}
        public IMarioState Idle() {
            
            return this; // Would be this if not for state change testing
            //return new smallRightFacingIdle();
        }

        public IMarioState Jump() {
            return this; // Would be this if not for state change testing
            //return new smallRightFacingIdle();
        }

        public IMarioState Crouch() {
            return this; // Would be this if not for state change testing
            //return new smallRightFacingIdle();
        }

        public IMarioState Left() {
            return this; // Would be this if not for state change testing
            //return new smallLeftFacingIdle();
        }

        public IMarioState Right() {
            return this; // Would be this if not for state change testing
            //return new smallRightFacingIdle();
        }

        public void Attack(Attacks.MariosFireBall fb) { }

        public IMarioState Mushroom() {
            return this; // Would be this if not for state change testing
            //return new smallRightFacingIdle();
        }

        public IMarioState Fire() {
            return this; // Would be this if not for state change testing
            //return new smallRightFacingIdle();
        }

        public IMarioState damaged() {
            return this;
        }

        public IMarioState Flagpole()
        {
            return this;
        }

        public void update() {}

        public Rectangle getReferenceRectangle()
        {
            return refRectangle;
        }

        public override string ToString()
        {
            return "dead";
        }
    }
}
