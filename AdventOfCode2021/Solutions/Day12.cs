
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        private int CountPaths(Dictionary<string, List<string>> map, bool part2 = false)
        {

            //This is hte recursive call - defined as an inline method here
            // build a list of the explored path, creating a new copy of exploration so far and pass that into the recursive call.
            IEnumerable<List<string>> ExploreCave(List<string> currentPath)
            {

                //if we made this a dictionary keyed on the cave name with the value as the visit count?


                var currentCave = currentPath.Last();
                var result = new List<List<string>> { currentPath };
                
                //Once we reach the end cave, stop
                if (currentCave == "end")
                {
                    return result;
                }

                var visitLimit = part2 ? 2: 1;

                var visitFrequency = currentPath.Where(x => x.ToLower() == x && x != "start").ToLookup(x=>x);

                //If we've already been to a small cave more than once we're not going into another multiple times
                if (visitFrequency.Any(x=> x.Count() > 1))
                {
                    visitLimit = 1;
                }

                var toExplore = map[currentCave].OrderBy(x=>x).Where(x =>
                    x.ToUpper() == x ||
                    visitFrequency[x].Count() < visitLimit &&
                    x != "start");

                foreach (var cave in toExplore)
                {
                    var next = new List<string>(currentPath) { cave };
                    
                    result.AddRange(ExploreCave(next));
                }
                return result;
            }

            var paths = ExploreCave(new List<string>{ "start" })
                .Where(path => path.Last() == "end");

            return paths.Count();
        }

        


    }
}