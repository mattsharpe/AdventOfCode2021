using System.IO;
using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021.Tests
{
    [TestClass]
    public class Day17Tests
    {
        private Day17 _day17 = new();
        string Input => File.ReadAllText(@"Input\Day17.txt");
        private string _sample = "target area: x=20..30, y=-10..-5";


        [TestInitialize]
        public void Initialize()
        {
            _day17 = new Day17();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(45, _day17.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(8646, _day17.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(112, _day17.Part2(_sample));
        }


        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(5945, _day17.Part2(Input));
        }

    }
}
