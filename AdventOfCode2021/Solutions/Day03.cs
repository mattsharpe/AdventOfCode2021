using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Solutions
{
    public class Day03
    {
        public int Part1(string[] input)
        {
            var result = ProcessList(new List<string>(input));

            var resultInverted = Invert(result);
            var gammaRate =  Convert.ToInt32(result.ToString(), 2);
            var epsilonRate = Convert.ToInt32(resultInverted, 2);                     

            return gammaRate * epsilonRate;
        }

        public string ProcessList(List<string> list)
        {
            var result = new StringBuilder();

            for (int i = 0; i < list[0].Length; i++)
            {
                var count = list.Count(x => x[i] == '1');
                var bit = 2 * count >= list.Count;
                result.Append(bit ? '1' : '0');
            }

            return result.ToString();
        }

        public string Invert(string bits)
        {
            return string.Join("", bits.ToString().Select(x => x == '0' ? '1' : '0'));
        }

        public int FilterList(List<string> list, bool inverted = false)
        {
            var count = list.Count();
            for (int i = 0; i < count; i++)
            {
                var most = inverted ? Invert(ProcessList(list)) : ProcessList(list);
                list.RemoveAll(x => x[i] != most[i]);
                if (list.Count == 1) break;
            }

            return Convert.ToInt32(list.Single().ToString(), 2);
        }

        public int Part2(string[] input)
        {
            var co2GeneratorRating = FilterList(new List<string>(input));
            var co2ScrubberRating = FilterList(new List<string>(input), true);

            return co2GeneratorRating * co2ScrubberRating;
        }
    }   
}
