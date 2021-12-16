
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Solutions
{
    public class Day13
    {
        public int Part1(string[] input)
        {
            var (paper, instructions) = Parse(input);

            return Fold(paper, instructions.First()).Count;

        }

        public string Part2(string[] input)
        {
            var (paper, instructions) = Parse(input);
            var result = instructions.Aggregate(paper, Fold);
            
            return Print(result);
        }

        private HashSet<Dot> Fold(HashSet<Dot> dots, Instruction instruction)
        {
            //Even I will admit, this might be a step too far...
            var newDots = dots.Select(dot => instruction.Axis == "y" ? 
                        
                    dot.Y > instruction.Position ? 
                    dot with { Y = 2 * instruction.Position - dot.Y } : 
                    dot 
                :
                    dot.X > instruction.Position ? 
                    dot with { X = 2 * instruction.Position - dot.X } : 
                    dot
                );

            return new HashSet<Dot>(newDots);
        }

        private string Print(HashSet<Dot> dots)
        {
            var maxX = Convert.ToInt32(dots.Max(x => x.X)) + 1;
            var maxY = Convert.ToInt32(dots.Max(x => x.Y)) + 1 ;

            var stringBuilder = new StringBuilder();

            foreach(var y in Enumerable.Range(0,maxY))
            {
                foreach (var x in Enumerable.Range(0, maxX))
                {
                    var dot = dots.Any(dot => dot.X == x && dot.Y == y);
                    stringBuilder.Append(dot ? "#" : " ");
                }

                if(y < maxY-1)
                    stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }



        private (HashSet<Dot> coords, IList<Instruction> instructions) Parse(string[] input)
        {
            var dots = input.TakeWhile(x => !string.IsNullOrEmpty(x)).Select(x =>
            {
                var split = x.Split(',').Select(int.Parse).ToArray();
                return new Dot(split[0], split[1]);
            }).ToHashSet();

            var instructions = input.Skip(dots.Count + 1).Select(x =>
            {
                var split = x[11..].Split('=');
                return new Instruction(split[0], int.Parse(split[1]));
            }).ToList();
           
            return (dots, instructions);
        }
    }

    record Instruction(string Axis, int Position);
    record Dot(int X, int Y);
}