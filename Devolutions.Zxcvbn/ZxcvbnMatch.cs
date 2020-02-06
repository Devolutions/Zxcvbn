using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Devolutions.Zxcvbn
{
    internal class ZxcvbnMatch
    {
        public MatchPattern Pattern { get; set; }

        public int I { get; set; }

        public int J { get; set; }

        public string Token { get; set; }

        public double? Guesses { get; set; }

        public bool Ascending { get; set; }

        public int RepeatCount { get; set; }

        public double BaseGuesses { get; set; }

        public DictionaryName DictionaryName { get; set; }

        public RegexName RegexName { get; set; }

        public Match RegexMatch { get; set; }

        public int Year { get; set; }

        public string Graph { get; set; }

        public int Turns { get; set; }

        public int ShiftedCount { get; set; }

        public double Rank { get; internal set; }

        public bool Reversed { get; internal set; }

        public double UppercaseVariations { get; set; }

        public double L33tVariations { get; set; }

        public bool L33t { get; set; }

        public Dictionary<char, char> Sub { get; set; }

        public double GuessesLog10 { get; set; }

        public string Separator { get; set; }

        public string BaseToken { get; set; }

        public string MatchedWord { get; set; }

        public ZxcvbnMatch[] BaseMatches { get; set; }

        public SequenceName SequenceName { get; set; }

        public int SequenceSpace { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public string SubDisplay { get; set; }

        public override string ToString()
        {
            return $"{Pattern}: {Token}";
        }
    }
}
