using System;
using System.Collections.Generic;
using System.Linq;

public static class Pangram
{
    //  a - z ascii
    // 97 - 122
    public static bool IsPangram(string input)
    {
        //  The use of ASCII only is specifically called out
        var compendium = new HashSet<byte>();
        foreach(byte b in input.ToLower()) if (b > 96 && b < 123) compendium.Add(b);
        return compendium.Count == 26;
    }
}
