using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    class Day06
    {
        readonly List<string> Input;

        public const int Part1Answer = 0;
        public const int Part2Answer = 0;

        public Day06()
        {
            Input = System.IO.File.ReadAllLines("day06-input.txt").ToList();
        }

        public int Part1()
        {
            List<Coord> points = new List<Coord>();
            List<List<char>> grid = new List<List<char>>();

            int i = 0;
            foreach (string line in Input)
            {
                string[] split = line.Split(new string[] { ", " }, StringSplitOptions.None);
                points.Add(new Coord(i++, Convert.ToInt32(split[0]), Convert.ToInt32(split[1])));
            }
            return 0;
        }

        public int Part2()
        {
            return 0;
        }
    }

    class Coord
    {
        public int X { get; }
        public int Y { get; }
        public int Id { get; }

        public Coord(int id, int x, int y)
        {
            X = x;
            Y = y;
            Id = id;
        }
    }
}
