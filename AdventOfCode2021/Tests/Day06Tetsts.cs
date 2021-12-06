using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day06Tests
    {
        private Day06 _day06 = new();
        string Input => File.ReadAllText(@"Input\Day06.txt");

        private string _sample = "3,4,3,1,2";

        [TestInitialize]
        public void Initialize()
        {
            _day06 = new Day06();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(5934, _day06.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(380612, _day06.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(26984457539, _day06.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(0, _day06.Part2(Input));
        }
    }
}
