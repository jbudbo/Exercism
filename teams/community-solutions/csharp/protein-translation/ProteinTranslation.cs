using System;
using System.Collections.Generic;

public static class ProteinTranslation
{
    private static readonly HashSet<string> stops = new HashSet<string>(new string[]{"UAA","UAG","UGA" });

    public static string[] Proteins(string strand)
    {
        List<int> hashes = new List<int>();
        ArraySegment<char> source = new ArraySegment<char>(strand.ToCharArray());
        for(int i = 0, n = source.Count; i < n; i += 3)
        {
            Codon codon = source.Slice(i, 3);
            hashes.Add(codon);
        }
        return null;
    }

    public readonly ref struct Codon
    {
        private readonly Span<char> nucleotide;

        private Codon(Span<char> nucleotide)
        {
            this.nucleotide = nucleotide;
        }

        public static implicit operator Codon(ArraySegment<char> seg) 
            => new Codon(seg);

        public static implicit operator int(Codon c)
            => c.nucleotide[0] << 16 | c.nucleotide[1] << 8 | c.nucleotide[2];
    }
}