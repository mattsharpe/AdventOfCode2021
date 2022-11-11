using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day15Tests
    {
        private Day15 _day15 = new();
        string[] Input => File.ReadAllLines(@"Input\Day15.txt");

        private readonly string[] _sample = 
        {
            "1163751742",
            "1381373672",
            "2136511328",
            "3694931569",
            "7463417111",
            "1319128137",
            "1359912421",
            "3125421639",
            "1293138521",
            "2311944581",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day15 = new Day15();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(40, _day15.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(462, _day15.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(315, _day15.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(2846, _day15.Part2(Input));
        }
    }

}
