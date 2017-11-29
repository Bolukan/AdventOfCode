using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    /* https://pastebin.com/BMd61PUv
     * https://pastebin.com/wGmzZHeq
     * 
     * Advent Warmup: Elvish Cheat Codes
---------------------------------
In the run up to advent, the elves are playing on their video game console. Before long, one of the elves manages to discover a cheat mode, by entering a sequence of button presses on the controller.
The sequence involves the buttons 'Up', 'Down', 'Left', 'Right', 'A', 'B', and terminates with a single press of the 'Start' button.
The elves begin to ponder the significance of the sequence they discovered, and decide to draw a chart.
Starting at the origin in an (x,y) grid, the buttons Up, Down, Left, Right are imagined to move a cursor a single step in the corresponding direction through the grid. Buttons A and B place corresponding markers at the current cursor location.
-------------------------------------------------------------
Example:  Up, A, Right, Right, B, Left, B, Start
Taking Right to be the positive x direction, and Up to be the positive y direction. This sequence will move one step up from the origin (0,0), and place an 'A' marker at location (0,1), then a 'B' marker at location (2,1). The cursor will move one step left and another 'B' marker is placed at location (1,1). Then the cursor halts at location (1,1).
-------------------------------------------------------------
Example:  Up, Up, Down, Down, Left, Right, Left, Right, B, A, Start
Again, starting from the origin (0,0), this sequence will place both a 'B' and an 'A' marker at (0,0), and the cursor will halt at (0,0).
-------------------------------------------------------------
The taxicab distance ( https://en.wikipedia.org/wiki/Taxicab_distance ) between two grid locations is defined as the (positive) difference between the two points' x values + the (positive) difference between their y values.
eg, between locations (1,2) and (8,6), the difference between the two x values (1 and 8) is 7, and the difference between the two y values (2 and 6) is 4. Therefore, the taxicab distance is 7 + 4 = 11.
Your input is here: https://pastebin.com/wGmzZHeq
Question 1:
Identify the marker furthest from the origin, as measured by the taxicab distance, and return that distance.
Question 2:
Consider all pairs of *different* markers (where a pair may consist of any 'A' and any 'B' marker). Identify the pair maximally far apart from one another, as measured by the taxicab distance, and return that distance.
*/
    public class Day00 : IDay
    {
        public string InputFile { get { return "elvish_cheat_codes.txt"; } }

        struct Point
        {
            public int X;
            public int Y;
        }

        struct AB
        {
            public bool A;
            public bool B;
        }

        private int Answer01(Dictionary<Point, AB> points)
        {
            int maxDistance = 0;
            foreach(KeyValuePair<Point, AB>  point in points)
            {
                int distance = Math.Abs(point.Key.X) + Math.Abs(point.Key.Y);
                if (distance > maxDistance) maxDistance = distance;
            }
            return maxDistance;
        }

        private int Answer02(Dictionary<Point, AB> points)
        {
            int maxDistance = 0;
            foreach (KeyValuePair<Point, AB> point1 in points.Where(point => point.Value.A))
            {
                foreach (KeyValuePair<Point, AB> point2 in points.Where(point => point.Value.B))
                {
                    int distance = Math.Abs(point1.Key.X - point2.Key.X) + Math.Abs(point1.Key.Y - point2.Key.Y);
                    if (distance > maxDistance) maxDistance = distance;
                }
            }
            return maxDistance;
        }

        private void RegisterAB(int x, int y, string command, Dictionary<Point, AB> points)
        {
            Point currentPoint = new Point { X = x, Y = y };
            AB newAB = new AB { A = command == "A", B = command == "B" };

            if (points.ContainsKey(currentPoint))
            {
                newAB.A |= points[currentPoint].A;
                newAB.B |= points[currentPoint].B;
                points.Remove(currentPoint);
            }
            points.Add(currentPoint, newAB);
            // Console.WriteLine(x.ToString() + "/" + y.ToString() + ": " + (newAB.A ? "A" : "") + " " + (newAB.B ? "B" : ""));
        }

        private Dictionary<Point, AB> ReadAll(string[] input)
        {
            string[] commands = input[0].Split(new string[] { ", " }, StringSplitOptions.None);
            int X = 0;
            int Y = 0;
            Dictionary<Point, AB> points = new Dictionary<Point, AB>();
            foreach (string command in commands)
            {
                switch (command)
                {
                    case "Left": X--; break;
                    case "Right": X++; break;
                    case "Up": Y++; break;
                    case "Down": Y--; break;
                    case "A": RegisterAB(X, Y, command, points); break;
                    case "B": RegisterAB(X, Y, command, points); break;
                    case "Start": return points;
                    default: break;
                }
            }
            return points;
        }

        /// <summary>
        /// My answer: 86, according to twitter 87 ??????????????
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int Part1(string[] input)
        {
            Dictionary<Point, AB> points = ReadAll(input);
            return Answer01(points);
        }

        /// <summary>
        /// My answer: 137. 1 star.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int Part2(string[] input)
        {
            Dictionary<Point, AB> points = ReadAll(input);
            return Answer02(points);
        }

    }
}
