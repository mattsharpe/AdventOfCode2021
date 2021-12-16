using System;
using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day13Tests
    {
        private Day13 _day13 = new();
        string[] Input => File.ReadAllLines(@"Input\Day13.txt");

        private readonly string[] _sample = 
        {
            "6,10",
            "0,14",
            "9,10",
            "0,3",
            "10,4",
            "4,11",
            "6,0",
            "6,12",
            "4,1",
            "0,13",
            "10,12",
            "3,4",
            "3,0",
            "8,4",
            "1,10",
            "2,14",
            "8,10",
            "9,0",
            "",
            "fold along y=7",
            "fold along x=5",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day13 = new Day13();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(17, _day13.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(810, _day13.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            var array = new[]
            {
                "#####",
                "#   #",
                "#   #",
                "#   #",
                "#####"
            };
            var expected = string.Join(Environment.NewLine, array);

            Assert.AreEqual(expected, _day13.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            var array = new[]
            {
                "#  # #    ###  #  # ###   ##  #### ### ",
                "#  # #    #  # #  # #  # #  # #    #  #",
                "#### #    ###  #  # ###  #    ###  #  #",
                "#  # #    #  # #  # #  # # ## #    ### ",
                "#  # #    #  # #  # #  # #  # #    # # ",
                "#  # #### ###   ##  ###   ### #    #  #"
            };
            var expected = string.Join(Environment.NewLine, array);
            Assert.AreEqual(expected, _day13.Part2(Input));
        }
    }

}
