using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    class Day05
    {
        string Input;

        public const int Part1Answer = 10180;
        public const int Part2Answer = 5668;

        public Day05()
        {
            Input = System.IO.File.ReadAllText("day05-input.txt").Trim(); //if copy pasted from input there will be a carriage return as well
        }

        public int Part1()
        {
            char[] charList = Input.ToCharArray();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < Input.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(charList[i]);
                    continue;
                }
                char top = stack.Peek();
                if (char.IsLower(top) && char.IsUpper(charList[i]) || char.IsLower(charList[i]) && char.IsUpper(top))
                {
                    if (char.ToLower(top).Equals(char.ToLower(charList[i])))
                    {
                        stack.Pop();
                        continue;
                    }
                }
                stack.Push(charList[i]);
            }
            return stack.Count;
        }

        public int Part2()
        {
            string originalInput = Input;
            int asciiUpperOffset = 65;
            int asciiLowerOffset = 97;
            int shortestPolymer = 999999999;

            for (int i = 0; i < 26; i++)
            {
                Input = originalInput;
                char lower = (char)(i + asciiUpperOffset);
                char upper = (char)(i + asciiLowerOffset);
                Input = Input.Replace(lower.ToString(), string.Empty);
                Input = Input.Replace(upper.ToString(), string.Empty);
                int result = Part1();
                if (result < shortestPolymer)
                    shortestPolymer = result;
            }

            return shortestPolymer;
        }
    }
}
