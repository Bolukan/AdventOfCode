using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day201704 : IDay
    {
        public string InputFile { get { return "input04.txt"; } }

        public int Part1(string[] input)
        {
            return input.Length;
        }

        public int Part2(string[] input)
        {
            return int.Parse(input[0]);
        }

    }
}
