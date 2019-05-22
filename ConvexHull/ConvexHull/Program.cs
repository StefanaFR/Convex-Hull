using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.Windows.Forms;

namespace ConvexHull
{
    class Program
    {
        // list of points
        static List<Vector2> points = new List<Vector2>();

        public static void Main(string[] args)
        {
            // Test 1 points
            points.Add(new Vector2(0, 3));
            points.Add(new Vector2(1, 1));
            points.Add(new Vector2(2, 2));
            points.Add(new Vector2(4, 4));
            points.Add(new Vector2(0, 0));
            points.Add(new Vector2(1, 2));
            points.Add(new Vector2(3, 1));
            points.Add(new Vector2(3, 3));

            // Test 2 points
            //points.Add(new Vector2(116, 68));
            //points.Add(new Vector2(162, 226));
            //points.Add(new Vector2(158, 193));
            //points.Add(new Vector2(326, 288));
            //points.Add(new Vector2(200, 152));
            //points.Add(new Vector2(305, 212));
            //points.Add(new Vector2(254, 135));
            //points.Add(new Vector2(365, 167));
            //points.Add(new Vector2(307, 97));
            //points.Add(new Vector2(527, 96));
            
            // Writes the list of points out to the console
            listOfPoints(points);

            // sort ascending by y values.
            points.Sort(new SortByY());

            // sort counterclockwise by polar angles from smallest y value point. 
            SortByAngle hull = new SortByAngle();
            hull.Origin = points[0];
            points.Sort(hull);

            // create the empty stack of points
            Stack<Vector2> s = new Stack<Vector2>();
            // push the first two points fromt he list of points onto the stack
            s.Push(points[0]);
            s.Push(points[1]);

            // while the direction is counterclockwise, determine whether the points are within the bounds of the polygon, or if they are corner points
            for (int i = 2; i < points.Count; i++)
            {
                Vector2 top = s.Pop();
                while (Direction(s.Peek(), top, points[i]) <= 0)
                {
                    top = s.Pop();
                }
                s.Push(top);
                s.Push(points[i]);
            }

            // output the bounding vertices of the polygon
            Console.WriteLine("\nConvex Hull Bounding Vertices ");
            while (s.Count != 0)
            {
                Vector2 v = s.Peek();
                Console.Write(" ({0}" + "," + "{1}) ", v.X, v.Y);
                s.Pop();
            }
            
            Console.ReadLine();
        }

        // Find direction (clockwise, counterclockwise, or colinear)
        public static float Direction(Vector2 one, Vector2 two, Vector2 three)
        {
            float value = (two.Y - one.Y) * (three.X - two.X) -
                      (two.X - one.X) * (three.Y - two.Y);

            if (value == 0)
            {
                return 0; // colinear
            }
            else if (value > 0)
            {
                return 1; // clockwise
            }
            else
            {
                return -1; //counterclockwise
            }
        }
        
        // function that outputs the list of all points within polygon
        public static void listOfPoints(List<Vector2> points)
        {
            Console.WriteLine("List of initial points");
            foreach (Vector2 vector in points)
            {
                Console.Write(" (" + vector.X + "," + vector.Y + ") ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}


