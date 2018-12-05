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
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < Input.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(Input[i]);
                    continue;
                }
                char top = stack.Peek();
                if (IsLower(top) && IsUpper(Input[i]) || IsLower(Input[i]) && IsUpper(top))
                {
                    if (ToLower(top).Equals(ToLower(Input[i])))
                    {
                        stack.Pop();
                        continue;
                    }
                }
                stack.Push(Input[i]);
            }
            return stack.Count;
        }

        public bool IsLower(char c)
        {
            return c >= 'a' && c <= 'z';
        }

        public bool IsUpper(char c)
        {
            return c >= 'A' && c <= 'Z';
        }

        public char ToLower(char c)
        {
            if (IsLower(c))
                return c;
            return (char)(c + 32);
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
