using System;
using System.Collections.Generic;
using System.Linq;
public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException();

        var result = Divisors(number).Sum() - number;

        if (result < 0)
            return Classification.Deficient;

        if (result > 0)
            return Classification.Abundant;

        return Classification.Perfect;
    }

    private static IEnumerable<int> Divisors(int number)
    {
        for(int i = number / 2; i > 0; i--)
        {
            if(number % i == 0) yield return i;
        }
    }
}
