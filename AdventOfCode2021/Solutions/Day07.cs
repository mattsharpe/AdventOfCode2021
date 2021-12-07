using System;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day07
    {
        public int Part1(string input)
        {
            var positions = input.Split(',').Select(int.Parse).ToList(); 
            return Enumerable.Range(positions.Min(), positions.Max()).
                Min(x => positions.Select(pos => Math.Abs(pos - x)).Sum());
        }

        public int Part2(string input)
        {
            // Calculate the sum of a linear progression using the formula
            // n/2 * (2a + (n − 1) * d)
            // (with some simplifications as d = a = 1)

            var positions = input.Split(',').Select(int.Parse).ToList();
            return Enumerable.Range(positions.Min(), positions.Max()).
                Min(x => positions.Select(pos => {  
                    var n = Math.Abs(pos - x);
                    return Convert.ToInt32(n * 0.5 * (1 + n));
                }).Sum());
        }
    }
}
