namespace Devolutions.Zxcvbn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RankedDictionary = System.Collections.Generic.Dictionary<string, int>;
    using RankedDictionaries = System.Collections.Generic.Dictionary<DictionaryName, System.Collections.Generic.Dictionary<string, int>>;
    using L33tTable = System.Collections.Generic.Dictionary<char, char[]>;
    using System.Text.RegularExpressions;

    internal class Matching
    {
        private const int dateMaxYear = 2050;
        private const int dateMinYear = 1000;
        private const int maxDelta = 5;

        private static readonly RankedDictionaries rankedDictionaries = new RankedDictionaries
        {
            [DictionaryName.EnglishWikipedia] = BuildRankedDict(FrequencyList.EnglishWikipedia),
            [DictionaryName.FemaleNames] = BuildRankedDict(FrequencyList.FemaleNames),
            [DictionaryName.MaleNames] = BuildRankedDict(FrequencyList.MaleNames),
            [DictionaryName.Passwords] = BuildRankedDict(FrequencyList.Passwords),
            [DictionaryName.Surnames] = BuildRankedDict(FrequencyList.Surnames),
            [DictionaryName.UsTvAndFilm] = BuildRankedDict(FrequencyList.UsTvAndFilm)
        };

        private static L33tTable l33tTable = new L33tTable
        {
            ['a'] = new[] { '4', '@' },
            ['b'] = new[] { '8' },
            ['c'] = new[] { 'C', '{', '[', '<' },
            ['e'] = new[] { '3' },
            ['g'] = new[] { '6', '9' },
            ['i'] = new[] { '1', '!', '|' },
            ['l'] = new[] { '1', '|', '7' },
            ['o'] = new[] { '0' },
            ['s'] = new[] { '$', '5' },
            ['t'] = new[] { '+', '7' },
            ['x'] = new[] { '%' },
            ['z'] = new[] { '2' }
        };

        private static Dictionary<RegexName, Regex> regexen = new Dictionary<RegexName, Regex>
        {
            [RegexName.RecentYear] = new Regex(@"19\d\d|200\d|201\d")
        };

        private static readonly Dictionary<int, (int, int)[]> dateSplits = new Dictionary<int, (int, int)[]>
        {
            [4] = new (int, int)[]
            {
                (1, 2),
                (2, 3),
            },
            [5] = new (int, int)[]
            {
                (1, 3),
                (2, 3),
            },
            [6] = new (int, int)[]
            {
                (1, 2),
                (2, 4),
                (4, 5),
            },
            [7] = new (int, int)[]
            {
                (1, 3),
                (2, 3),
                (4, 5),
                (4, 6),
            },
            [8] = new (int, int)[]
            {
                (2, 4),
                (4, 6),
            },
        };

        public static RankedDictionary BuildRankedDict(string[] orderedList)
        {
            RankedDictionary result = new RankedDictionary();

            for (int i = 0; i < orderedList.Length; i++)
            {
                result.Add(orderedList[i], i + 1);
            }

            return result;
        }

        public static IEnumerable<ZxcvbnMatch> OmniMatch(string password)
        {
            List<ZxcvbnMatch> matches = new List<ZxcvbnMatch>();

            matches.AddRange(DictionaryMatch(password));
            matches.AddRange(ReverseDictionaryMatch(password));
            matches.AddRange(L33tMatch(password));
            matches.AddRange(SpatialMatch(password));
            matches.AddRange(RepeatMatch(password));
            matches.AddRange(SequenceMatch(password));
            matches.AddRange(RegexMatch(password));
            matches.AddRange(DateMatch(password));

            return Sorted(matches);
        }

        private static ZxcvbnMatch[] DictionaryMatch(string password, RankedDictionaries rankedDictionaries = default)
        {
            rankedDictionaries = rankedDictionaries ?? Matching.rankedDictionaries;

            List<ZxcvbnMatch> matches = new List<ZxcvbnMatch>();
            string passwordLower = password.ToLower();

            foreach (KeyValuePair<DictionaryName, RankedDictionary> kv in rankedDictionaries)
            {
                DictionaryName dictionaryName = kv.Key;
                RankedDictionary rankedDict = kv.Value;

                for (int i = 0; i < password.Length; i++)
                {
                    for (int j = i; j < password.Length; j++)
                    {
                        string word = passwordLower.Substring(i, j - i + 1);

                        if (rankedDict.TryGetValue(word, out int rank))
                        {
                            matches.Add(new ZxcvbnMatch
                            {
                                Pattern = MatchPattern.Dictionary,
                                I = i,
                                J = j,
                                Token = password.Substring(i, j - i + 1),
                                MatchedWord = word,
                                Rank = rank,
                                DictionaryName = dictionaryName
                            });
                        }
                    }
                }
            }

            return Sorted(matches);
        }

        private static ZxcvbnMatch[] ReverseDictionaryMatch(string password, RankedDictionaries rankedDictionaries = default)
        {
            string reversedPassword = Reverse(password);
            ZxcvbnMatch[] matches = DictionaryMatch(reversedPassword, rankedDictionaries);

            foreach (ZxcvbnMatch match in matches)
            {
                match.Token = Reverse(match.Token);
                match.Reversed = true;

                int i = match.I;
                int j = match.J;

                //WARN: Flipped J / I (from original source)?
                match.I = password.Length - 1 - j;
                match.J = password.Length - 1 - i;
            }

            return Sorted(matches);
        }

        private static ZxcvbnMatch[] L33tMatch(string password, RankedDictionaries rankedDictionaries = default, L33tTable l33tTable = default)
        {
            string Translate(string str, Dictionary<char, char> charMap)
            {
                foreach (KeyValuePair<char, char> chr in charMap)
                {
                    str = str.Replace(chr.Key, chr.Value);
                }

                return str;
            }

            l33tTable = l33tTable ?? Matching.l33tTable;

            List<ZxcvbnMatch> matches = new List<ZxcvbnMatch>();

            List<Dictionary<char, char>> subs = EnumerateL33tSubs(RelevantL33tSubtable(password, l33tTable));

            foreach (Dictionary<char, char> sub in subs)
            {
                if (sub.Count == 0)
                {
                    continue;
                }

                string subbedPassword = Translate(password, sub);

                foreach (ZxcvbnMatch match in DictionaryMatch(subbedPassword, rankedDictionaries))
                {
                    string token = password.Substring(match.I, match.J - match.I + 1);

                    if (token.ToLower() == match.MatchedWord)
                    {
                        continue;
                    }

                    Dictionary<char, char> matchSub = new Dictionary<char, char>();

                    foreach (KeyValuePair<char, char> kv in sub)
                    {
                        if (token.IndexOf(kv.Key) != -1)
                        {
                            if (matchSub.ContainsKey(kv.Key))
                            {
                                continue;
                            }

                            matchSub.Add(kv.Key, kv.Value);
                        }
                    }

                    match.L33t = true;
                    match.Token = token;
                    match.Sub = matchSub;
                    match.SubDisplay = string.Join(", ", matchSub.Select(kv => $"{kv.Key} -> {kv.Value}"));
                    matches.Add(match);
                }
            }

            return Sorted(matches.Where(m => m.Token?.Length > 1).ToArray());
        }

        private static ZxcvbnMatch[] SpatialMatch(string password, AdjacencyGraph[] graphs = default)
        {
            graphs = graphs ?? new[] { AdjacencyGraph.Qwerty, AdjacencyGraph.Dvorak, AdjacencyGraph.Keypad, AdjacencyGraph.MacKeypad };

            return graphs.SelectMany(g => SpatialMatchHelper(password, g)).ToArray();
        }

        private static ZxcvbnMatch[] SpatialMatchHelper(string password, AdjacencyGraph graph)
        {
            Regex shiftedRegex = new Regex(@"[~!@#$%^&*()_+QWERTYUIOP{}|ASDFGHJKL:""ZXCVBNM<>?]");
            List<ZxcvbnMatch> matches = new List<ZxcvbnMatch>();

            int i = 0;

            while (i < password.Length - 1)
            {
                int j = i + 1;
                int? lastDirection = null;
                int turns = 0;
                int shiftedCount = 0;

                if ((graph == AdjacencyGraph.Qwerty || graph == AdjacencyGraph.Dvorak) && shiftedRegex.IsMatch(password[i].ToString()))
                {
                    shiftedCount = 1;
                }

                while (true)
                {
                    char prevChar = password[j - 1];
                    bool found = false;
                    int foundDirection = -1;
                    int currentDirection = -1;
                    string[] adjacents = graph.TryGetValue(prevChar, out string[] values) ? values : new string[0];

                    if (j < password.Length)
                    {
                        char currentChar = password[j];

                        foreach (string adj in adjacents)
                        {
                            currentDirection++;

                            if (adj != null && adj.IndexOf(currentChar) != -1)
                            {
                                found = true;
                                foundDirection = currentDirection;

                                if (adj.IndexOf(currentChar) == 1)
                                {
                                    shiftedCount++;
                                }

                                if (lastDirection != foundDirection)
                                {
                                    turns++;
                                    lastDirection = foundDirection;
                                }

                                break;
                            }
                        }
                    }

                    if (found)
                    {
                        j++;
                    }
                    else
                    {
                        if (j - i > 2)
                        {
                            matches.Add(new ZxcvbnMatch
                            {
                                Pattern = MatchPattern.Spatial,
                                I = i,
                                J = j - 1,
                                Token = password.Substring(i, j - i),
                                Graph = graph.Name,
                                Turns = turns,
                                ShiftedCount = shiftedCount
                            });
                        }

                        i = j;
                        break;
                    }
                }
            }

            return matches.ToArray();
        }

        private static ZxcvbnMatch[] RepeatMatch(string password)
        {
            List<ZxcvbnMatch> matches = new List<ZxcvbnMatch>();

            Regex greedy = new Regex(@"(.+)\1+");
            Regex lazy = new Regex(@"(.+?)\1+");
            Regex lazyAnchored = new Regex(@"^(.+?)\1+$");

            int lastIndex = 0;

            while (lastIndex < password.Length)
            {
                string croppedPassword = password.Substring(lastIndex);

                Match greedyMatch = greedy.Match(croppedPassword);
                Match lazyMatch = lazy.Match(croppedPassword);
                Match match;
                string baseToken;

                if (!greedyMatch.Success)
                {
                    break;
                }

                if (greedyMatch.Groups[0].Length > lazyMatch.Groups[0].Length)
                {
                    match = greedyMatch;
                    baseToken = lazyAnchored.Match(match.Groups[0].Value).Groups[1].Value;
                }
                else
                {
                    match = lazyMatch;
                    baseToken = match.Groups[1].Value;
                }

                int i = match.Index + lastIndex;
                int j = match.Index + match.Groups[0].Length - 1 + lastIndex;
                ZxcvbnResult baseAnalysis = Scoring.MostGuessableMatchSequence(baseToken, OmniMatch(baseToken));

                matches.Add(new ZxcvbnMatch
                {
                    Pattern = MatchPattern.Repeat,
                    I = i,
                    J = j,
                    Token = match.Groups[0].Value,
                    BaseToken = baseToken,
                    BaseGuesses = baseAnalysis.Guesses,
                    BaseMatches = baseAnalysis.Sequence,
                    RepeatCount = match.Groups[0].Length / baseToken.Length
                });

                lastIndex = j + 1;
            }

            return matches.ToArray();
        }

        private static ZxcvbnMatch[] SequenceMatch(string password)
        {
            if (password.Length == 1)
            {
                return new ZxcvbnMatch[0];
            }

            List<ZxcvbnMatch> matches = new List<ZxcvbnMatch>();

            void Update(int i, int j, int delta)
            {
                if (j - i > 1 || Math.Abs(delta) == 1)
                {
                    if (0 < Math.Abs(delta) && Math.Abs(delta) <= maxDelta)
                    {
                        string token = password.Substring(i, j - i + 1);
                        SequenceName sequenceName = SequenceName.Unicode;
                        int sequenceSpace = 26;

                        if (Regex.IsMatch(token, @"^[a-z]+$"))
                        {
                            sequenceName = SequenceName.Lower;
                        }
                        else if (Regex.IsMatch(token, @"^[A-Z]+$"))
                        {
                            sequenceName = SequenceName.Upper;
                        }
                        else if (Regex.IsMatch(token, @"^\d+$"))
                        {
                            sequenceName = SequenceName.Digits;
                            sequenceSpace = 10;
                        }

                        matches.Add(new ZxcvbnMatch
                        {
                            Pattern = MatchPattern.Sequence,
                            I = i,
                            J = j,
                            Token = password.Substring(i, j - i + 1),
                            SequenceName = sequenceName,
                            SequenceSpace = sequenceSpace,
                            Ascending = delta > 0
                        });
                    }
                }
            }

            int i = 0;
            int? lastDelta = null;

            for (int k = 1; k <= password.Length - 1; k++)
            {
                int delta = password[k] - password[k - 1];

                if (!lastDelta.HasValue)
                {
                    lastDelta = delta;
                }

                if (lastDelta == delta)
                {
                    continue;
                }

                int j = k - 1;

                Update(i, j, lastDelta.Value);

                i = j;
                lastDelta = delta;
            }

            Update(i, password.Length - 1, lastDelta.Value);

            return matches.ToArray();
        }

        private static ZxcvbnMatch[] RegexMatch(string password, Dictionary<RegexName, Regex> regexen = default)
        {
            List<ZxcvbnMatch> matches = new List<ZxcvbnMatch>();

            regexen = regexen ?? Matching.regexen;

            foreach (KeyValuePair<RegexName, Regex> kv in regexen)
            {
                MatchCollection ms = kv.Value.Matches(password);

                matches.AddRange(ms.Cast<Match>().Select(m => new ZxcvbnMatch
                {
                    Pattern = MatchPattern.Regex,
                    Token = m.Groups[0].Value,
                    I = m.Index,
                    J = m.Index + m.Value.Length - 1,
                    RegexName = kv.Key,
                    RegexMatch = m
                }));
            }

            return Sorted(matches);
        }

        private static ZxcvbnMatch[] DateMatch(string password)
        {
            List<ZxcvbnMatch> matches = new List<ZxcvbnMatch>();

            Regex maybeDateNoSeparator = new Regex(@"^\d{4,8}$");
            Regex maybeDateWithSeparator = new Regex(@"^(\d{1,4})([\s/\\_.-])(\d{1,2})\2(\d{1,4})$");

            for (int i = 0; i <= password.Length - 4; i++)
            {
                for (int j = i + 3; j <= i + 7; j++)
                {
                    if (j >= password.Length)
                    {
                        break;
                    }

                    string token = password.Substring(i, j - i + 1);

                    if (!maybeDateNoSeparator.IsMatch(token))
                    {
                        continue;
                    }

                    List<(int d, int m, int y)> candidates = new List<(int d, int m, int y)>();

                    foreach ((int k, int l) dateSplit in dateSplits[token.Length])
                    {
                        (int d, int m, int y)? dmy = MapIntsToDmy(new[]
                        {
                                token.Substring(0, dateSplit.k),
                                token.Substring(dateSplit.k, dateSplit.l - dateSplit.k),
                                token.Substring(dateSplit.l),
                        }.Select(s => int.TryParse(s, out int v) ? v : -1).ToArray());

                        if (dmy.HasValue)
                        {
                            candidates.Add(dmy.Value);
                        }

                        if (candidates.Count == 0)
                        {
                            continue;
                        }

                        (int d, int m, int y) bestCandidate = candidates[0];

                        int Metric((int d, int m, int y) candidate) => Math.Abs(candidate.y) - DateTime.Now.Year;

                        int minDistance = Metric(bestCandidate);

                        foreach ((int d, int m, int y) candidate in candidates.Skip(1))
                        {
                            int distance = Metric(candidate);

                            if (distance < minDistance)
                            {
                                minDistance = distance;
                                bestCandidate = candidate;
                            }
                        }

                        matches.Add(new ZxcvbnMatch
                        {
                            Pattern = MatchPattern.Date,
                            Token = token,
                            I = i,
                            J = j,
                            Separator = "",
                            Year = bestCandidate.y,
                            Month = bestCandidate.m,
                            Day = bestCandidate.d
                        });
                    }
                }
            }

            for (int i = 0; i <= password.Length - 6; i++)
            {
                for (int j = i + 5; j <= i + 9; j++)
                {
                    if (j >= password.Length)
                    {
                        break;
                    }

                    string token = password.Substring(i, j - i + 1);
                    Match match = maybeDateWithSeparator.Match(token);

                    if (!match.Success)
                    {
                        continue;
                    }

                    (int d, int m, int y)? dmy = MapIntsToDmy(new[]
                    {
                        match.Groups[1].Value,
                        match.Groups[3].Value,
                        match.Groups[4].Value
                    }.Select(s => int.TryParse(s, out int v) ? v : -1).ToArray());

                    if (!dmy.HasValue)
                    {
                        continue;
                    }

                    matches.Add(new ZxcvbnMatch
                    {
                        Pattern = MatchPattern.Date,
                        Token = token,
                        I = i,
                        J = j,
                        Separator = match.Groups[2].Value,
                        Year = dmy.Value.y,
                        Month = dmy.Value.m,
                        Day = dmy.Value.d
                    });
                }
            }

            return Sorted(matches.Where(m =>
            {
                foreach (ZxcvbnMatch otherMatch in matches)
                {
                    if (m == otherMatch)
                    {
                        continue;
                    }

                    if (otherMatch.I <= m.I && otherMatch.J >= m.J)
                    {
                        return false;
                    }
                }

                return true;
            }).ToArray());
        }

        private static Dictionary<char, char[]> RelevantL33tSubtable(string password, Dictionary<char, char[]> table)
        {
            HashSet<char> passwordChars = new HashSet<char>(password.Distinct());

            L33tTable subtable = new Dictionary<char, char[]>();

            foreach (KeyValuePair<char, char[]> kv in table)
            {
                char[] relevantSubs = kv.Value.Where(s => passwordChars.Contains(s)).ToArray();

                if (relevantSubs.Length > 0)
                {
                    subtable.Add(kv.Key, relevantSubs);
                }
            }

            return subtable;
        }

        private static List<Dictionary<char, char>> EnumerateL33tSubs(Dictionary<char, char[]> table)
        {
            List<Dictionary<char, char>> subs = new List<Dictionary<char, char>>();
            subs.Add(new Dictionary<char, char>());

            List<Dictionary<char, char>> Dedup(List<Dictionary<char, char>> subs)
            {
                List<Dictionary<char, char>> deduped = new List<Dictionary<char, char>>();
                HashSet<string> members = new HashSet<string>();

                foreach (Dictionary<char, char> sub in subs)
                {
                    KeyValuePair<char, char>[] assoc = sub.ToArray().OrderBy(kv => kv.Key).ToArray();
                    string label = string.Join("-", assoc.Select(kv => $"{kv.Key},{kv.Value}"));

                    if (!members.Contains(label))
                    {
                        members.Add(label);
                        deduped.Add(sub);
                    }
                }

                return deduped;
            }

            void Helper(char[] keys)
            {
                if (keys.Length == 0)
                {
                    return;
                }

                char firstKey = keys.First();
                List<Dictionary<char, char>> nextSubs = new List<Dictionary<char, char>>();

                foreach (char l33tChar in table[firstKey])
                {
                    foreach (Dictionary<char, char> sub in subs)
                    {
                        int dupL33tIndex = -1;

                        KeyValuePair<char, char>[] subArray = sub.ToArray();

                        for (int i = 0; i < subArray.Length; i++)
                        {
                            if (subArray[i].Key == l33tChar)
                            {
                                dupL33tIndex = i;
                                break;
                            }
                        }

                        if (dupL33tIndex == -1)
                        {
                            Dictionary<char, char> subExtensions = new Dictionary<char, char>();

                            foreach (var kv in sub)
                            {
                                subExtensions.Add(kv.Key, kv.Value);
                            }

                            subExtensions.Add(l33tChar, firstKey);
                            nextSubs.Add(subExtensions);
                        }
                        else
                        {
                            Dictionary<char, char> subAlternative = new Dictionary<char, char>();

                            for (int i = 0; i < subArray.Length; i++)
                            {
                                if (i == dupL33tIndex)
                                {
                                    continue;
                                }

                                subAlternative.Add(subArray[i].Key, subArray[i].Value);
                            }

                            subAlternative.Add(l33tChar, firstKey);
                            nextSubs.Add(sub);
                            nextSubs.Add(subAlternative);
                        }
                    }
                }

                subs = Dedup(nextSubs);
                Helper(keys.Skip(1).ToArray());
            }

            Helper(table.Keys.ToArray());

            List<Dictionary<char, char>> subDicts = new List<Dictionary<char, char>>();

            foreach (Dictionary<char, char> sub in subs)
            {
                Dictionary<char, char> subDict = new Dictionary<char, char>();

                foreach (KeyValuePair<char, char> kv in sub)
                {
                    subDict.Add(kv.Key, kv.Value);
                }

                subDicts.Add(subDict);
            }

            return subDicts;
        }

        private static void SetUserInputDictionary(string[] orderedList)
        {
            RankedDictionary rankedDictionary = BuildRankedDict(orderedList);

            if (!rankedDictionaries.ContainsKey(DictionaryName.UserInputs))
            {
                rankedDictionaries.Add(DictionaryName.UserInputs, rankedDictionary);
            }
            else
            {
                rankedDictionaries[DictionaryName.UserInputs] = rankedDictionary;
            }
        }

        private static int Mod(int n, int m) => ((n % m) + m) % m;

        private static ZxcvbnMatch[] Sorted(IEnumerable<ZxcvbnMatch> matches)
        {
            List<ZxcvbnMatch> result = matches.ToList();

            result.Sort((m1, m2) =>
            {
                int diff = m1.I - m2.I;

                return diff == 0 ? m1.J - m2.J : diff;
            });

            return result.ToArray();
        }

        private static string Reverse(string str)
        {
            return new string(str.ToCharArray().Reverse().ToArray());
        }

        private static (int d, int m, int y)? MapIntsToDmy(int[] ints)
        {
            if (ints[1] > 31 || ints[1] <= 0)
            {
                return default;
            }

            int over12 = 0;
            int over31 = 0;
            int under1 = 0;

            foreach (int @int in ints)
            {
                if ((99 < @int && @int < dateMinYear) || @int > dateMaxYear)
                {
                    return default;
                }
            }

            if (over31 >= 2 || over12 == 3 || under1 >= 2)
            {
                return default;
            }

            (int, int[])[] possibleYearSplits = new[]
            {
                (ints[2], ints.Take(2).ToArray()),
                (ints[0], ints.Skip(1).Take(2).ToArray()),
            };

            foreach ((int y, int[] rest) in possibleYearSplits)
            {
                if (dateMinYear <= y && y <= dateMaxYear)
                {
                    (int d, int m)? dm = MapIntsToDm(rest);

                    if (dm.HasValue)
                    {
                        return (dm.Value.m, dm.Value.d, y);
                    }
                    else
                    {
                        return default;
                    }
                }
            }

            foreach ((int y, int[] rest) in possibleYearSplits)
            {
                if (dateMinYear <= y && y <= dateMaxYear)
                {
                    (int d, int m)? dm = MapIntsToDm(rest);

                    if (dm.HasValue)
                    {
                        return (dm.Value.d, dm.Value.m, TwoToFourDigitYear(y));
                    }
                }
            }

            return default;
        }

        private static (int d, int m)? MapIntsToDm(int[] ints)
        {
            int[] reversed = ints.Reverse().ToArray();

            for (int i = 0; i < ints.Length; i++)
            {
                int d = ints[i];
                int m = reversed[i];

                if (1 <= d && d <= 31 && 1 <= m && m <= 12)
                {
                    return (d, m);
                }
            }

            return default;
        }

        private static int TwoToFourDigitYear(int year)
        {
            if (year > 99)
            {
                return year;
            }

            if (year > 50)
            {
                return year + 1900;
            }

            return year + 2000;
        }
    }
}
