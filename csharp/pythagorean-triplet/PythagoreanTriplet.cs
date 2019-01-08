using System;
using System.Collections.Generic;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        for (int a = 3, b = 4; a < sum - a - b - 1; a++, b = a + 1)
            for(; b < sum - b - 1; b++)
            {
                var c = Math.Sqrt(a * a + b * b);
                if(c % 1 == 0)
                {
                    if (a + b + c == sum)
                        yield return (a, b, (int)c);
                }
            }
    }
}