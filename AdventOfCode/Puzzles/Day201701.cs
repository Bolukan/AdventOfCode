using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day201701 : IDay
    {
        public string InputFile { get { return "input01.txt"; } }

        private int MatchDigits(string input, int offset)
        {
            int modulos = input.Length;
            int answer = 0;
            for (int pos = 0; pos < modulos; pos++)
            {
                if (input[pos] == input[(pos + offset) % modulos]) answer += (int)Char.GetNumericValue(input[pos]);
            }
            return answer;
        }

        public int Part1(string[] input)
        {
            return MatchDigits(input[0], 1);
        }

        public int Part2(string[] input)
        {
            return MatchDigits(input[0], input[0].Length/2);
        }

    }
}
