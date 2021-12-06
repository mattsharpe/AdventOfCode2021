using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Solutions
{
    public class Day06
    {
        public int Part1(string input)
        {
            var lanternFish = input.Split(',').Select(int.Parse).ToList();
            
            foreach(int i in Enumerable.Range(0, 80))
            {
                ProcessIteration(lanternFish);
            }

            return lanternFish.Count;
        }

        public void ProcessIteration(List<int> fish)
        {
            //Console.WriteLine(string.Join(",", fish));

            for (int i = 0; i < fish.Count; i++)
            {
                fish[i]--;                
            }

            var newFish = fish.Count(x => x == -1);
            //Console.WriteLine(newFish);
            fish.RemoveAll(x => x == -1);
            Enumerable.Range(0, newFish).ToList().ForEach(x =>
            {
                fish.Add(6);
                fish.Add(8);
            });

            //Console.WriteLine(string.Join(",",fish));
        }

        public int Part2(string input)
        {

            //Obviously not. 

            //If we don't need the actual list to be correct can we group them by their counter and then work with that?
            /*
             * [0] = 1
             * 
             * Then each iteration just shuffle the counts around and introduce new ones to [8] when necessary?
             * */
            
            var lanternFish = input.Split(',').Select(int.Parse).ToList();

            foreach (int i in Enumerable.Range(0, 200))
            {
                ProcessIteration(lanternFish);
            }

            return lanternFish.Count;
            //256
        }
    }
}
