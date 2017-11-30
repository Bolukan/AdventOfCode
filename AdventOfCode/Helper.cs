using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    
    public class Helper
    {
        public static string[] SplitOnComma(string input)
        {
            return input.Split(new string[] { ", " }, StringSplitOptions.None);
        }
    }
}
