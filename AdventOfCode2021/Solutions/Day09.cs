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
            var map = ParseInput(input);
            
            List<Vector2> GetAdjacent(Vector2 cell)
            {
                //this syntax is awesome
                return new List<Vector2>
                {
                    cell with {Y = cell.Y + 1},
                    cell with {Y = cell.Y - 1},
                    cell with {X = cell.X + 1},
                    cell with {X = cell.X - 1},
                };
            }

            var count = map.Where(
                    cell => GetAdjacent(cell.Key)
                        .Where(map.ContainsKey)
                        .Select(x => map[x])
                        .All(adj => adj > cell.Value))
                .Sum(cell => cell.Value + 1);

            return count;
        }

        public int Part2(string[] input)
        {

            return 0;
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
