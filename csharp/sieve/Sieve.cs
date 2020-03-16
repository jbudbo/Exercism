using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2)
            throw new ArgumentOutOfRangeException(nameof(limit), "No primes under two");

        //  Process first by getting our list of numbers to Exclude
        var exclusions = GetExclusions(limit);

        //  Return
        return Enumerable
            //  - The Full Set from 2 to limit
            .Range(2, limit - 1)
            //  <- Everything except the excluded numbers
            .Except(exclusions).ToArray();
    }

    private static IEnumerable<int> GetExclusions(int limit, int floor = 2)
    {
        //  If we find that our minimum squared is higher than our limit there is no
        //      sense in processing as we'll find nothing
        if (floor * floor > limit)
            return Enumerable.Empty<int>();

        //  If we queue this up as IEnumerable then we can save the recursive processing
        //      until invocation
        IEnumerable<int> locals()
        {
            for (int i = floor, calc = i * floor; calc <= limit; calc = ++i * floor)
            {
                yield return calc;
            }
        }

        //  Return an IEnumerable that will end up being a distinct list of these local 
        //      exclusions plus the next set 
        return locals().Concat(GetExclusions(limit, floor + 1)).Distinct();
    }
}