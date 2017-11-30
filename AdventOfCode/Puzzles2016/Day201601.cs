using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day201601 : IDay
    {
        public string InputFile { get { return "input201601.txt"; } }
        public Position pos;

        private void CreateObject(string[] input)
        {
            string[] commands = Helper.SplitOnComma(input[0]);
            pos = new Position();

            foreach (string command in commands)
            {
                switch (command[0])
                {
                    case 'L': pos.GoLeft(); break;
                    case 'R': pos.GoRight(); break;
                    default: break;
                }
                pos.Step(int.Parse(command.Substring(1)));
            }
        }


        public int Part1(string[] input)
        {
            CreateObject(input);
            return Math.Abs(pos.XY.X) + Math.Abs(pos.XY.Y);
        }

        public int Part2(string[] input)
        {
            for(int i = 1; i < pos.Points.Count(); i++)
            {
                if (pos.Points.Take(i).Any(p => p.Equals(pos.Points[i])))
                {
                    return pos.Points[i].Distance();
                }
            }
            return 0;
        }

    }
}
