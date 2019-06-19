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
            List<List<char>> steps = new List<List<char>>();

            //initialise array
            for (int i = 0; i < numberOfLetters; i++)
            {
                steps.Add(new List<char>());
            }

            //fill the steps array list
            foreach (string line in Input)
            {
                char previousStep = Convert.ToChar(line[5]);
                char nextStep = Convert.ToChar(line[36]);
                steps[nextStep-'A'].Add(previousStep);
            }

            //find starting letters
            List<char> startingLetters = new List<char>();
            for (int i = 0; i < numberOfLetters; i++)
            {
                if (steps[i].Count == 0)
                    startingLetters.Add(Convert.ToChar(i + 'A'));
            }

            string output = "";

            //start looping through each letter
            while (output.Length != numberOfLetters)
            {
                startingLetters.Sort();
                char letter = startingLetters[0];
                output += letter;
                startingLetters.Remove(letter);
                for (int i = 0; i < numberOfLetters; i++)
                {
                    foreach (char step in steps[i])
                    {
                        //need to check for letter prereqs here
                        if (step == letter && !startingLetters.Contains(Convert.ToChar(i + 'A')))
                            startingLetters.Add(Convert.ToChar(i + 'A'));
                    }
                }
            }
            return 0;
        }

        public int Part2()
        {
            return 0;
        }
    }
}
//Step C must be finished before step A can begin.