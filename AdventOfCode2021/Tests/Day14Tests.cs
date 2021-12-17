using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day14Tests
    {
        private Day14 _day14 = new();
        string[] Input => File.ReadAllLines(@"Input\Day14.txt");

        private readonly string[] _sample = 
        {
            "NNCB",
            "",
            "CH -> B",
            "HH -> N",
            "CB -> H",
            "NH -> C",
            "HB -> C",
            "HC -> B",
            "HN -> C",
            "NN -> C",
            "BH -> H",
            "NC -> B",
            "NB -> B",
            "BN -> B",
            "BB -> N",
            "BC -> B",
            "CC -> N",
            "CN -> C",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day14 = new Day14();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(1588, _day14.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(2975, _day14.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(2188189693529, _day14.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(3015383850689, _day14.Part2(Input));
        }
    }

}
