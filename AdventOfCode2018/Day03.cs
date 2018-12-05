using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    class Day03
    {
        readonly List<string> Input;
        HashSet<int> OverlappingClaims;

        public const int Part1Answer = 109785;
        public const int Part2Answer = 504;

        public Day03()
        {
            Input = System.IO.File.ReadAllLines("day03-input.txt").ToList();
            OverlappingClaims = new HashSet<int>();
        }

        public int Part1()
        {
            int[,] fabric = new int[1000, 1000];
            foreach (string line in Input)
            {
                MatchCollection matches = Regex.Matches(line, @"^#(\d+) @ (\d+),(\d+): (\d+)x(\d+)");

                int id = Convert.ToInt32(matches[0].Groups[1].Value);
                int left = Convert.ToInt32(matches[0].Groups[2].Value);
                int top = Convert.ToInt32(matches[0].Groups[3].Value);
                int wide = Convert.ToInt32(matches[0].Groups[4].Value);
                int height = Convert.ToInt32(matches[0].Groups[5].Value);

                for (int i = left; i < wide + left; i++)
                {
                    for (int j = top; j < height + top; j++)
                    {
                        if (fabric[i, j] == 0)
                            fabric[i, j] = id;
                        else
                        {
                            OverlappingClaims.Add(id);
                            if (fabric[i, j] != -1)
                                OverlappingClaims.Add(fabric[i, j]);
                            fabric[i, j] = -1;
                        }
                    }
                }
            }

            int overlapCount = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (fabric[i, j] == -1)
                        overlapCount++;
                }
            }

            return overlapCount;
        }

        public int Part2()
        {
            for (int i = 1; i < 1000; i++)
            {
                if (!OverlappingClaims.Contains(i))
                    return i;
            }
            return 0;
        }
    }
}
