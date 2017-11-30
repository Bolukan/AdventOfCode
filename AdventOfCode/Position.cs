using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return X.ToString() + "/" + Y.ToString();
        }

        public int Distance()
        {
            return Math.Abs(X) + Math.Abs(Y);
        }

        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;
            Point point2 = (Point)obj;

            return (X == point2.X) && (Y == point2.Y);
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }

    public class Position
    {
        public Point XY;
        public int DX { get; set; }
        public int DY { get; set; }
        public List<Point> Points { get; }

        public Position()
        {
            DY = 1;
            Points = new List<Point>();
            Points.Add(XY);
        }

        public void GoLeft()
        {
            if (DX == 0)
            {
                DX = -DY;
                DY = 0;
            }
            else
            {
                DY = DX;
                DX = 0;
            }
        }

        public void GoRight()
        {
            if (DX == 0)
            {
                DX = DY;
                DY = 0;
            }
            else
            {
                DY = -DX;
                DX = 0;
            }
        }

        public void Step(int steps = 1)
        {
            for (int step = 1; step <= steps; step++)
            {
                XY.X += DX;
                XY.Y += DY;
                Points.Add(XY);
            }
        }

    }
}
