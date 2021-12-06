using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day06
    {
        public long Part1(string input)
        {
            var fish = ParseInput(input);

            SimulateDays(fish, 80);

            return fish.Sum();
        }


        public long Part2(string input)
        {
            var fish = ParseInput(input);

            SimulateDays(fish, 256);

            return fish.Sum();
            
        }

        public void SimulateDays(long[] fish, int days)
        {
            foreach (var _ in Enumerable.Range(0, days))
            {
                ProcessIteration(fish);
            }
        }

        public long[] ParseInput(string input)
        {
            var lanternFish = input.Split(',').Select(long.Parse).ToList();
            long[] fish = new long[9];

            var lookup = lanternFish.GroupBy(x => x);
            foreach (var item in lookup)
            {
                fish[item.Key] = item.Count();
            }

            return fish;
        }        

        public void ProcessIteration(long[] fish)
        {
            //put in temp array to avoid royally fucking things up as you go.
            var temp = new long[9];
            for (var i = 0; i < fish.Length; i++)
            {
                if(i == 0)
                {
                    temp[8] = fish[0];
                    temp[6] += fish[0];
                } 
                else
                {
                    temp[i - 1] += fish[i];
                }
            }
            temp.CopyTo(fish, 0);
        }
    }
}
