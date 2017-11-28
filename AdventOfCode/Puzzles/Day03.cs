﻿using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day03 : IDay
    {
        public string InputFile { get { return "input03.txt"; } }

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