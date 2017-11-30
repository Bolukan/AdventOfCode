using AdventOfCode;
using System;
using System.Collections.Generic;

namespace AdventOfCode2016
{
    public class Day201623 : IDay
    {
        public string InputFile { get { return "input.txt"; } }

        int[] register = new int[4] { 0, 0, 0, 0 };
        string[] instructions = new string[5] { "inc", "dec", "tgl", "jnz", "cpy" };
        string[] instructionstoggled = new string[5] { "dec", "inc", "inc", "cpy", "jnz" };

        string[][] commands;

        private int FindRegister(string argument)
        {
            switch (argument)
            {
                case "a":
                    return 0;
                case "b":
                    return 1;
                case "c":
                    return 2;
                case "d":
                    return 3;
                default:
                    return -1;
            }
        }

        private string ToggleCommand(string command)
        {
            switch(command)
            {
                case "inc": return "dec";
                case "dec": return "inc";
                case "tgl": return "inc";
                case "jnz": return "cpy";
                case "cpy": return "jnz";
                default: throw new IndexOutOfRangeException();
            }
        }
        private void tgl(string argument1, int pointer)
        {
            int register1 = FindRegister(argument1);
            int pointer2 = pointer + ((register1 == -1) ? int.Parse(argument1) : register[register1]);
            if ((pointer2 < 0) || (pointer2 >= commands.Length)) return;
            commands[pointer2][0] = ToggleCommand(commands[pointer2][0]);
        }
        
        private void inc(string argument1)
        {
            int register1 = FindRegister(argument1);
            if (register1 > -1) register[register1]++;
        }

        private void dec(string argument1)
        {
            int register1 = FindRegister(argument1);
            if (register1 > -1) register[register1]--;
        }

        private void cpy(string argument1, string argument2)
        {
            int register2 = FindRegister(argument2);
            if (register2 > -1)
            {
                int register1 = FindRegister(argument1);
                register[register2] = (register1 == -1) ? int.Parse(argument1) : register[register1];
            }
        }

        private int jnz(string argument1, string argument2, int pointer)
        {
            int register1 = FindRegister(argument1);
            if (((register1 == -1) ? int.Parse(argument1) : register[register1]) == 0)
            {
                return pointer + 1;
            }

            int register2 = FindRegister(argument2);
            return pointer + ((register2 == -1) ? int.Parse(argument2) : register[register2]);
        }

        public int Part1(string[] input)
        {
            return 0;
        }

        public int Part1(string[] input, int a)
        {
            register[0] = a;
            commands = new string[input.Length][];
            for(int line=0; line < input.Length; line++ )
            {
                commands[line] = input[line].Split(' ');
            }
            int counter = 0;
            int pointer = 0;
            string signal = "";
            while (pointer < input.Length && counter < 12)
            {
                //if (pointer == 26)
                //{
                //    Console.WriteLine(a.ToString()+": "+register[0].ToString()+" "+register[1].ToString()+" "+register[2].ToString()+" "+register[3].ToString());
                //    return register[0];
               // }
                switch(commands[pointer][0])
                {
                    case "inc": inc(commands[pointer][1]); pointer++; break;
                    case "dec": dec(commands[pointer][1]); pointer++; break;
                    case "tgl": tgl(commands[pointer][1], pointer); pointer++; break;
                    case "cpy": cpy(commands[pointer][1], commands[pointer][2]); pointer++; break;
                    case "jnz": pointer = jnz(commands[pointer][1], commands[pointer][2], pointer); break;
                    case "out": Console.Write(register[1].ToString()); pointer++; counter++; signal += register[1].ToString(); break;
                }
            }
            Console.WriteLine();
            if (signal == "010101010101" || signal == "101010101010")
            {
                Console.WriteLine(a.ToString());

            }
            return register[0];
        }

        public int Part2(string[] input)
        {
            return 0;
        }
    }
}
