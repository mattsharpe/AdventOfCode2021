using System;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day08
    {
        public int Part1(string[] input)
        {
            //Part 1 - piece of cake, count occurences of a string that is either 2,3,4 or 7 long.
            return input.Select(line =>
            {
                return line.Split('|')[1].Split(' ')
                .Count(x => new[] { 2, 3, 4, 7 }.Contains(x.Length));
            }).Sum();
        }

        public int Part2(string[] input)
        {
            // Part 2 - slightly tougher cake...

            // we should be able to apply a sort of filter approach by identifying known letters
            // We know that 1 (cf) is made of ab, and we know that 7 (acf) is made of dab. 
            // Therefore the unknown letter (d) must be the top section of the display ('a')


            return 0;
        }

    }
}
