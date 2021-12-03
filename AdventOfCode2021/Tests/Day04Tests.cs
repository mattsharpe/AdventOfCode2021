using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day04Tests
    {
        private Day04 _day04 = new();
        string[] Input => File.ReadAllLines(@"Input\Day04.txt");

        private string[] _sample = new string[]
        {
        };

        [TestInitialize]
        public void Initialize()
        {
            _day04 = new Day04();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(0, _day04.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(0, _day04.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(0, _day04.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(0, _day04.Part2(Input));
        }
    }
}
