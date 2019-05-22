using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConvexHull
{
    // new class that uses IComparer to Sort by lowest Y value
    public class SortByY : IComparer<Vector2>
    {
        
        public int Compare(Vector2 a, Vector2 b)
        {
            if (a.Y > b.Y)
            {
                return 1;
            }

            if (a.Y < b.Y)
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }
    }
}
