using System;
using System.Collections.Generic;
using System.Linq;

public static class Grains
{
    private static readonly Func<int, ulong> engine = i => 1UL << (i-1);

    public static ulong Square(int n)
    {
        if (!n.Between(0, 65))
            throw new ArgumentOutOfRangeException(nameof(n));

        return engine(n);
    }

    public static ulong Total()
        => Enumerable.Range(1, 64).AsParallel().Sum(engine);

    public static ulong Sum(this IEnumerable<int> source, Func<int, ulong> f = null)
    {
        ulong sum = 0;
        foreach (int u in source) sum += f?.Invoke(u) ?? (ulong)u;
        return sum;
    }

    public static bool Between(this int n, int min, int max)
        => min < n && max > n;
}