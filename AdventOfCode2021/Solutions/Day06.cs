using System.Collections.Generic;
using System.Linq;

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

            for (int i = 0; i < fish.Count; i++)
            {
                fish[i]--;                
            }

            var newFish = fish.Count(x => x == -1);
            fish.RemoveAll(x => x == -1);

            Enumerable.Range(0, newFish).ToList().ForEach(x =>
            {
                fish.Add(6);
                fish.Add(8);
            });

        }

        public long Part2(string input)
        {
            var lanternFish = input.Split(',').Select(long.Parse).ToList();
            long[] fish = new long[9];

            var lookup = lanternFish.GroupBy(x => x);
            foreach (var item in lookup)
            {
                fish[item.Key] = item.Count();
            }

            foreach (int i in Enumerable.Range(0, 256))
            {
                ProcessIteration(fish);
            }

            return fish.Sum();
            
        }

        public void ProcessIteration(long[] fish)
        {
            //put in temp array to avoid royally fucking things up as you go.
            var temp = new long[9];
            for (int i = fish.Length - 1; i >= 0; i--)
            {
                switch (i)
                {
                    case 0:
                        temp[8] = fish[0];
                        temp[6] += fish[0];
                        break;
                    default:
                        temp[i - 1] += fish[i];
                        break;
                }

            }
            temp.CopyTo(fish, 0);
        }
    }
}
