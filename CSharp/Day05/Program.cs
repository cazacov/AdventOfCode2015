using System;
using System.Linq;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input.txt");
            var niceLines = lines.ToList().Count(IsNiceLine);
            Console.WriteLine($"There are {niceLines} nice strings");
        }

        private static bool IsNiceLine(string arg)
        {
            int vowelCount = 0;
            foreach (var ch in arg)
            {
                if (IsVowel(ch))
                {
                    vowelCount++;
                }
            }
            if (vowelCount < 3)
            {
                return false;
            }

            bool doublesFound = false;
            for (int i = 0; i < arg.Length - 1; i++)
            {
                if (arg[i] == arg[i + 1])
                {
                    doublesFound = true;
                    break;
                }
            }

            if (!doublesFound)
            {
                return false;
            }



            if (arg.Contains("ab") || arg.Contains("cd") || arg.Contains("pq") || arg.Contains("xy"))
            {
                return false;
            }

            return true;
        }

        private static bool IsVowel(char ch)
        {
            return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
        }
    }
}
