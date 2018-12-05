using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    class Day02
    {
        readonly List<string> Input;
        HashSet<string> Twice;
        HashSet<string> Triple;
        
        public const int Part1Answer = 5904;
        public const string Part2Answer = "jiwamotgsfrudclzbyzkhlrvp";

        public Day02()
        {
            Input = System.IO.File.ReadAllLines("day02-input.txt").ToList();
            Twice = new HashSet<string>();
            Triple = new HashSet<string>();
        }

        public int Part1()
        {
            foreach (string current in Input)
            {
                List<char> chars = current.ToCharArray().ToList();

                if (chars.GroupBy(r => r).Any(t => t.Count() == 2)) Twice.Add(current);
                if (chars.GroupBy(r => r).Any(t => t.Count() == 3)) Triple.Add(current);
            }

            return Twice.Count * Triple.Count;
        }

        public string Part2()
        {
            string[] idList = Twice.Except(Triple).ToArray();
            int comparisons = 0;

            for (int id1 = 0; id1 < idList.Length; id1++)
            {
                for (int id2 = id1 + 1; id2 < idList.Length; id2++)
                {
                    comparisons++;
                    int diff = 0;
                    int removeIndex = 0;
                    for (int cha = 0; cha < idList[id1].Length; cha++)
                    {
                        if (idList[id1][cha] != idList[id2][cha])
                        {
                            if (diff == 0)
                                removeIndex = cha;
                            diff++;
                        }
                        if (diff > 1)
                            break;
                    }
                    if (diff == 1)
                    {
                        System.Console.WriteLine("Comparisons: {0}", comparisons);
                        return idList[id1].Remove(removeIndex, 1);
                    }
                }
            }
            return "Error";
        }
    }
}
