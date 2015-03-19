using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision
{
    class CollisionType
    {
        public enum Collision { none, left, right, top, bottom, inside, consumed }

        public CollisionType(){}

        //Returns none if there is no collision
        //Returns left if Rectangle one is colliding with the left side of Rectangle two
        //Returns right if Rectangle one is colliding with the right side of Rectangle two
        //Returns bottom if Rectangle one is colliding with the bottom side of Rectangle two
        //Returns top if Rectangle one is colliding with the top side of Rectangle two
        //Returns inside if Rectangle one is completely inside Rectangle two
        //Returns Consumed if Retangle two is completely inside Rectangle one
        public Collision GetCollisionType(Rectangle one, Rectangle two) 
        {
            Collision output = Collision.none;
            Rectangle overlap = Rectangle.Intersect(one, two);

            if (overlap.IsEmpty)
                output = Collision.none;

            else if (overlap.Equals(one))
                output = Collision.inside;

            else if (overlap.Equals(two))
                output = Collision.consumed;

            else
                output = getCollsionSide(one,two);

            return output;
        }

        private Collision getCollsionSide(Rectangle one, Rectangle two)
        {
            Rectangle twoLeft = new Rectangle(two.X, two.Y, 1, two.Height);
            Rectangle twoRight = new Rectangle(two.X + two.Width - 1, two.Y, 1, two.Height);
            Rectangle twoTop = new Rectangle(two.X, two.Y, two.Width, 2);
            Rectangle twoBottom = new Rectangle(two.X, two.Y + two.Height - 1, two.Width, 1);

            twoLeft = Rectangle.Intersect(one, twoLeft);
            twoRight = Rectangle.Intersect(one, twoRight);
            twoTop = Rectangle.Intersect(one, twoTop);
            twoBottom = Rectangle.Intersect(one, twoBottom);

            Collision output = getLargestRectangle(twoLeft,twoRight, twoTop, twoBottom);

            return output;
        }

        private Collision getLargestRectangle(Rectangle twoLeft, Rectangle twoRight, Rectangle twoTop, Rectangle twoBottom)
        {
            Collision output = Collision.top;
            int largestSize = getRectangleSize(twoTop);

            if (getRectangleSize(twoBottom) > largestSize)
            {
                output = Collision.bottom;
                largestSize = getRectangleSize(twoBottom);
            }

            if (getRectangleSize(twoRight) > largestSize)
            {
                output = Collision.right;
                largestSize = getRectangleSize(twoRight);
            }

            if (getRectangleSize(twoLeft) > largestSize)
            {
                output = Collision.left;
            }

            return output;
        }

        private int getRectangleSize(Rectangle twoLeft)
        {
            return (twoLeft.Width * twoLeft.Height);
        }

        internal Collision GetCollisionSide(Rectangle pRec, Rectangle enemyRec)
        {
            Collision output = Collision.none;
            int largestSize = 0;

            Rectangle enemyRecLeft = new Rectangle(enemyRec.X, enemyRec.Y, 1, enemyRec.Height);
            Rectangle enemyRecRight = new Rectangle(enemyRec.X + enemyRec.Width - 1, enemyRec.Y, 1, enemyRec.Height);

            enemyRecLeft = Rectangle.Intersect(pRec, enemyRecLeft);
            enemyRecRight = Rectangle.Intersect(pRec, enemyRecRight);

            if (getRectangleSize(enemyRecLeft) > largestSize)
            {
                output = Collision.left;
                largestSize = getRectangleSize(enemyRecLeft);
            }

            if (getRectangleSize(enemyRecRight) > largestSize)
            {
                output = Collision.right;
            }

            return output;
        }
    }
}
