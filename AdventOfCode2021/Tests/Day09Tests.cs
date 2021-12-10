using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day09Tests
    {
        private Day09 _day09 = new();
        string[] Input => File.ReadAllLines(@"Input\Day09.txt");

        private string[] _sample = 
        {
            "2199943210",
            "3987894921",
            "9856789892",
            "8767896789",
            "9899965678",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day09 = new Day09();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(15, _day09.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(475, _day09.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(0, _day09.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(0, _day09.Part2(Input));
        }
    }
}
