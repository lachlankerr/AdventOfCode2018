using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            //prog.Day01Output();
            //prog.Day02Output();
            //prog.Day03Output();
            //prog.Day04Output();
            prog.Day05Output();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        void Day01Output()
        {
            Console.WriteLine("Day 01");
            Day01 day = new Day01();

            Console.WriteLine("Part 1: {0}", day.Part1() == Day01.Part1Answer);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Part 2: {0}", day.Part2() == Day01.Part2Answer);
            stopwatch.Stop();
            Console.WriteLine("Time for part 2: {0}", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine();
        }

        void Day02Output()
        {
            Console.WriteLine("Day 02");
            Day02 day = new Day02();

            Console.WriteLine("Part 1: {0}", day.Part1() == Day02.Part1Answer);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Part 2: {0}", day.Part2() == Day02.Part2Answer);
            stopwatch.Stop();
            Console.WriteLine("Time for part 2: {0}", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine();
        }

        void Day03Output()
        {
            Console.WriteLine("Day 03");
            Day03 day = new Day03();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Part 1: {0}", day.Part1() == Day03.Part1Answer);
            stopwatch.Stop();
            Console.WriteLine("Time for part 1: {0}", stopwatch.Elapsed.TotalMilliseconds);

            Console.WriteLine("Part 2: {0}", day.Part2() == Day03.Part2Answer);
            Console.WriteLine();
        }

        void Day04Output()
        {
            Console.WriteLine("Day 04");
            Day04 day = new Day04();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Part 1: {0}", day.Part1() == Day04.Part1Answer);
            stopwatch.Stop();
            Console.WriteLine("Time for part 1: {0}", stopwatch.Elapsed.TotalMilliseconds);

            Console.WriteLine("Part 2: {0}", day.Part2() == Day04.Part2Answer);
            Console.WriteLine();
        }

        void Day05Output()
        {
            Console.WriteLine("Day 05");
            Day05 day = new Day05();
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            Console.WriteLine("Part 1: {0}", day.Part1());// == Day04.Part1Answer);
            //stopwatch.Stop();
            //Console.WriteLine("Time for part 1: {0}", stopwatch.Elapsed.TotalMilliseconds);

            Console.WriteLine("Part 2: {0}", day.Part2());// == Day04.Part2Answer);
            Console.WriteLine();
        }
    }
}
