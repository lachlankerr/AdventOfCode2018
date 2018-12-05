using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    class Day05
    {
        readonly string Input;

        public Day05()
        {
            Input = System.IO.File.ReadAllText("day05-input.txt");
        }

        public int Part1()
        {
            List<char> charList = Input.ToCharArray().ToList();
            for (int i = 0; i < charList.Count-1; i++)
            {
                if (char.IsLower(charList[i]) && char.IsUpper(charList[i+1]) || char.IsLower(charList[i+1]) && char.IsUpper(charList[i]))
                {
                    if (char.ToLower(charList[i]).Equals(char.ToLower(charList[i+1])))
                    {
                        charList.RemoveAt(i);
                        charList.RemoveAt(i); //dont use +1 or it will remove wrong thing
                        i = 0;
                    }
                }
            }
            return charList.Count;
        }

        public int Part2()
        {
            return 0;
        }
    }
}
