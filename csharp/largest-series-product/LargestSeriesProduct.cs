using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (!Regex.Match(digits, "^[0-9]*$").Success || span < 0 )
            throw new ArgumentException();

        if (span == 0) return 1;

        if (string.IsNullOrWhiteSpace(digits) || span > digits.Length)
            throw new ArgumentException();

        if (Regex.Match(digits, "^0*$").Success) return 0;

        var chars = digits
            .ToCharArray()
            .Select(char.GetNumericValue);

        return chars
            .Window(span)
            .Select(str => str.Product())
            .Max();
    }

    public static long Product(this IEnumerable<double> source)
    {
        long product = 1;
        foreach (double d in source) product *= (long)d;
        return product;
    }

    public static IEnumerable<IEnumerable<T>> Window<T>(this IEnumerable<T> source, int span)
    {
        T[] srcArr = source.ToArray();

        for (int s = 0, n = srcArr.Length; n - s >= span; s++)
            yield return srcArr.Skip(s).Take(span);
    }
}