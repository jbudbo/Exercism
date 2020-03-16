using System;
using System.Collections.Generic;
using System.Linq;

public static class AffineCipher
{
    const string fullLib = "abcdefghijklmnopqrstuvwxyz";
    static readonly Lazy<char[]> cache = new Lazy<char[]>(() => fullLib.ToCharArray());
    static readonly Lazy<int> len = new Lazy<int>(() => fullLib.Length);

    public static string Encode(string plainText, int a, int b)
    {
        if (!IsCoPrime(a, len.Value)) throw new ArgumentException("Error: a and m must be coprime.");

        return string.Join(" ", plainText
            .ToLower()
            .Where(char.IsLetterOrDigit)
            .Branched(char.IsDigit,
                c => c, 
                c => (char)((((a * Array.IndexOf(cache.Value, c)) + b) % len.Value) + 'a'))
            .Windowed(5)
            .Select(cs => new string(cs)));
    }

    public static string Decode(string cipheredText, int a, int b)
    {
        if (!IsCoPrime(a, len.Value)) throw new ArgumentException("Error: a and m must be coprime.");

        return new string(cipheredText
            .Where(char.IsLetterOrDigit)
            .Branched(char.IsDigit,
                c => c,
                c => (char)Math.Pow(a,-1*(Array.IndexOf(cache.Value, c)-b)%len.Value + 'a'))
            .ToArray());
    }

    private static IEnumerable<Tout> Branched<Tin, Tout>(this IEnumerable<Tin> source, Predicate<Tin> test, Func<Tin,Tout> IfTrue, Func<Tin, Tout> IfFalse)
        => source.Select(t => test(t) ? IfTrue(t) : IfFalse(t));

    private static bool IsCoPrime(int a, int b)
    {
        //  It's just as easy to setup a local x, y var off of a and b but why :)
        static int GCD(int x, int y)
        {
            while (x != 0 && y != 0)
            {
                if (x > y)
                    x %= y;
                else
                    y %= x;
            }
            return Math.Max(x, y);
        }
        return GCD(a, b) == 1;
    }

    /// <summary>
    /// Groups <see cref="IEnumerable{T}"/> in chunks of a given <paramref name="size"/>
    /// </summary>
    /// <typeparam name="T">The underlying object type to iterate on</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}"/> source to Window</param>
    /// <param name="size">The Size of each window to return</param>
    /// <returns></returns>
    private static IEnumerable<T[]> Windowed<T>(this IEnumerable<T> source, int size)
    {
        T[] segment = new T[size];
        int index = 0;

        foreach (var s in source)
        {
            segment[index++] = s;

            // Zero Based
            if (index == size)
            {
                index = 0;
                yield return segment;
                segment = new T[size];
            }
        }

        //  Output any stragglers
        if (index < size && index > 0)
        {
            yield return segment
                .Take(index)
                .ToArray();
        }
    }
}
