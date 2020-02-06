namespace Devolutions.Zxcvbn
{
    internal class CrackTimesSeconds
    {
        public CrackTimesSeconds(double onlineThrottling100PerHour, double onlineNoThrottling10PerSecond, double offlineSlowHashing1e4PerSecond, double offlineFastHashing1e10PerSecond)
        {
            OnlineThrottling100PerHour = onlineThrottling100PerHour;
            OnlineNoThrottling10PerSecond = onlineNoThrottling10PerSecond;
            OfflineSlowHashing1e4PerSecond = offlineSlowHashing1e4PerSecond;
            OfflineFastHashing1e10PerSecond = offlineFastHashing1e10PerSecond;
        }

        public double OnlineThrottling100PerHour { get; }

        public double OnlineNoThrottling10PerSecond { get; }

        public double OfflineSlowHashing1e4PerSecond { get; }

        public double OfflineFastHashing1e10PerSecond { get; }
    }
}