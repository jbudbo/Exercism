using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "UAGUUUUUCUUAUUGUCUUCCUCAUCGUAUUACUGUUGCUGGUAAUAGUGA";
            var source = new ArraySegment<char>(s.ToCharArray());
            for(int i = 0, n = source.Count; i < n; i += 3)
            {
                Codon codon = source.Slice(i, 3);
                Console.WriteLine((int)codon);
            }
        }
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
