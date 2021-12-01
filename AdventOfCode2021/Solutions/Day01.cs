using System;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day01
    {
        public int Part1(string[] input)
        {
            var numbers = input.Select(x => Convert.ToInt32(x)).ToList();

            return numbers.Zip(numbers.Skip(1), (a, b) => b > a).Count(x => x == true);

        }

        public int Part2(string[] input)
        {
            var numbers = input.Select(x => Convert.ToInt32(x)).ToList();

            var windows = numbers.Zip(numbers.Skip(1), (a, b) => a + b)
                .Zip(numbers.Skip(2), (a, b) => a + b);

            return windows.Zip(windows.Skip(1), (a, b) => b > a).Count(x => x == true);
        }      
    }
}
