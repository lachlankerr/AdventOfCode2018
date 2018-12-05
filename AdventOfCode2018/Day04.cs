using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    class Day04
    {
        readonly List<string> Input;
        Dictionary<int,Dictionary<int, int>> GuardTimes;

        public const int Part1Answer = 138280;
        public const int Part2Answer = 0;

        public Day04()
        {
            Input = System.IO.File.ReadAllLines("day04-input-spike.txt").ToList();
            Input.Sort();
            GuardTimes = new Dictionary<int, Dictionary<int, int>>();

            //System.IO.File.WriteAllLines("day04-input-sorted.txt", Input);
        }

        public int Part1()
        {
            int currentGuard = 0;
            int asleepStart = 0;
            foreach (string line in Input)
            {
                MatchCollection matches = Regex.Matches(line, @"^\[(\d+)-(\d+)-(\d+) (\d+):(\d+)\] (falls|Guard #(\d+)|wakes)", RegexOptions.Compiled);

                int year = Convert.ToInt32(matches[0].Groups[1].Value);
                int month = Convert.ToInt32(matches[0].Groups[2].Value);
                int day = Convert.ToInt32(matches[0].Groups[3].Value);
                int hour = Convert.ToInt32(matches[0].Groups[4].Value);
                int minute = Convert.ToInt32(matches[0].Groups[5].Value);
                string action = matches[0].Groups[6].Value;
                if (action.StartsWith("Guard"))
                {
                    currentGuard = Convert.ToInt32(matches[0].Groups[7].Value);
                    action = "Guard";
                }

                if (action.Equals("falls"))
                {
                    asleepStart = minute;
                }

                if (action.Equals("wakes"))
                {
                    for (int i = asleepStart; i < minute; i++)
                    {
                        if (GuardTimes.TryGetValue(currentGuard, out Dictionary<int, int> times))
                        {
                            times.TryGetValue(i, out int freqAsleep); //increments the current time for this guard if it already exists
                            times[i] = ++freqAsleep;                  //otherwise just sets to 1

                            GuardTimes[currentGuard] = times;
                        }
                        else //guard hasn't been seen before, add this first time to a new dictionary then add dictionary to new guard id
                        {
                            Dictionary<int, int> newTimes = new Dictionary<int, int> { [i] = 1 };
                            GuardTimes.Add(currentGuard, newTimes);
                        }
                    }
                }
            }

            int guardWithMostMinutesAsleep = 0;
            int totalMinutesGuardWasAsleep = 0;
            int minuteGuardWasMostAsleep = 0;
            foreach (KeyValuePair<int, Dictionary<int,int>> guard in GuardTimes)
            {
                int totalMinutesAsleep = 0;
                int mostAsleepMinute = 0;
                int mostAsleepMinuteValue = 0;
                foreach (KeyValuePair<int, int> time in guard.Value)
                {
                    totalMinutesAsleep += time.Value;
                    if (time.Value > mostAsleepMinuteValue)
                    {
                        mostAsleepMinuteValue = time.Value;
                        mostAsleepMinute = time.Key;
                    }
                }
                if (totalMinutesAsleep > totalMinutesGuardWasAsleep)
                {
                    guardWithMostMinutesAsleep = guard.Key;
                    totalMinutesGuardWasAsleep = totalMinutesAsleep;
                    minuteGuardWasMostAsleep = mostAsleepMinute;
                }
            }
            return guardWithMostMinutesAsleep * minuteGuardWasMostAsleep;
        }

        public int Part2()
        {
            foreach (KeyValuePair<int, Dictionary<int, int>> guard in GuardTimes)
            {
                foreach (KeyValuePair<int, int> time in guard.Value)
                {

                }
            }

            return 0;
        }
    }
}
