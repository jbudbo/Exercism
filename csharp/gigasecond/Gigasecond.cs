using System;

public static class Gigasecond
{
    private static readonly TimeSpan giga = new TimeSpan(0,0,1000000000);
    public static DateTime Add(DateTime birthDate)
    {
        return birthDate + giga;
    }
}