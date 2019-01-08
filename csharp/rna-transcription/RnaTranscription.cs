using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        if(string.IsNullOrWhiteSpace(nucleotide))
            return string.Empty;

        return string.Concat(nucleotide.Transcribe());
    }

    private static readonly Dictionary<char,char> rnaMapping = new Dictionary<char, char>
    {
        ['C'] = 'G',
        ['G'] = 'C',
        ['T'] = 'A',
        ['A'] = 'U'
    };

    public static IEnumerable<char> Transcribe(this IEnumerable<char> chars)
    {
        foreach(char c in chars)
        {
            yield return rnaMapping[c];            
        }
    }
}