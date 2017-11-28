using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // diagnostics
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // input file, prevents input clutter
            var input = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "../../input01.txt");

            // challenge 1 + 2
            var challenge = new Day01();
            var output1 = challenge.Part1(input);
            var output2 = challenge.Part2(input);

            stopwatch.Stop();

            // make sure some output is there with or without debugging :P
            Console.WriteLine($"Calculation took {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Answer1: {output1}");
            Console.WriteLine($"Answer2: {output2}");

            Debug.WriteLine($"Calculation took {stopwatch.ElapsedMilliseconds} ms");
            Debug.WriteLine($"Answer1: {output1}");
            Debug.WriteLine($"Answer2: {output2}");

            Console.ReadLine();
        }
    }
}
