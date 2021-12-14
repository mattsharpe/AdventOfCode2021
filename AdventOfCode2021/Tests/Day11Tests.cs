using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day11Tests
    {
        private Day11 _day11 = new();
        string[] Input => File.ReadAllLines(@"Input\Day11.txt");

        private readonly string[] _sample = 
        {
            "5483143223",
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day11 = new Day11();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(1656, _day11.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(1608, _day11.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(195, _day11.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(214, _day11.Part2(Input));
        }
    }
}
