namespace Devolutions.Zxcvbn
{
    internal static class FrequencyList
    {
        public static string[] EnglishWikipedia { get; } = EmbeddedResources.ReadAllLines("Devolutions.Zxcvbn.Resources.FrequencyList.EnglishWikipedia.txt");
        public static string[] FemaleNames { get; } = EmbeddedResources.ReadAllLines("Devolutions.Zxcvbn.Resources.FrequencyList.FemaleNames.txt");
        public static string[] MaleNames { get; } = EmbeddedResources.ReadAllLines("Devolutions.Zxcvbn.Resources.FrequencyList.MaleNames.txt");
        public static string[] Passwords { get; } = EmbeddedResources.ReadAllLines("Devolutions.Zxcvbn.Resources.FrequencyList.Passwords.txt");
        public static string[] Surnames { get; } = EmbeddedResources.ReadAllLines("Devolutions.Zxcvbn.Resources.FrequencyList.Surnames.txt");
        public static string[] UsTvAndFilm { get; } = EmbeddedResources.ReadAllLines("Devolutions.Zxcvbn.Resources.FrequencyList.UsTvAndFilm.txt");
    }
}
