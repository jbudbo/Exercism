using System;
using System.Collections;
using System.Collections.Generic;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        if (shiftKey < 0 || shiftKey > 26)
            throw new ArgumentException(nameof(shiftKey));

        return string.Concat(text.MutateChars(shiftKey));
    }
    
    public static IEnumerable<char> MutateChars(this IEnumerable<char> source, int shiftKey)
    {
        foreach (Letter c in source)
        {
            if (c.IsLetter)
                yield return c + shiftKey;
            else
                yield return c;
        }
    }

    private struct Letter
    {
        private readonly int offset;
        private int index;

        private Letter(char c)
        {
            if(char.IsUpper(c))
            {
                offset = 'A';
            }
            else if(char.IsLetter(c))
            {
                offset = 'a';
            }
            else
            {
                offset = 0;
            }
            index = c - offset;
        }

        public bool IsLetter => offset > 0;

        public static implicit operator Letter(char c) => new Letter(c);
        public static implicit operator char(Letter l) => (char)(l.offset + l.index);

        public static Letter operator +(Letter l, int i)
        {
            l.index += i;
            l.index %= 26;
            return l;
        }
    }
}