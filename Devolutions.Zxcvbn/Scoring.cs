namespace Devolutions.Zxcvbn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal static class Scoring
    {
        private static readonly char[] obviousStartingPoints = new[] { 'a', 'A', 'z', 'Z', '0', '1', '9' };
        private static readonly int referenceYear = DateTime.Now.Year;
        private static readonly double keyboardAverageDegree = CalcAverageDegree(AdjacencyGraph.Qwerty);
        private static readonly double keypadAverageDegree = CalcAverageDegree(AdjacencyGraph.Keypad);
        private static readonly int keyboardStartingPositions = AdjacencyGraph.Qwerty.Count;
        private static readonly int keypadStartingPositions = AdjacencyGraph.Keypad.Count;

        private const int bruteforceCardinality = 10;
        private const int minGuessesBeforeGrowingSequence = 10000;
        private const int minSubmatchGuessesSingleChar = 10;
        private const int minSubmatchGuessesMultiChar = 50;
        private const int minYearSpace = 20;

        public const string StartUpper = @"^[A-Z][^A-Z]+$";
        public const string EndUpper = @"^[^A-Z]+[A-Z]$";
        public const string AllUpper = @"^[^a-z]+$";
        public const string AllLower = @"^[^A-Z]+$";

        private static double CalcAverageDegree(AdjacencyGraph graph)
        {
            double average = 0;

            foreach (KeyValuePair<char, string[]> kv in graph)
            {
                average += kv.Value.Count(v => v != null);
            }

            average /= graph.Count;

            return average;
        }

        private static double NCk(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if (k == 0)
            {
                return 1;
            }

            double r = 1;

            for (int d = 1; d <= k; d++)
            {
                r *= n;
                r /= d;
                n--;
            }

            return r;
        }

        private static double Log10(double n)
        {
            return Math.Log(n) / Math.Log(10);
        }

        private static double Factorial(int n)
        {
            if (n < 2)
            {
                return 1;
            }

            double f = 1;

            for (int i = 2; i <= n; i++)
            {
                f *= i;
            }

            return f;
        }

        public static ZxcvbnResult MostGuessableMatchSequence(string password, IEnumerable<ZxcvbnMatch> matches, bool excludeAdditive = false)
        {
            List<ZxcvbnMatch>[] matchesByJ = Enumerable.Range(0, password.Length).Select(i => new List<ZxcvbnMatch>()).ToArray();

            for (int i = 0; i < password.Length; i++)
            {
                matchesByJ[i] = new List<ZxcvbnMatch>();
            }

            foreach (ZxcvbnMatch m in matches)
            {
                matchesByJ[m.J].Add(m);
            }

            foreach (List<ZxcvbnMatch> lst in matchesByJ)
            {
                lst.Sort((m1, m2) => m1.I - m2.I);
            }

            Dictionary<int, ZxcvbnMatch>[] optimalM = Enumerable.Range(0, password.Length).Select(i => new Dictionary<int, ZxcvbnMatch>()).ToArray();
            Dictionary<int, double>[] optimalPi = Enumerable.Range(0, password.Length).Select(i => new Dictionary<int, double>()).ToArray();
            Dictionary<int, double>[] optimalG = Enumerable.Range(0, password.Length).Select(i => new Dictionary<int, double>()).ToArray();

            void Update(ZxcvbnMatch m, int l)
            {
                int k = m.J;
                double pi = EstimateGuesses(m, password);

                if (l > 1)
                {
                    pi *= optimalPi[m.I - 1][l - 1];
                }

                double g = Factorial(l) * pi;

                if (!excludeAdditive)
                {
                    g += Math.Pow(minGuessesBeforeGrowingSequence, l - 1);
                }

                foreach (KeyValuePair<int, double> kv in optimalG[k])
                {
                    int competingL = kv.Key;
                    double competingG = kv.Value;

                    if (competingL > l)
                    {
                        continue;
                    }
                    else if (competingG <= g)
                    {
                        return;
                    }
                }

                optimalG[k].AddOrSet(l, g);
                optimalM[k].AddOrSet(l, m);
                optimalPi[k].AddOrSet(l, pi);
            }

            void BruteforceUpdate(int k)
            {
                ZxcvbnMatch m = MakeBruteforceMatch(0, k);
                Update(m, 1);

                for (int i = 1; i <= k; i++)
                {
                    m = MakeBruteforceMatch(i, k);

                    foreach (KeyValuePair<int, ZxcvbnMatch> kv in optimalM[i - 1])
                    {
                        int l = kv.Key;
                        ZxcvbnMatch lastM = kv.Value;

                        if (lastM.Pattern == MatchPattern.Bruteforce)
                        {
                            continue;
                        }

                        Update(m, l + 1);
                    }
                }
            }

            ZxcvbnMatch MakeBruteforceMatch(int i, int j) => new ZxcvbnMatch
            {
                Pattern = MatchPattern.Bruteforce,
                Token = password.Substring(i, j - i + 1),
                I = i,
                J = j
            };

            ZxcvbnMatch[] Unwind(int n)
            {
                List<ZxcvbnMatch> optimalMatchSequence = new List<ZxcvbnMatch>();

                int k = n - 1;
                int l = 0;
                double g = double.PositiveInfinity;

                foreach (KeyValuePair<int, double> kv in optimalG[k])
                {
                    int candidateL = kv.Key;
                    double candidateG = kv.Value;

                    if (candidateG < g)
                    {
                        l = candidateL;
                        g = candidateG;
                    }
                }

                while (k >= 0)
                {
                    ZxcvbnMatch m = optimalM[k][l];
                    optimalMatchSequence.Insert(0, m);
                    k = m.I - 1;
                    l--;
                }

                return optimalMatchSequence.ToArray();
            }

            for (int k = 0; k < password.Length; k++)
            {
                foreach (ZxcvbnMatch m in matchesByJ[k])
                {
                    if (m.I > 0)
                    {
                        foreach (int l in optimalM[m.I - 1].Keys.OrderBy(k => k))
                        {
                            Update(m, l + 1);
                        }
                    }
                    else
                    {
                        Update(m, 1);
                    }
                }

                BruteforceUpdate(k);
            }

            ZxcvbnMatch[] optimalMatchSequence = Unwind(password.Length);
            int optimalL = optimalMatchSequence.Length;
            double guesses = password.Length == 0 ? 1 : optimalG[password.Length - 1][optimalL];

            return new ZxcvbnResult
            {
                Password = password,
                Guesses = guesses,
                GuessesLog10 = Log10(guesses),
                Sequence = optimalMatchSequence
            };
        }

        private static double EstimateGuesses(ZxcvbnMatch match, string password)
        {
            if (match.Guesses.HasValue)
            {
                return match.Guesses.Value;
            }

            int minGuesses = 1;

            if (match.Token.Length < password.Length)
            {
                minGuesses = match.Token.Length == 1 ? minSubmatchGuessesSingleChar : minSubmatchGuessesMultiChar;
            }

            double guesses = match.Pattern switch
            {
                MatchPattern.Dictionary => DictionaryGuesses(match),
                MatchPattern.Spatial => SpatialGuesses(match),
                MatchPattern.Repeat => RepeatGuesses(match),
                MatchPattern.Sequence => SequenceGuesses(match),
                MatchPattern.Regex => RegexGuesses(match),
                MatchPattern.Date => DateGuesses(match),
                _ => BruteforceGuesses(match)
            };

            match.Guesses = Math.Max(guesses, minGuesses);
            match.GuessesLog10 = Log10(match.Guesses.Value);

            return match.Guesses.Value;
        }

        private static double BruteforceGuesses(ZxcvbnMatch match)
        {
            double guesses = Math.Pow(bruteforceCardinality, match.Token.Length);

            if (double.IsInfinity(guesses))
            {
                guesses = double.MaxValue;
            }

            double minGuesses = match.Token.Length == 1 ? minSubmatchGuessesSingleChar : minSubmatchGuessesMultiChar;

            minGuesses += 1;

            return Math.Max(guesses, minGuesses);
        }

        private static double RepeatGuesses(ZxcvbnMatch match)
        {
            return match.BaseGuesses * match.RepeatCount;
        }

        private static double SequenceGuesses(ZxcvbnMatch match)
        {
            char firstChar = match.Token[0];
            double baseGuesses = obviousStartingPoints.Contains(match.Token[0]) ? 4 : (char.IsDigit(firstChar) ? 10 : 26);

            if (!match.Ascending)
            {
                baseGuesses *= 2;
            }

            return baseGuesses * match.Token.Length;
        }

        private static double RegexGuesses(ZxcvbnMatch match)
        {
            return match.RegexName switch
            {
                RegexName.RecentYear => Math.Max(Math.Abs(int.Parse(match.RegexMatch.Value) - referenceYear), minYearSpace),
                RegexName.None => 0,
                _ => Math.Pow((int)match.RegexName, match.Token.Length)
            };
        }

        private static double DateGuesses(ZxcvbnMatch match)
        {
            int guesses = Math.Max(Math.Abs(match.Year - referenceYear), minYearSpace) * 365;

            if (!string.IsNullOrEmpty(match.Separator))
            {
                guesses *= 4;
            }

            return guesses;
        }

        private static double SpatialGuesses(ZxcvbnMatch match)
        {
            bool isKeyboard = match.Graph == AdjacencyGraph.Qwerty.Name || match.Graph == AdjacencyGraph.Dvorak.Name;
            int s = isKeyboard ? keyboardStartingPositions : keypadStartingPositions;
            double d = isKeyboard ? keyboardAverageDegree : keypadAverageDegree;
            double guesses = 0;

            for (int i = 2; i <= match.Token.Length; i++)
            {
                int possibleTurns = Math.Min(match.Turns, i - 1);

                for (int j = 1; j <= possibleTurns; j++)
                {
                    guesses += NCk(i - 1, j - 1) * s * Math.Pow(d, j);
                }
            }

            if (match.ShiftedCount != 0)
            {
                int S = match.ShiftedCount;
                int U = match.Token.Length - match.ShiftedCount;

                if (S == 0 || U == 0)
                {
                    guesses *= 2;
                }
                else
                {
                    double shitfedVariations = 0;

                    for (int i = 1; i <= Math.Min(S, U); i++)
                    {
                        shitfedVariations += NCk(S + U, i);
                    }

                    guesses *= shitfedVariations;
                }
            }

            return guesses;
        }

        private static double DictionaryGuesses(ZxcvbnMatch match)
        {
            match.BaseGuesses = match.Rank;
            match.UppercaseVariations = UppercaseVariations(match);
            match.L33tVariations = L33tVariations(match);

            return match.BaseGuesses * match.UppercaseVariations * match.L33tVariations * (match.Reversed ? 2 : 1);
        }

        private static double UppercaseVariations(ZxcvbnMatch match)
        {
            if (Regex.IsMatch(match.Token, AllLower) || match.Token.ToLower() == match.Token)
            {
                return 1;
            }

            if (Regex.IsMatch(match.Token, StartUpper) || Regex.IsMatch(match.Token, EndUpper) || Regex.IsMatch(match.Token, AllUpper))
            {
                return 2;
            }

            int U = match.Token.Count(c => char.IsUpper(c));
            int L = match.Token.Count(c => char.IsLower(c));

            return Enumerable.Range(0, Math.Min(U, L)).Sum(i => NCk(U + L, i + 1));
        }

        private static double L33tVariations(ZxcvbnMatch match)
        {
            if (!match.L33t)
            {
                return 1;
            }

            double variations = 1;

            foreach (KeyValuePair<char, char> kv in match.Sub)
            {
                int S = match.Token.ToLower().Count(c => c == kv.Key);
                int U = match.Token.ToLower().Count(c => c == kv.Value);

                if (S == 0 || U == 0)
                {
                    variations *= 2;
                }
                else
                {
                    variations *= Enumerable.Range(0, Math.Min(U, S)).Sum(i => NCk(U + S, i + 1));
                }
            }

            return variations;
        }
    }
}
