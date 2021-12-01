

using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    internal class Day01
    {
        public int Part1(string[] input)
        {
            var numbers = input.Select(x=> Convert.ToInt32(x)).ToList();
            var linkedList = new LinkedList<int>(numbers);
            var node = linkedList.First;
                        
            var count = 0;

            while(node != null)
            {
                if(node.Next == null)
                {
                    break;
                }

                if(node.Value < node.Next.Value)
                {
                    count++;
                }
                node = node.Next;
            }
            return count;
        }

        internal int Part2(string[] input)
        {
            var numbers = input.Select(x => Convert.ToInt32(x)).ToList();
            var linkedList = new LinkedList<int>(numbers);
            var node = linkedList.First;
                        
            var windows = new LinkedList<int>();

            while (node != null && node.Next!=null && node.Next.Next != null)
            {
                var window = node.Value + node.Next.Value + node.Next.Next.Value;
                windows.AddLast(window);

                node = node.Next;
            }


            node = windows.First;

            var count = 0;

            while (node != null)
            {
                if (node.Next == null)
                {
                    break;
                }

                if (node.Value < node.Next.Value)
                {
                    count++;
                }
                node = node.Next;
            }

            return count;
        }
    }
}
