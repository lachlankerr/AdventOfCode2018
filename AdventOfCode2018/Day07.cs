using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    class Day07
    {
        readonly List<string> Input;

        public const int Part1Answer = 0;
        public const int Part2Answer = 0;

        public Day07()
        {
            Input = System.IO.File.ReadAllLines("day07-input-example.txt").ToList();
            //Input.Sort();
            //System.IO.File.WriteAllLines("day07-input-sorted.txt", Input);
        }

        public int Part1()
        {
            int numberOfLetters = 6;
            List<List<int>> steps = new List<List<int>>();
            for (int i = 0; i < numberOfLetters; i++)
            {
                steps.Add(new List<int>());
            }
            //List<string> shortenedBackwardsInput = new List<string>();
            foreach (string line in Input)
            {
                char previousStep = Convert.ToChar(line[5]);
                char nextStep = Convert.ToChar(line[36]);
                //shortenedBackwardsInput.Add(nextStep + " <- " + previousStep);
                steps[nextStep-65].Add(previousStep-65);
            }
            //shortenedBackwardsInput.Sort();
            //System.IO.File.WriteAllLines("day07-input-sorted-shortbackwards.txt", shortenedBackwardsInput);
            List<int> startingLetters = new List<int>();
            for (int i = 0; i < steps.Count; i++)
            {
                if (steps[i].Count == 0)
                    startingLetters.Add(i);
            }
            return 0;
        }

        public int Part2()
        {
            return 0;
        }
    }
}
