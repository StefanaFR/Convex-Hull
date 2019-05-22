using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConvexHull
{
    // new class that uses IComparer to Sort by Angle
    public class SortByAngle : IComparer<Vector2>
    {
        // set the origin point as the point with the lowest Y value
        private Vector2 origin;
        public Vector2 Origin { get { return origin; } set { origin = value; } }
        
        public int Compare(Vector2 a, Vector2 b)
        {
            return IsCCW(a, b, origin);
        }

        // check to see if the direction is counterclockwise
        public static int IsCCW(Vector2 a, Vector2 b, Vector2 origin)
        {
            if (a == origin || a == b || b == origin)
            {
                return 0;
            }

            Vector2 firstOffset = a - origin;
            Vector2 secondOffset = b - origin;

            double angle1 = Math.Atan2(firstOffset.X, firstOffset.Y) * 180/Math.PI; // generates the angle
            double angle2 = Math.Atan2(secondOffset.X, secondOffset.Y) * 180 / Math.PI; // generates the angle

            if (angle1 < angle2)
            {
                return -1; 
            }

            else if (angle1 > angle2)
            {
                return 1;
            }

            else
            {
                if (firstOffset.LengthSquared() < secondOffset.LengthSquared())
                {
                    return -1;
                }

                else
                {
                    return 1;
                }
            }
        }

    }
}
