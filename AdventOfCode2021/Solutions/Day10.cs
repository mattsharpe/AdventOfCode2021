using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day10
    {
        public int Part1(string[] input)
        {
            return input.Sum(CorruptionScore);
        }

        public long Part2(string[] input)
        {
            var counts = input.Where(x => CorruptionScore(x) == 0).Select(Result).OrderBy(x=>x).ToArray();
            var result = counts.ElementAt(counts.Length / 2);

            return result;
        }

        private long Result(string line)
        {
            var stack = new Stack<char>();
            foreach (var bracket in line)
            {
                if (BracketPairs.Select(x => x.Open).ToHashSet().Contains(bracket))
                {
                    stack.Push(bracket);
                }
                else
                {
                    stack.Pop();
                }
            }

            var missing = string.Join("", stack.Select(x => BracketPairs.Single(pair => pair.Open == x).Close));

            var result = missing.Aggregate(0L, (total, current) =>
            {
                total *= 5;
                total += current switch
                {
                    ')' => 1,
                    ']' => 2,
                    '}' => 3,
                    '>' => 4,
                    _ => throw new NotImplementedException()
                };
                return total;
            });

            return result;
        }

        public int CorruptionScore(string line)
        {
            var stack = new Stack<char>();
            foreach (var bracket in line)
            {
                if (BracketPairs.Select(x=>x.Open).ToHashSet().Contains(bracket))
                {
                    stack.Push(bracket);
                }
                else
                {
                    var opener = stack.Pop();
                    var expected = BracketPairs.Single(x => x.Open == opener);
                    if (expected.Close == bracket) continue;

                    return bracket switch
                    {
                        ')' => 3,
                        ']' => 57,
                        '}' => 1197,
                        '>' => 25137,
                        _ => 0
                    };
                }
            }

            return 0;
        }

        public BracketPair[] BracketPairs =>
            new BracketPair[]
            {
                new('{', '}'),
                new('(', ')'),
                new('[', ']'),
                new('<', '>'),
            };
    }

    public record BracketPair(char Open, char Close);
}