using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day05Tests
    {
        private Day05 _day05 = new();
        string[] Input => File.ReadAllLines(@"Input\Day05.txt");

        private string[] _sample = new string[]
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day05 = new Day05();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(5, _day05.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(6572, _day05.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(12, _day05.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(21466, _day05.Part2(Input));
        }
    }
}
