using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2021.Solutions
{
    public class Day11
    {
        public int Part1(string[] input)
        {
            var map = ParseInput(input);
            return Enumerable.Range(1, 100).Sum(_ => RunStep(map));
        }

        public long Part2(string[] input)
        {
            var map = ParseInput(input);

            var count = 0;
            while (map.Any(x => x.Value != 0))
            {
                RunStep(map);
                count++;
            }

            return count;
        }

        public int RunStep(Dictionary<Vector2, int> map)
        {

            var flashers = new Queue<Vector2>();

            void IncrementTheOctopus(IEnumerable<Vector2> keys)
            {
                foreach (var key in keys)
                {
                    map[key]++;
                    if (map[key] == 10)
                    {
                        flashers.Enqueue(key);
                    }
                }
            }

            //First, the energy level of each octopus increases by 1.
            IncrementTheOctopus(map.Keys);

            //Then, any octopus with an energy level greater than 9 flashes.
            //This increases the energy level of all adjacent octopuses by 1, including octopuses that are diagonally adjacent.
            //If this causes an octopus to have an energy level greater than 9, it also flashes.
            //This process continues as long as new octopuses keep having their energy level increased beyond 9.
            //(An octopus can only flash at most once per step.)
            var flashed = new HashSet<Vector2>();
            while (flashers.Any())
            {
                var current = flashers.Dequeue();
                flashed.Add(current);
                var adjacent = GetAdjacent(current).Where(x => map.ContainsKey(x) && !flashed.Contains(x));
                IncrementTheOctopus(adjacent);
            }

            //Finally, any octopus that flashed during this step has its energy level set to 0, as it used all of its energy to flash.
            foreach (var key in flashed)
            {
                map[key] = 0;
            }

            return flashed.Count;
        }

        public IEnumerable<Vector2> GetAdjacent(Vector2 cell)
        {
            Vector2 Transform(Vector2 input, float x, float y) => input with { X = input.X += x, Y = input.Y += y };
            
            var transforms = new Vector2[]
            {
                new(-1, 1), new(0, 1), new(1, 1),
                new(-1, 0), new(1, 0),
                new(-1,-1), new(0, -1), new(1, -1)
            };

            return transforms.Select(x => Transform(cell, x.X, x.Y));
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