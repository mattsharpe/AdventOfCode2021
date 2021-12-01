using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day01Tests
    {
        private Day01 _day01;
        string[] Input => File.ReadAllLines(@"Input\Day01.txt");

        private string[] _sample = new string[]
        {
            "199",
            "200",
            "208",
            "210",
            "200",
            "207",
            "240",
            "269",
            "260",
            "263",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day01 = new Day01();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(7, _day01.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(1655, _day01.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(5, _day01.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(1683, _day01.Part2(Input));
        }
    }
}
