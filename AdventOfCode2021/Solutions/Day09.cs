using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2021.Solutions
{
    public class Day09
    {
        public int Part1(string[] input)
        {
            var lowest = FindLowPoints(ParseInput(input));

            return lowest.Sum(cell => cell.Value + 1);
        }

        public int Part2(string[] input)
        {
            var map = ParseInput(input);
            var lowPoints = FindLowPoints(map);

            List<Vector2> ExploreBasin(Vector2 point)
            {
                var basin = new List<Vector2> { point };

                Queue<Vector2> toExplore = new();
                toExplore.Enqueue(point);

                while (toExplore.Any())
                {
                    var current = toExplore.Dequeue();
                    
                    var next = GetAdjacent(current)
                        .Where(x => map.ContainsKey(x) && map[x] < 9 && !basin.Contains(x));

                    foreach (var thing in next)
                    {
                        basin.Add(thing);
                        toExplore.Enqueue(thing);
                    }
                }

                return basin;
            }

            return lowPoints.Select(point => ExploreBasin(point.Key))
                .OrderByDescending(x=>x.Count)
                .Take(3)
                .Aggregate(1, (a, b) => a * b.Count);
        }


        private IEnumerable<KeyValuePair<Vector2, int>> FindLowPoints(Dictionary<Vector2, int> map)
        {
            return map.Where(
                cell => GetAdjacent(cell.Key)
                    .Where(map.ContainsKey)
                    .Select(x => map[x])
                    .All(adj => adj > cell.Value));
        }

        private IEnumerable<Vector2> GetAdjacent(Vector2 cell)
        {
            //this syntax is awesome
            return new List<Vector2>
            {
                cell with { Y = cell.Y + 1 },
                cell with { Y = cell.Y - 1 },
                cell with { X = cell.X + 1 },
                cell with { X = cell.X - 1 },
            };
        }

        public Dictionary<Vector2, int> ParseInput(string[] input)
        {
            var map = new Dictionary<Vector2, int>();
            for (var y = 0; y < input.Length; y++)
            {
                for (var x = 0; x < input[y].Length; x++)
                {
                    map.Add(new Vector2(x, y), Convert.ToInt32(input[y][x] + ""));
                }
            }

            return map;
        }
    }
}