using System;
using AdventOfCode2021.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Tests
{
 
    [TestClass]
    public class Day16Tests
    {
        private Day16 _day16 = new();
        string Input => File.ReadAllText(@"Input\Day16.txt");



        [TestInitialize]
        public void Initialize()
        {
            _day16 = new Day16();
        }

        [DataTestMethod]
        [DataRow("D2FE28", 6)]
        [DataRow("8A004A801A8002F478",16)]
        [DataRow("620080001611562C8802118E34", 12)]
        [DataRow("C0015000016115A2E0802F182340", 23)]
        [DataRow("A0016C880162017C3686B18A3D4780", 31)]
        public void Part1_Sample(string input, int expected)
        {
            Assert.AreEqual(expected, _day16.Part1(input));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(949, _day16.Part1(Input));
        }

        [DataTestMethod]
        [DataRow("C200B40A82", 3)]
        [DataRow("04005AC33890", 54)]
        [DataRow("880086C3E88112", 7)]
        [DataRow("CE00C43D881120", 9)]
        [DataRow("D8005AC2A8F0", 1)]
        [DataRow("F600BC2D8F", 0)]
        [DataRow("9C005AC2F8F0", 0)]
        [DataRow("9C0141080250320F1802104A08", 1)]
        public void Part2_Sample(string input, int expected)
        {
            Assert.AreEqual(expected, _day16.Part2(input));
        }


        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(1114600142730, _day16.Part2(Input));
        }
    }

}
