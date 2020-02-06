namespace Devolutions.Zxcvbn
{
    using System.IO;
    using System.Linq;

    internal static class EmbeddedResources
    {
        public static string[] ReadAllLines(string name)
        {
            Stream stream = typeof(EmbeddedResources).Assembly.GetManifestResourceStream(name);

            if (stream == null)
            {
                return null;
            }

            using StreamReader reader = new StreamReader(stream);

            return reader.ReadToEnd()
                .Split('\n')
                .Select(l => l.Trim('\r'))
                .ToArray();
        }
    }
}
