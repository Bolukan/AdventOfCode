using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day201702 : IDay
    {
        public string InputFile { get { return "input02.txt"; } }

        private int[] Numbers(string line)
        {
            List<int> numbers = new List<int>();
            foreach(string getal in line.Split('\t'))
            {
                numbers.Add(int.Parse(getal));
            }
            return numbers.ToArray();
        }

        public int Part1(string[] input)
        {
            int checksum = 0;
            foreach (string line in input)
            {
                int max = int.MinValue;
                int min = int.MaxValue;
                int[] nummers = Numbers(line);
                foreach (int nummer in nummers)
                {
                    if (nummer > max) max = nummer;
                    if (nummer < min) min = nummer;
                }
                checksum += (max - min);
            }
            return checksum;
        }

        public int Part2(string[] input)
        {
            int checksum = 0;
            foreach (string line in input)
            {
                int[] nummers = Numbers(line);
                foreach (int nummer in nummers)
                    foreach (int nummer2 in nummers)
                    {
                        if ((nummer != nummer2) && (nummer % nummer2 == 0))
                        {
                            checksum += (nummer / nummer2);
                        }
                    }
            }
            return checksum;
        }

    }
}
