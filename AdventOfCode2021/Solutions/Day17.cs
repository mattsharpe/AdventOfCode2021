using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Solutions
{
    public class Day17
    {

        public int Part1(string input)
        {
            var range = Parse(input);

            return MaxAltitudes(range).Max();
        }


        public int Part2(string input)
        {
            var range = Parse(input);

            return MaxAltitudes(range).Count();
        }

        private IEnumerable<int> MaxAltitudes(TargetRange range)
        {
            for (var x = 0; x <= range.MaxX; x++)
            {
                for (var y = range.MinY; y <= Math.Abs(range.MinY); y++)
                {
                    var state = new ProbeState(0, 0, x, y);
                    var maxY = 0;

                    //while we're still approaching the target
                    while (state.LocationX <= range.MaxX && state.LocationY >= range.MinY)
                    {
                        state = Move(state);
                        maxY = Math.Max(maxY, state.LocationY);

                        //if we're still approaching the target then continue
                        if (state.LocationX < range.MinX || state.LocationX > range.MaxX ||
                            state.LocationY < range.MinY || state.LocationY > range.MaxY) continue;

                        yield return maxY;
                        break;
                    }
                }
            }

        }
        

        private ProbeState Move(ProbeState state)
        {
            var nextX = state.LocationX + state.VelocityX;
            var nextY = state.LocationY + state.VelocityY;
            var nextVelocityX = Math.Max(0, state.VelocityX - 1);
            var nextVelocityY = state.VelocityY - 1;

            return new ProbeState(nextX, nextY, nextVelocityX, nextVelocityY);
        }

        private TargetRange Parse(string input)
        {
            var regex = new Regex(@"x=(-?\d+)..(-?\d+), y=(-?\d+)..(-?\d+)");
            var groups = regex.Match(input).Groups;

            return new TargetRange(
                Convert.ToInt32(groups[1].Value),
                Convert.ToInt32(groups[2].Value),
                Convert.ToInt32(groups[3].Value),
                Convert.ToInt32(groups[4].Value)
            );
        }
    }
    record TargetRange(int MinX, int MaxX, int MinY, int MaxY);
    record ProbeState(int LocationX, int LocationY, int VelocityX, int VelocityY);
}
