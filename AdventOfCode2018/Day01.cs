using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    class Day01
    {
        List<string> Input;
        List<int> IntList;

        public const int Part1Answer = 502;
        public const int Part2Answer = 71961;

        public Day01()
        {
            Input = System.IO.File.ReadAllLines("day01-input.txt").ToList();
            IntList = Input.Select(int.Parse).ToList();
        }
        
        public int Part1()
        {
            return IntList.Sum();
        }

        public int Part2()
        {
            int currentFreq = 0;
            int reachedTwice = 0;
            int count = 0;
            bool found = false;

            HashSet<int> hashSet = new HashSet<int>();

            while (!found)
            {
                if (!hashSet.Contains(currentFreq))
                    hashSet.Add(currentFreq);
                else
                {
                    reachedTwice = currentFreq;
                    found = true;
                }

                currentFreq = IntList[count] + currentFreq;
                if (count == IntList.Count-1)
                    count = 0;
                else
                    count++;
            }

            return reachedTwice;
        }
    }
}
