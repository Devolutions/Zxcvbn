using System;

namespace Devolutions.Zxcvbn
{
    public class ZxcvbnResult
    {
        internal ZxcvbnResult()
        {

        }

        public TimeSpan CalcTime { get; internal set; }

        public string Password { get; internal set; }

        public double GuessesLog10 { get; internal set; }

        public string ThrottledOnlineAttackCrackTime { get; internal set; }

        public string UnthrottledOnlineAttackCrackTime { get; internal set; }

        public string OfflineSlowHashManyCoresCrackTime { get; internal set; }

        public string OfflineFastHashManyCoresCrackTime { get; internal set; }

        public int Score { get; internal set; }

        public Feedback Feedback { get; internal set; }

        internal double Guesses { get; set; }

        internal CrackTimesSeconds CrackTimesSeconds { get; set; }

        internal ZxcvbnMatch[] Sequence { get; set; }
    }
}
