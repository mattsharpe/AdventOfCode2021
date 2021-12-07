using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day07Tests
    {
        private Day07 _day07 = new();
        string Input => File.ReadAllText(@"Input\Day07.txt");

        private string _sample = "16,1,2,0,4,2,7,1,2,14";

        [TestInitialize]
        public void Initialize()
        {
            _day07 = new Day07();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(37, _day07.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(345197, _day07.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(168, _day07.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(96361606, _day07.Part2(Input));
        }
    }
}
