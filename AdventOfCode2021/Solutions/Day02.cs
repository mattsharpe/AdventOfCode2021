using System;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day02
    {
        public int Part1(string[] input)
        {
            var displacement = input.Select(x =>  (x.Split(' ')[0], int.Parse(x.Split(' ')[1])))
                .GroupBy(x => x.Item1,x=>x.Item2)
                .ToDictionary(x=> x.Key, x=>x.Sum());

            return displacement["forward"] * (displacement["down"] - displacement["up"]);

        }

        public int Part2(string[] input)
        {
            var (x, depth, aim) = (0, 0, 0);
            
            foreach (var instruction in input)
            {
                var split = instruction.Split(' ');
                var value = int.Parse(split[1]);

                switch (split[0])
                {
                    case "forward":
                        x += value;
                        depth += aim * value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    case "down":
                        aim += value;
                        break;
                    default:
                        throw new Exception("Unknown command");
                }
            }

            return x * depth;
        }
    }   
}
