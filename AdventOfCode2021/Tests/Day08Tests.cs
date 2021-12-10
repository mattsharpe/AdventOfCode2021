using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day08Tests
    {
        private Day08 _day08 = new();
        string[] Input => File.ReadAllLines(@"Input\Day08.txt");

        private string[] _sample = new[]
        {
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
            "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
            "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
            "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
            "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
            "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
            "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
            "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
            "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
            "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day08 = new Day08();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(26, _day08.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(387, _day08.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(61229, _day08.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(986034, _day08.Part2(Input));
        }
    }
}
