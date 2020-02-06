namespace Devolutions.Zxcvbn
{
    using System;
    using System.Linq;

    internal partial class TimeEstimates
    {
        public CrackTimesSeconds CrackTimesSeconds { get; private set; }

        public string[] CrackTimesDisplay { get; private set; }

        public int Score { get; private set; }

        private TimeEstimates()
        {
        }

        internal static TimeEstimates EstimateAttackTimes(double guesses)
        {
            double[] times = new[]
            {
                guesses / (100d / 3600d),
                guesses / 10,
                guesses / 1e4,
                guesses / 1e10
            };

            return new TimeEstimates
            {
                CrackTimesSeconds = new CrackTimesSeconds(times[0], times[1], times[2], times[3]),
                CrackTimesDisplay = times.Select(DisplayTime).ToArray(),
                Score = GuessesToScore(guesses)
            };
        }

        private static int GuessesToScore(double guesses)
        {
            const int delta = 5;

            if (guesses < 1e3 + delta)
            {
                return 0;
            }

            if (guesses < 1e6 + delta)
            {
                return 1;
            }

            if (guesses < 1e8 + delta)
            {
                return 2;
            }

            if (guesses < 1e10 + delta)
            {
                return 3;
            }

            return 4;
        }

        private static string DisplayTime(double seconds)
        {
            const long minute = 60;
            const long hour = minute * 60;
            const long day = hour * 24;
            const long month = day * 31;
            const long year = month * 12;
            const long century = year * 100;

            (int? num, string str) display;

            if (seconds < 1)
            {
                display = (0, "less than a second");
            }
            else if (seconds < minute)
            {
                int @base = (int)Math.Round(seconds);
                display = (@base, $"{@base} second");
            }
            else if (seconds < hour)
            {
                int @base = (int)Math.Round(seconds / minute);
                display = (@base, $"{@base} minute");
            }
            else if (seconds < day)
            {
                int @base = (int)Math.Round(seconds / hour);
                display = (@base, $"{@base} hour");
            }
            else if (seconds < month)
            {
                int @base = (int)Math.Round(seconds / day);
                display = (@base, $"{@base} day");
            }
            else if (seconds < year)
            {
                int @base = (int)Math.Round(seconds / month);
                display = (@base, $"{@base} month");
            }
            else if (seconds < century)
            {
                int @base = (int)Math.Round(seconds / year);
                display = (@base, $"{@base} year");
            }
            else
            {
                display = (null, "centuries");
            }

            if (display.num > 1)
            {
                display.str += "s";
            }

            return display.str;
        }
    }
}