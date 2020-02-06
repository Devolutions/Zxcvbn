using System;
using System.Collections.Generic;

namespace Devolutions.Zxcvbn
{
    public static class Zxcvbn
    {
        public static ZxcvbnResult Evaluate(string password)
        {
            DateTime startTime = DateTime.Now;
            IEnumerable<ZxcvbnMatch> matches = Matching.OmniMatch(password);
            ZxcvbnResult result = Scoring.MostGuessableMatchSequence(password, matches);

            result.CalcTime = DateTime.Now - startTime;

            TimeEstimates timeEstimates = TimeEstimates.EstimateAttackTimes(result.Guesses);

            result.Score = timeEstimates.Score;
            result.ThrottledOnlineAttackCrackTime = timeEstimates.CrackTimesDisplay[0];
            result.UnthrottledOnlineAttackCrackTime = timeEstimates.CrackTimesDisplay[1];
            result.OfflineSlowHashManyCoresCrackTime = timeEstimates.CrackTimesDisplay[2];
            result.OfflineFastHashManyCoresCrackTime = timeEstimates.CrackTimesDisplay[3];
            result.CrackTimesSeconds = timeEstimates.CrackTimesSeconds;

            result.Feedback = Feedback.GetFeedback(timeEstimates.Score, result.Sequence);

            return result;
        }
    }
}
