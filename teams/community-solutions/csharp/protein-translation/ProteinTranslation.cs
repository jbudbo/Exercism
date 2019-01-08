using System;
using System.Collections.Generic;
using ProteinTranslation.Helpers;

namespace ProteinTranslation
{
    public static class ProteinTranslation
    {
        public static string[] Proteins(string strand)
        {
            List<string> polypeptide = new List<string>();

            foreach(string codon in strand.ToChunks(3))
            {
                string protein = Translate(codon);
                if (protein is null) break;
                polypeptide.Add(protein);
            }

            return polypeptide.ToArray();
        }

        private static string Translate(string codon)
        {
            switch (codon)
            {
                case "AUG":
                    return "Methionine";
                case "UUU":
                case "UUC":
                    return "Phenylalanine";
                case "UUA":
                case "UUG":
                    return "Leucine";
                case "UCU":
                case "UCC":
                case "UCA":
                case "UCG":
                    return "Serine";
                case "UAU":
                case "UAC":
                    return "Tyrosine";
                case "UGU":
                case "UGC":
                    return "Cysteine";
                case "UGG":
                    return "Tryptophan";
                case "UAA":
                case "UAG":
                case "UGA":
                    return null;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}