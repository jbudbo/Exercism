using System;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return r.Expreal(realNumber);
    }
}

public struct RationalNumber
{
    private readonly int numerator;
    private readonly int denominator;

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new DivideByZeroException();
        
        var gcd = GCD(numerator, denominator);

        this.numerator = numerator / gcd;
        this.denominator = denominator / gcd;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        => new RationalNumber(Math.Abs(r1.numerator * r2.denominator) - Math.Abs(r2.numerator * r1.denominator), r1.denominator * r2.denominator);

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        => new RationalNumber(Math.Abs(r1.numerator * r2.denominator) - Math.Abs(r2.numerator * r1.denominator), r1.denominator * r2.denominator);

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        => new RationalNumber(r1.numerator * r2.numerator, r1.denominator * r2.denominator);

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        => new RationalNumber(r1.numerator * r2.denominator, r2.numerator * r1.denominator);

    public RationalNumber Abs() => new RationalNumber(Math.Abs(numerator), Math.Abs(denominator));

    public RationalNumber Reduce() => this;

    public RationalNumber Exprational(int power)
    {
        if(power >= 0)
            return new RationalNumber((int)Math.Pow(numerator, power), (int)Math.Pow(denominator, power));
        else
            return new RationalNumber((int)Math.Pow(denominator, Math.Abs(power)), (int)Math.Pow(numerator, Math.Abs(power)));
    }

    public double Expreal(int baseNumber)
    {
        return Math.Pow(baseNumber, numerator / (double)denominator);
    }

    public override string ToString() => $"{numerator}/{denominator}";

    private static int GCD(int a, int b)
        => b == 0 ? a : GCD(b, a % b);
}