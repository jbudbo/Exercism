using System;
using System.Collections.Generic;
using System.Linq;

public class Robot
{
    private string name;
    public string Name {
        get{
            if(string.IsNullOrWhiteSpace(name))
                name = NameGenerator.Next();
            return name;
        }
    }

    public void Reset()
    {
        NameGenerator.Remove(name);
        name = null;
    }

    private static class NameGenerator
    {
        private static readonly Random mizer = new Random();
        private static readonly HashSet<char[]> names = new HashSet<char[]>();

        private const int alphaMin = 65;
        private const int alphaMax = 90;

        private const int numMin = 48;
        private const int numMax = 57;

        public static string Next()
        {
            char[] candidate;

            do
            {
                candidate = GenerateNew().ToArray();

            } while (names.Contains(candidate));

            names.Add(candidate);

            return new string(candidate);
        }

        public static void Remove(string name)
            => names.Remove(name.ToCharArray());

        private static IEnumerable<char> GenerateNew()
        {
            yield return (char)mizer.Next(alphaMin, alphaMax);
            yield return (char)mizer.Next(alphaMin, alphaMax);
            yield return (char)mizer.Next(numMin, numMax);
            yield return (char)mizer.Next(numMin, numMax);
            yield return (char)mizer.Next(numMin, numMax);
        }
    }
}