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
            "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
            "",
            "22 13 17 11  0",
            " 8  2 23  4 24",
            "21  9 14 16  7",
            " 6 10  3 18  5",
            " 1 12 20 15 19",
            "",
            " 3 15  0  2 22",
            " 9 18 13 17  5",
            "19  8  7 25 23",
            "20 11 10 24  4",
            "14 21 16 12  6",
            "",
            "14 21 17 24  4",
            "10 16 15  9 19",
            "18  8 23 26 20",
            "22 11 13  6  5",
            " 2  0 12  3  7",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day04 = new Day04();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(4512, _day04.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(5685, _day04.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(1924, _day04.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(21070, _day04.Part2(Input));
        }
    }
}
