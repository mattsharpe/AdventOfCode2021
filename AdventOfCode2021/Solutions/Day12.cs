
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day12
    {
        public long Part1(string[] input)
        {
            var graph = ParseInput(input);
            return CountPaths(graph);

        }
        public long Part2(string[] input)
        {
            return 0;
        }

        //must be a way to do this more nicely with linq?
        private Dictionary<string, List<string>> ParseInput(string[] input)
        {
            var result = new Dictionary<string, List<string>>();
            
            foreach (var line in input)
            {
                var split = line.Split('-');

                var left = result.GetValueOrDefault(split[0]) ?? new List<string>();
                var right = result.GetValueOrDefault(split[1]) ?? new List<string>();

                left.Add(split[1]);
                right.Add(split[0]);

                result[split[0]] = left;
                result[split[1]] = right;
                
            }

            return result;
        }

        private int CountPaths(Dictionary<string, List<string>> map)
        {
            //This is hte recursive call - defined as an inline method here
            IEnumerable<List<string>> ExploreCave(List<string> currentPath, IReadOnlySet<string> visitedCaves)
            {
                var currentCave = currentPath.Last();
                var result = new List<List<string>> { currentPath };
                
                //Once we reach the end cave, stop
                if (currentCave == "end")
                {
                    return result;
                }

                foreach (var cave in map[currentCave].Where(x => x.All(char.IsUpper) || !visitedCaves.Contains(x)))
                {
                    var next = new List<string>(currentPath) { cave };
                    var visited = new HashSet<string>(visitedCaves) { cave };
                    
                    result.AddRange(ExploreCave(next, visited));
                }
                return result;
            }

            var start = new[] { "start" };
            var paths = ExploreCave(start.ToList(), start.ToHashSet())
                .Where(path => path.Last() == "end");

            return paths.Count();
        }

        


    }
}