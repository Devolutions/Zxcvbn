namespace Devolutions.Zxcvbn
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Feedback
    {
        internal static Feedback Default => new Feedback("", "Use a few words, avoid common phrases", "No need for symbols, digits, or uppercase letters");
        internal static Feedback Empty => new Feedback("");

        private Feedback(string warning, params string[] suggestions)
        {
            Warning = warning ?? "";
            Suggestions = suggestions ?? new string[0];
        }

        public string Warning { get; private set; }

        public string[] Suggestions { get; private set; }

        internal static Feedback GetFeedback(double score, ZxcvbnMatch[] sequence)
        {
            if (sequence == null || sequence.Length == 0)
            {
                return Default;
            }

            if (score > 2)
            {
                return Empty;
            }

            ZxcvbnMatch longestMatch = sequence.OrderByDescending(m => m.Token.Length).First();

            Feedback feedback = GetMatchFeedback(longestMatch, sequence.Length == 1);

            feedback.Suggestions = feedback.Suggestions.Concat(new[] { "Add another word or two. Uncommon words are better." }).ToArray();

            return feedback;
        }

        private static Feedback GetMatchFeedback(ZxcvbnMatch match, bool isSoleMatch)
        {
            return match.Pattern switch
            {
                MatchPattern.Dictionary => GetDictionaryMatchFeedback(match, isSoleMatch),
                MatchPattern.Spatial => new Feedback(match.Turns == 1 ? "Straight rows of keys are easy to guess" : "Short keyboard patterns are easy to guess", "Use a longer keyboard pattern with more turns"),
                MatchPattern.Repeat => new Feedback(match.BaseToken.Length == 1 ? @"Repeats like ""aaa"" are easy to guess" : @"Repeats like ""abcabcabc"" are only slightly harder to guess than ""abc""", "Avoid repeated words and characters"),
                MatchPattern.Sequence => new Feedback("Sequences like abc or 6543 are easy to guess", "Avoid sequences"),
                MatchPattern.Regex => match.RegexName == RegexName.RecentYear ? new Feedback("Recent years are easy to guess", "Avoid recent years", "Avoid years that are associated with you") : Default,
                MatchPattern.Date => new Feedback("Dates are often easy to guess", "Avoid dates and years that are associated with you"),
                _ => Empty
            };
        }

        private static Feedback GetDictionaryMatchFeedback(ZxcvbnMatch match, bool isSoleMatch)
        {
            string warning = "";

            if (match.DictionaryName == DictionaryName.Passwords)
            {
                if (isSoleMatch && !match.L33t && !match.Reversed)
                {
                    if (match.Rank <= 10)
                    {
                        warning = "This is a top-10 common password";
                    }
                    else if (match.Rank <= 100)
                    {
                        warning = "This is a top-100 common password";
                    }
                    else
                    {
                        warning = "This is a very common password";
                    }
                }
                else if (match.GuessesLog10 <= 4)
                {
                    warning = "This is similar to a commonly used password";
                }
            }
            else if (match.DictionaryName == DictionaryName.EnglishWikipedia)
            {
                if (isSoleMatch)
                {
                    warning = "A word by itself is easy to guess";
                }
            }
            else if (match.DictionaryName == DictionaryName.Surnames || match.DictionaryName == DictionaryName.MaleNames || match.DictionaryName == DictionaryName.FemaleNames)
            {
                if (isSoleMatch)
                {
                    warning = "Names and surnames by themselves are easy to guess";
                }
                else
                {
                    warning = "Common names and surnames are easy to guess";
                }
            }

            List<string> suggestions = new List<string>();

            if (Regex.IsMatch(match.Token, Scoring.StartUpper))
            {
                suggestions.Add("Capitalization doesn't help very much");
            }
            else if (Regex.IsMatch(match.Token, Scoring.AllUpper) && match.Token.ToLower() != match.Token)
            {
                suggestions.Add("All-uppercase is almost as easy to guess as all-lowercase");
            }

            if (match.Reversed && match.Token.Length >= 4)
            {
                suggestions.Add("Reversed words aren't much harder to guess");
            }

            if (match.L33t)
            {
                suggestions.Add("Predictable substitutions like '@' instead of 'a' don't help very much");
            }

            return new Feedback(warning, suggestions.ToArray());
        }
    }
}
