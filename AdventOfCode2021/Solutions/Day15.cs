using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Map = System.Collections.Generic.Dictionary<System.Numerics.Vector2, int>;

namespace AdventOfCode2021.Solutions
{
    public class Day15
    {
        public int Part1(string[] input)
        {
            var map = Parse(input);
            
            return FindMinimumRiskPath(map);
        }

        public int Part2(string[] input)
        {
            var smallMap = Parse(input);
            var fullMap = ExpandMap(smallMap);

            return FindMinimumRiskPath(fullMap);
        }

        private Map ExpandMap(Map map)
        {

            var result = new Map();
            
            var width = (int)map.Keys.Max(a => a.X) + 1;
            var height = (int)map.Keys.Max(a => a.Y) + 1;

            foreach (var x in Enumerable.Range(0, width * 5))
            {
                foreach (var y in Enumerable.Range(0, height * 5))
                {
                    var tileY = y % height;
                    var tileX = x % width;
                    var tileRiskLevel = map[new Vector2(tileX, tileY)];

                    var offset = (y / height + x / width) - 1;
                    
                    var riskLevel = (tileRiskLevel + offset) % 9 + 1;
                    result.Add(new Vector2(x,y), riskLevel);
                }
            }
            
            return result;
        }

        private int FindMinimumRiskPath(Map map)
        {
            var start = new Vector2(0, 0);
            var end = new Vector2(map.Keys.Max(a=>a.X), map.Keys.Max(a => a.Y));

            var queue = new PriorityQueue<Vector2, int>();
            var totalRiskMap = new Map
            {
                {start, 0}
            };

            queue.Enqueue(start, 0);

            while (queue.Peek() != end)
            {
                var next = queue.Dequeue();

                foreach (var n in Neighbours(next).Where(map.ContainsKey))
                {
                    var totalRisk = totalRiskMap[next] + map[n];
                    
                    //only bother if this path is lower risk
                    if (totalRisk >= totalRiskMap.GetValueOrDefault(n, int.MaxValue)) continue;

                    totalRiskMap [n] = totalRisk;
                    queue.Enqueue(n, totalRisk);
                }
            }

            return totalRiskMap [end];
        }

        public Map Parse(string[] input)
        {
            var map = new Map();

            for (var y = 0; y < input.Length; y++)
            {
                for (var x = 0; x < input[y].Length; x++)
                {
                    map.Add(new Vector2(x, y), Convert.ToInt32(input[y][x] + ""));
                }
            }
            return map;
        }

        private IEnumerable<Vector2> Neighbours(Vector2 position) =>
            new[]
            {
                position with { X = position.X + 1 },
                position with { X = position.X - 1 },
                position with { Y = position.Y + 1 },
                position with { Y = position.Y - 1 }
            };

    }
    
}