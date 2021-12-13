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

        public int Part2(string[] input)
        {
            return 0;
        }

        public int CorruptionScore(string line)
        {
            var bracketPairs = new BracketPair[]
            {
                new ('{','}'),
                new ('(',')'),
                new ('[',']'),
                new ('<','>'),
            };
            
            var stack = new Stack<char>();
            foreach (var bracket in line)
            {
                if (bracketPairs.Select(x=>x.Open).ToHashSet().Contains(bracket))
                {
                    stack.Push(bracket);
                    
                }
                else
                {
                    var opener = stack.Pop();
                    var expected = bracketPairs.Single(x => x.Open == opener);
                    if (expected.Close == bracket) continue;

                    Console.WriteLine($"Expected {expected.Close}, but found {bracket} instead");
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


    }

    record BracketPair(char Open, char Close);
}