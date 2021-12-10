using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

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
            
            return input.Sum(SolveLine);            
        }

        public int SolveLine(string input)
        {
            var split = input.Split('|');

            // There are a couple of ways to approach this;
            //  - We can count the frequency of the segments in the input and deduce a few mappings from unique frequencies
            //  - Starting from the known digits we can use for instance take the edges for '7' and remove '1' to get the top edge and then proceed from there
            //  - This approach is similar but applies the method to entire digits by counting the unique number of intersections with known numbers

            var patterns = split[0].Split(' ').ToArray();
         
            //this is dictionary of words to the digit they represent on the display, e.g. ab => 1
            var digitLookup = new Dictionary<int, string>
            {
                [1] = patterns.Single(x => x.Length == 2),
                [4] = patterns.Single(x => x.Length == 4),
                [7] = patterns.Single(x => x.Length == 3),
                [8] = patterns.Single(x => x.Length == 7)
            };

            digitLookup[3] = patterns.Single(x => x.Length == 5 && x.Intersect(digitLookup[1]).Count() == 2);
            digitLookup[9] = patterns.Single(x => x.Length == 6 && x.Intersect(digitLookup[3]).Count() == 5);

            digitLookup[0] = patterns.Single(x => x.Length == 6 && x != digitLookup[9] && x.Intersect(digitLookup[1]).Count() == 2);
            digitLookup[6] = patterns.Single(x=>x.Length == 6 && !digitLookup.ContainsValue(x));

            digitLookup[5] = patterns.Single(x => x.Length == 5 && !digitLookup.ContainsValue(x) && x.Intersect(digitLookup[9]).Count() == 5);
            digitLookup[2] = patterns.Single(x => x.Length == 5 && !digitLookup.ContainsValue(x));


            var thing = split[1].Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(new StringBuilder(),
                    (sb, value) =>
                        sb.Append(digitLookup.Single(x => value.ToHashSet().SetEquals(x.Value.ToHashSet())).Key))
                .ToString();


            return Convert.ToInt32(thing);
        }

    }
}
