using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Solutions
{
    public class Day03
    {
        public int Part1(string[] input)
        {
            var length = input[0].Length;
            var result = new StringBuilder();

            for(int i = 0; i < length; i++)
            {
                var count = input.Count(x => x[i] == '1');
                var bit = count > input.Length / 2;
                result.Append(bit ? '1' : '0');
            }

            var resultInverted = string.Join("", result.ToString().Select(x => x == '0' ? '1' : '0'));
            var gammaRate =  Convert.ToInt32(result.ToString(), 2);
            var epsilonRate = Convert.ToInt32(resultInverted, 2);                     

            return gammaRate * epsilonRate;

        }

        public int Part2(string[] input)
        {
            return 0;
        }
    }   
}
