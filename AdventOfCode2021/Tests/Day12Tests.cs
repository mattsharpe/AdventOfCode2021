using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day12Tests
    {
        private Day12 _day12 = new();
        string[] Input => File.ReadAllLines(@"Input\Day12.txt");

        private readonly string[] _sample = 
        {
            "start-A",
            "start-b",
            "A-c",
            "A-b",
            "b-d",
            "A-end",
            "b-end",
        };

        private readonly string[] _sample2 =
        {
            "dc-end",
            "HN-start",
            "start-kj",
            "dc-start",
            "dc-HN",
            "LN-dc",
            "HN-end",
            "kj-sa",
            "kj-HN",
            "kj-dc",
        };

        private readonly string[] _sample3 =
        {
            "fs-end",
            "he-DX",
            "fs-he",
            "start-DX",
            "pj-DX",
            "end-zg",
            "zg-sl",
            "zg-pj",
            "pj-he",
            "RW-he",
            "fs-DX",
            "pj-RW",
            "zg-RW",
            "start-pj",
            "he-WI",
            "zg-he",
            "pj-fs",
            "start-RW",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day12 = new Day12();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(10, _day12.Part1(_sample));
        }

        [TestMethod]
        public void Part1_Sample2()
        {
            Assert.AreEqual(19, _day12.Part1(_sample2));
        }

        [TestMethod]
        public void Part1_Sample3()
        {
            Assert.AreEqual(226, _day12.Part1(_sample3));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(4792, _day12.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(36, _day12.Part2(_sample));
        }

        [TestMethod]
        public void Part2_Sample2()
        {
            Assert.AreEqual(103, _day12.Part2(_sample2));
        }

        [TestMethod]
        public void Part2_Sample3()
        {
            Assert.AreEqual(3509, _day12.Part2(_sample3));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(133360, _day12.Part2(Input));
        }
    }

}
