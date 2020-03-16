using System;
using System.Linq;

public static class Triangle
{
    public enum Type : int
    {
        Equilateral = 0,
        Isosceles,
        Scalene
    }

    public static bool IsScalene(double side1, double side2, double side3)
        => ProcessTriangle(Type.Scalene, side1, side2, side3);

    public static bool IsIsosceles(double side1, double side2, double side3) 
        => ProcessTriangle(Type.Isosceles, side1, side2, side3);

    public static bool IsEquilateral(double side1, double side2, double side3)
        => ProcessTriangle(Type.Equilateral, side1, side2, side3);

    private static bool ProcessTriangle(Type expectation, params double[] sides)
    {
        if (!ValidateInput(sides)) return false;

        Type distance = (Type)HammingDistance(sides);

        if (expectation == Type.Isosceles)
            return distance == Type.Equilateral || distance == Type.Isosceles;

        return distance == expectation;
    }

    private static bool ValidateInput(params double[] sides)
    {
        if (sides.Length < 3) return false;

        if (!sides.All(s => s > 0)) return false;

        var windows = new[] {
            (sides[0], sides[1], sides[2]),
            (sides[1], sides[2], sides[0]),
            (sides[2], sides[0], sides[1])
        };
        
        return windows.All(t => t.Item1 + t.Item2 >= t.Item3);
    }

    public static int HammingDistance(params double[] sides)
    {
        var diffs = sides.Distinct();

        var x = diffs.Count() - 1;
        return x;
    }
    public static bool IsDegenerate(params double[] sides)
        => sides[0] + sides[1] == sides[2];
}