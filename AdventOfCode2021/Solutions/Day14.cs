
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Solutions
{
    public class Day14
    {
        public int Part1(string[] input)
        {
            var (polymer, rules) = Parse(input);

            var expanded = Enumerable.Range(1, 10).Aggregate(polymer, (a,_) => ProcessStepManually(a, rules));
            
            var grouped = expanded.GroupBy(x => x).OrderBy(x=>x.Count()).ToArray();
            return grouped.Last().Count() - grouped.First().Count();
            
        }

        public long Part2(string[] input)
        {
            var (polymer, rules) = Parse(input);

            Dictionary<string, long> pairs = new();

            for (var i = 0; i < polymer.Length - 1; i++)
            {
                var pair = $"{polymer[i]}{polymer[i + 1]}";
                pairs[pair] = pairs.GetValueOrDefault(pair) == 0 ? 1 : pairs[pair] + 1;
            }
            
            var count = polymer.GroupBy(x => x).ToDictionary(x => x.Key.ToString(), x => x.LongCount());

            //terse for loop
            var _ = Enumerable.Range(1, 40).Aggregate(pairs, (current, _) => ProcessStep(current, count, rules));
            
            return count.Values.Max() - count.Values.Min();
        }

        protected Dictionary<string, long> ProcessStep(Dictionary<string, long> pairs, Dictionary<string, long> counts, IReadOnlyDictionary<string,string> rules)
        {
            Dictionary<string, long> result = new();

            void AddToLookup(string key, long value, IDictionary<string, long> lookup)
            {
                lookup[key] = lookup.ContainsKey(key) ? lookup[key] + value : value;
            }

            //loop through all the mappings and 'expand' them into the new collection, counting the occurrences as we go.
            foreach (var (key, value) in pairs)
            {
                AddToLookup(rules[key], value, counts);
                AddToLookup($"{key[0]}{rules[key]}", value, result);
                AddToLookup($"{rules[key]}{key[1]}", value, result);
            }

            return result;
        }

        // Q: Who doesn't love the brute force approach? 
        // A: Anyone who needs to do 40 iterations of exponential growth
        private string ProcessStepManually(string polymer, IReadOnlyDictionary<string, string> rules)
        {
            var next = new StringBuilder();
            for (var i = 0; i < polymer.Length - 1; i++)
            {
                var pair = $"{polymer[i]}{polymer[i + 1]}";
                var insert = rules.GetValueOrDefault(pair);

                next.Append(polymer[i]);
                next.Append(insert);
            }
            next.Append(polymer.Last());
            return next.ToString();
        }

        public (string polymer, IReadOnlyDictionary<string, string> rules) Parse(string[] input)
        {
            var polymer = input.Take(1).Single();
            var rules = input.Skip(2).ToDictionary(x => x.Split(" -> ")[0], x => x.Split(" -> ")[1]);

            return (polymer, rules);
        }

    }
}