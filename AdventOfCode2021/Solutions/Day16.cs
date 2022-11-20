using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day16
    {
        public int Part1(string input)
        {
            var parsed = ParseInput(input);

            return ReadPacket(parsed).AggregateVersion();
        }

        public long Part2(string input)
        {
            var parsed = ParseInput(input);
            var packet = ReadPacket(parsed);
            
            return CalculatePacketValue(packet);
        }

        long CalculatePacketValue(Packet packet)
        {
            long result = 0;
            var values = packet.ChildPackets.Select(CalculatePacketValue);

            switch (packet.Type)
            {
                case 0:
                    return packet.ChildPackets.Sum(CalculatePacketValue);
                    
                case 1:
                    result = 1;
                    foreach (var child in packet.ChildPackets)
                    {
                        result *= CalculatePacketValue(child);
                    }
                    break;
                case 2:
                    return packet.ChildPackets.Min(CalculatePacketValue);
                case 4:
                    return packet.Value;
                case 3:
                    return packet.ChildPackets.Max(CalculatePacketValue);
                case 5:
                    return values.First() > values.Last() ? 1 : 0;
                case 6:
                    return values.First() < values.Last() ? 1 : 0;
                case 7:
                    return values.First() == values.Last() ? 1 : 0;

            }

            return result;
            
        }

        private Parser ParseInput(string input)
        {
            var binaryString = string.Join("", input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            var bits = binaryString.Select(x => int.Parse("" + x)).ToArray();

            return new Parser(bits);
        }

        Packet ReadPacket(Parser parser)
        {
            var version = parser.ReadNumber(3);
            var type = parser.ReadNumber(3);
            var packets = new List<Packet>();
            var value = 0L;
            
            if (type == 4)
            {
                var bits = "";
                //This is a literal, we just need to get the value out by reading the next packets until we hit one that starts with 1
                while (true)
                {
                    var final = parser.ReadNumber(1) == 0;
                    bits += parser.ReadBitString(4);

                    if (!final) continue;
                    value = Convert.ToInt64(bits, 2);
                    break;
                }
            }
            else
            {
                var lengthType = parser.ReadNumber(1);
                if (lengthType == 1)
                {
                    //read the next 11 bits to get the number of packets to read
                    var numberOfPackets = parser.ReadNumber(11);
                    foreach (var x in Enumerable.Range(0, numberOfPackets))
                    {
                        packets.Add(ReadPacket(parser));
                    }
                }
                else
                {
                    // Read the next 15bits 
                    var length = parser.ReadNumber(15);

                    // ths is the number of bits that make up our next packet - get a parser for that.
                    var nestedParser = parser.GetParserForSubPackets(length);

                    while (!nestedParser.Finished)
                    {
                        packets.Add(ReadPacket(nestedParser));
                    }
                }
            }

            var result = new Packet
            {
                Version = version,
                Type = type,
                Value = value,
                ChildPackets = packets.ToArray()
            };
                
            return result;
        }
    }
}

class Packet
{
    public int Version { get; set; }
    public int Type { get; set; }
    public long Value { get; set; }
    public Packet[] ChildPackets { get; set; }

    public int AggregateVersion()
    {
        return Version + ChildPackets.Sum(x => x.AggregateVersion());
    }
}

class Parser
{
    private readonly int[] _bits;
    private int _currentLocation;

    public bool Finished => _currentLocation == _bits.Length;

    public Parser(int[] bits)
    {
        _bits = bits;
    }
    
    public Parser GetParserForSubPackets(int length)
    {
        var result = new Parser(_bits.Skip(_currentLocation).Take(length).ToArray());
        _currentLocation += length;

        return result;
    }

    public int ReadNumber(int length)
    {
        var binaryString = string.Join("", _bits.Skip(_currentLocation).Take(length));
        _currentLocation += length;

        return Convert.ToInt32(binaryString, 2);
    }

    public string ReadBitString(int length)
    {
        var binaryString = string.Join("", _bits.Skip(_currentLocation).Take(length));
        _currentLocation += length;

        return binaryString;
    }
}


