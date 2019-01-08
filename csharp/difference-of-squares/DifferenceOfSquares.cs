using System;
using System.Collections.Generic;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
        => (int)Math.Pow(Range(1, max).Sum(), 2);

    public static int CalculateSumOfSquares(int max)
        => Range(1, max, (o) => (int)Math.Pow(o, 2)).Sum();

    public static int CalculateDifferenceOfSquares(int max)
        => CalculateSquareOfSum(max) - CalculateSumOfSquares(max);

    private static IEnumerable<int> Range(int start, int count, Func<int,int> op = null)
    {
        for (int i = start; i <= count;) yield return op?.Invoke(i++) ?? i++;
    }

    private static int Sum(this IEnumerable<int> ints)
    {
        int sum = 0;
        foreach(int i in ints) sum += i;
        return sum;
    }
}