using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        const int outerRadius = 10;
        const int middleRadius = 5;
        const int innerRadius = 1;

        var radius = Math.Sqrt((x * x) + (y * y));

        if (radius > outerRadius) return 0;

        if (radius > middleRadius) return 1;

        if (radius > innerRadius) return 5;

        return 10;
    }
}
