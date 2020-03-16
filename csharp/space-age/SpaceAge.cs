using System;

public class SpaceAge
{
    private readonly long age;
    public SpaceAge(long seconds)
    {
        this.age = seconds;
    }

    public double OnEarth()
    {
        return age / 31557600D;
    }

    public double OnMercury()
    {
        return OnEarth() / 0.2408467D;
    }

    public double OnVenus()
    {
        return OnEarth() / 0.61519726D;
    }

    public double OnMars()
    {
        return OnEarth() / 1.8808158D;
    }

    public double OnJupiter()
    {
        return OnEarth() / 11.862615D;
    }

    public double OnSaturn()
    {
        return OnEarth() / 29.447498D;
    }

    public double OnUranus()
    {
        return OnEarth() / 84.016846D;
    }

    public double OnNeptune()
    {
        return OnEarth() / 164.79132D;
    }
}