using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Solutions
{
    public class Day05
    {
        public int Part1(string[] input)
        {
            var coordinates = ProcessCoordinateRanges(ParseInput(input));

            return coordinates.GroupBy(x => x).Where(x=>x.Count() > 1).Count();
        }

        public int Part2(string[] input)
        {
            var coordinates = ProcessCoordinateRanges(ParseInput(input), true);

            return coordinates.GroupBy(x => x).Where(x => x.Count() > 1).Count();
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

        public List<Vector2> ProcessCoordinateRanges(IEnumerable<CoordinateRange> ranges, bool includeDiagonals = false)
        {
            List<Vector2> coordinates = new();

            foreach(var range in ranges)
            {
                // horizontal
                if(range.X1 == range.X2)
                {
                    for (int y = Math.Min(range.Y1, range.Y2); y <= Math.Max(range.Y1, range.Y2); y++)
                    {
                        coordinates.Add(new Vector2(range.X1, y));
                    }
                }
                // vertical
                else if (range.Y1 == range.Y2)
                {
                    for (int x = Math.Min(range.X1, range.X2); x <= Math.Max(range.X1, range.X2); x++)
                    {
                        coordinates.Add(new Vector2(x, range.Y1));
                    }
                }
                // diagonal
                else if (includeDiagonals)
                {
                    var xOffset = Math.Sign(range.X2 - range.X1);
                    var yOffset = Math.Sign(range.Y2 - range.Y1);

                    for(int x = range.X1, y = range.Y1; x != range.X2 + xOffset; x += xOffset)
                    {
                        coordinates.Add(new Vector2(x, y));
                        y += yOffset;
                    }
                }
            }
            
            return coordinates;
        }
    }

    public record CoordinateRange(int X1, int Y1, int X2, int Y2);
}
