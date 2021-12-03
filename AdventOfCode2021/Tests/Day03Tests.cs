using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day03Tests
    {
        private Day03 _day03 = new();
        string[] Input => File.ReadAllLines(@"Input\Day03.txt");

        private string[] _sample = new string[]
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day03 = new Day03();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(198, _day03.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(3633500, _day03.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(230, _day03.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(4550283, _day03.Part2(Input));
        }
    }
}
