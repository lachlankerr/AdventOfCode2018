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

        public const int Part1Answer = 3871;
        public const int Part2Answer = 0;

        public Day06()
        {
            Input = System.IO.File.ReadAllLines("day06-input.txt").ToList();
            
        }

        public int Part1()
        {
            int width = 0;
            int height = 0;

            //convert input into points
            List<Point> points = new List<Point>();
            int i = 0;
            foreach (string line in Input)
            {
                string[] split = line.Split(new string[] { ", " }, StringSplitOptions.None);
                Point temp = new Point(i++, Convert.ToInt32(split[0]), Convert.ToInt32(split[1]));
                points.Add(temp);
                //find size of grid
                if (temp.X + 1 > width)
                    width = temp.X + 1;
                if (temp.Y + 1 > height)
                    height = temp.Y + 1;
            }

            //initialise grid with '.'
            int[,] grid = new int[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[x, y] = -1;
                }
            }

            //plot points on grid
            foreach (Point point in points)
            {
                grid[point.X, point.Y] = point.Id;//GetCharFromPoint(point);
            }

            //manhattan distance for each cell on grid
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (grid[x, y] == -1) //prevents points already placed from being calculated again
                    {
                        int lowest = 999999999;
                        Point bestPoint = new Point(0, 0, 0);
                        Point current = new Point(-1, x, y);
                        bool twoOrMore = false;
                        foreach (Point point in points) //find shortest distance to one of the points in list
                        {
                            int distance = Manhattan(current, point);
                            if (distance < lowest)
                            {
                                lowest = distance;
                                bestPoint = point;
                                twoOrMore = false;
                            }
                            else if (distance == lowest)
                                twoOrMore = true;
                        }
                        if (!twoOrMore) //two or more points for this cell are equal distance, so don't do anything
                            grid[x, y] = bestPoint.Id;// GetCharFromPoint(bestPoint);
                    }
                }
            }

            //gets list of infinites and counts occurences of each id
            List<int> infinites = new List<int>();
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Point temp = new Point(0, x, y);
                    if (IsPointOnEdge(temp, width, height) && !infinites.Contains(grid[x, y]))
                        infinites.Add(grid[x, y]);
                    if (freq.ContainsKey(grid[x, y]))
                        freq[grid[x, y]]++;
                    else
                        freq.Add(grid[x, y], 1);
                }
            }

            //removes infinites
            foreach(int infinite in infinites)
            {
                freq.Remove(infinite);
            }
            freq.Remove(-1); //just in case it wasn't an infinite and was the largest area

            return freq.Values.Max();
        }

        public bool IsPointOnEdge(Point point, int width, int height)
        {
            return point.X == 0 || point.Y == 0 || point.X == height || point.Y == width;
        }

        public int Manhattan(Point point1, Point point2)
        {
            return Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);
        }

        public char GetCharFromPoint(Point point)
        {
            return (char)('A' + point.Id);
        }

        public char GetLowerCharFromPoint(Point point)
        {
            return (char)('a' + point.Id);
        }

        public int Part2()
        {
            return 0;
        }
    }

    class Point
    {
        public int X { get; }
        public int Y { get; }
        public int Id { get; }

        public Point(int id, int x, int y)
        {
            X = x;
            Y = y;
            Id = id;
        }
    }
}
