using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Solutions
{
    public class Day05
    {
        public int Part1(string[] input)
        {
            var ranges = ParseInput(input).ToArray();

            var max = input.SelectMany(x=> Regex.Matches(x, @"\d+").Select(x=> int.Parse(x.Value))).Max();

            var maxX = ranges.Select(x => x.x1).Union(ranges.Select(x => x.x2)).Max();
            var maxY = ranges.Select(x => x.y1).Union(ranges.Select(x => x.y2)).Max();

            Console.WriteLine(max + ": " + maxX + "," + maxY);
            return 0;
        }

        public int Part2(string[] input)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CoordinateRange> ParseInput(string[] input)
        {
            var regex = new Regex(@"(\d+),(\d+) -> (\d+),(\d+)");
            foreach(var line in input)
            {
                var groups = regex.Matches(line)[0].Groups;
                yield return new CoordinateRange(
                    int.Parse(groups[1].Value),
                    int.Parse(groups[2].Value),
                    int.Parse(groups[3].Value),
                    int.Parse(groups[4].Value)
                    );
            }
        }


    }

    public record CoordinateRange(int x1, int y1, int x2, int y2);
}
