using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day10Tests
    {
        private Day10 _day10 = new();
        string[] Input => File.ReadAllLines(@"Input\Day10.txt");

        private string[] _sample = 
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}",
            "[[<[([]))<([[{}[[()]]]",
            "[{[{({}]{}}([{[{{{}}([]",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "[<(<(<(<{}))><([]([]()",
            "<{([([[(<>()){}]>(<<{{",
            "<{([{{}}[<[[[<>{}]]]>[]]",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day10 = new Day10();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(26397, _day10.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(0, _day10.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(0, _day10.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(0, _day10.Part2(Input));
        }
    }
}
