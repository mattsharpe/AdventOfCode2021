
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

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
            return CountPaths(ParseInput(input), true);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int CountPaths(IReadOnlyDictionary<string, List<string>> map, bool part2 = false)
        {
            //This is hte recursive call - defined as an inline method here
            // build a list of the explored path, creating a new copy of exploration so far and pass that into the recursive call.
            IEnumerable<Dictionary<string, int>> ExploreCave(Dictionary<string, int> visits, string currentCave)
            {
                //if we made this a dictionary keyed on the cave name with the value as the visit count?
                var result = new List<Dictionary<string, int>> { visits };

                var count = visits.GetValueOrDefault(currentCave);
                visits[currentCave] = ++count;

                //Once we reach the end cave, stop
                if (currentCave == "end")
                {
                    //Console.WriteLine();
                    return result;
                }
                
                //If we've already been to a small cave more than once we're not going into another multiple times
                var visitLimit = visits.Any(x => x.Key.ToLower() == x.Key && x.Value > 1) || !part2 ? 1 : 2;

                var toExplore = map[currentCave].Where(x =>
                    x.ToUpper() == x ||
                    visits.GetValueOrDefault(x) < visitLimit &&
                    x != "start");

                foreach (var cave in toExplore)
                {
                    var next = new Dictionary<string, int>(visits);
                    var child = ExploreCave(next, cave);
                    result.AddRange(child);
                }

                return result;
            }

            var paths = ExploreCave(new Dictionary<string, int>(), "start")
                .Where(x=>x.ContainsKey("end"));

            return paths.Count();
        }
    }
}