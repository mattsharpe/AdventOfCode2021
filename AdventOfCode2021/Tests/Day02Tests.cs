using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day02Tests
    {
        private Day02 _day02 = new();
        string[] Input => File.ReadAllLines(@"Input\Day02.txt");

        private string[] _sample = new string[]
        {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day02 = new Day02();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(150, _day02.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(2102357, _day02.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(900, _day02.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(2101031224, _day02.Part2(Input));
        }
    }
}
