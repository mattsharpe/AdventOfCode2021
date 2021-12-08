using System;
using System.Linq;
using System.Collections.Generic;

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

            /*
             * Part 2 - slightly tougher cake...

             * This is the logical deductions I worked through to figure it out, put into (quite messy!) code
             * We should be able to apply a sort of filter approach by identifying known letters
             * We know that 1 (cf) is made of ab, and we know that 7 (acf) is made of dab. 
             * Therefore the unknown letter (d) must be the top section of the display ('a')

                
                acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf

                 0:      1:      2:      3:      4:
                 aaaa    ....    aaaa    aaaa    ....
                b    c  .    c  .    c  .    c  b    c
                b    c  .    c  .    c  .    c  b    c
                 ....    ....    dddd    dddd    dddd
                e    f  .    f  e    .  .    f  .    f
                e    f  .    f  e    .  .    f  .    f
                 gggg    ....    gggg    gggg    ....

                  5:      6:      7:      8:      9:
                 aaaa    aaaa    aaaa    aaaa    aaaa
                b    .  b    .  .    c  b    c  b    c
                b    .  b    .  .    c  b    c  b    c
                 dddd    dddd    ....    dddd    dddd
                .    f  e    f  .    f  e    f  .    f
                .    f  e    f  .    f  e    f  .    f
                 gggg    gggg    ....    gggg    gggg
             */

            // 1, 4, 7, 8 are uniquely identifiable with the number of segments lit up
            // 2, 4, 3, 7

            //we start with what we know and elimate

            // *segment a* = L3 - L2
            // 4 (count4) without 1(count3) = (b|d) top-left and middle
            // the count 6 without both of these must be 0 (missing middle), d = missing
            // *segment b* = (count 5) missing top-left and middle
            // *segment c* = 
            // *segment d* = edge of top left missing from top 6
            // e = L7 - L4 (remainder)

            

            SolveLine(input[0]);
            return 0;
            
        }

        public int SolveLine(string input)
        {
            var data = input.Split('|')[0].Trim().Split(' ')
                    .Select(x => new string(x.OrderBy(x => x).ToArray()))
                    .OrderBy(x => x.Length);

            var lookup = new Dictionary<string, int>();

            lookup[data.Single(x => x.Length == 2)] = 1;
            lookup[data.Single(x => x.Length == 4)] = 4;
            lookup[data.Single(x => x.Length == 3)] = 7;
            lookup[data.Single(x => x.Length == 7)] = 8;

            var overlap = data.GroupBy(x=>x.Length)
                .ToDictionary(x => x.Key, x => string.Join("",x.SelectMany(y => y).Distinct().ToArray()));
            

            string aWithoutB(string a, string b)
            {
                return new string(a.Except(b).ToArray());
            }

            string aWithoutAllB(string a, string[] b)
            {
                var result = a;

                foreach (var other in b)
                {
                    a = aWithoutB(a, other);
                }
                
                return result;
            }

            return 0;
        }

    }
}
