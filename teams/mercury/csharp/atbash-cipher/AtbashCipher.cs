using System.Linq;
using System.Collections.Generic;

public static class AtbashCipher
{
    /// <summary>
    /// Bit-specific ASCII offset
    /// </summary>
    private const int Up_offset = 1<<5;

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

        foreach(var s in source)
        {
            segment[index++] = s;

            // Zero Based
            if(index == size)
            {
                index = 0;
                yield return segment;
                segment = new T[size];
            }
        }

        //  Output any stragglers
        if(index < size && index > 0)
        {
            yield return segment
                .Take(index)
                .ToArray();
        }
    }

    public static string Encode(string plainValue)
        => string.Join(" ", plainValue
            //  Force everything to lowercase
            .Select(c => c | Up_offset)
            //  Forego punctuation and spaces
            .Where(c => (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
            .Select(c =>
            {
                //  If we're on a number then just return that number
                if (c >= '0' && c <= '9') return (char)c;

                //  Calc our character rollover
                int i = c - 'z';

                //  Get the Absolute value
                //  Offset our 'wrapping'
                return (char)((((i >> 31) ^ i) - (i >> 31)) + 'a');
            })
            //  Group by 5
            .Windowed(5)
            //  After windowing they come back in an array of character arrays, we need to compensate
            .Select(cs => new string(cs)));

    // Decoding is easier because our 'wrapping' technique facilitates this direction
    public static string Decode(string encodedValue)
        => new string(encodedValue
            //  Force everything to lowercase
            .Select(c => c | Up_offset)
            //  Forego punctuation and spaces
            .Where(c => (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
            //  No need to calcuate absolute, just calc our wrapping
            .Select(c => (c >= '0' && c <= '9') ? (char)c : (char)('z' - (c - 'a')))
            //  Enumerate our logic pipe
            .ToArray());
}
