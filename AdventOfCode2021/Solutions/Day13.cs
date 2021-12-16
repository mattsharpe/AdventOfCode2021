
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2021.Solutions
{
    public class Day13
    {
        public long Part1(string[] input)
        {
            var (paper, instructions) = Parse(input);

            return Fold(paper, instructions.First()).Count;

        }

        public long Part2(string[] input)
        {
            var (paper, instructions) = Parse(input);
            foreach (var instruction in instructions)
            {
                paper = Fold(paper, instruction);
            }

            Print(paper);
            return 0;
        }

        public HashSet<Vector2> Fold(HashSet<Vector2> dots, Instruction instruction)
        {

            var result = new HashSet<Vector2>();
            foreach (var dot in dots)
            {

                if (instruction.Axis == "y")
                {
                    if (dot.Y > instruction.Position)
                    {
                        result.Add(dot with { Y = 2 * instruction.Position - dot.Y });
                    }
                    else
                    {
                        result.Add(dot);
                    }
                }
                else
                {
                    if (dot.X > instruction.Position)
                    {
                        result.Add(dot with { X = 2 * instruction.Position - dot.X });
                    }
                    else
                    {
                        result.Add(dot);
                    }
                }
            }

            return result;
        }

        private void Print(HashSet<Vector2> dots)
        {
            var maxX = Convert.ToInt32(dots.Max(x => x.X)) + 1;
            var maxY = Convert.ToInt32(dots.Max(x => x.Y)) +1 ;
            Console.WriteLine(maxX);
            Console.WriteLine(maxY);

            foreach(var y in Enumerable.Range(0,maxY))
            {
                foreach (var x in Enumerable.Range(0, maxX))
                {
                    var dot = dots.Any(dot => dot.X == x && dot.Y == y);
                    Console.Write(dot ? "#" : " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }



        public (HashSet<Vector2> coords, IList<Instruction> instructions) Parse(string[] input)
        {
            var dots = input.TakeWhile(x => !string.IsNullOrEmpty(x)).Select(x =>
            {
                var split = x.Split(',').Select(int.Parse).ToArray();
                return new Vector2(split[0], split[1]);
            }).ToHashSet();

            var instructions = input.Skip(dots.Count + 1).Select(x =>
            {
                var split = x[11..].Split('=');
                return new Instruction(split[0], int.Parse(split[1]));
            }).ToList();
           
            return (dots, instructions);
        }
    }

    public record Instruction(string Axis, int Position);
}