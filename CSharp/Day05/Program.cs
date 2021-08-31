using System;
using System.Linq;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input.txt");
            var niceStrings = lines.ToList().Count(IsNiceLine);
            Console.WriteLine($"There are {niceStrings} nice strings");
            var veryNiceStrings = lines.ToList().Count(IsVeryNice);
            Console.WriteLine($"There are {veryNiceStrings} very nice strings");
        }

        private static bool IsVeryNice(string arg)
        {
            bool pairFound = false;
            for (int i = 0; i < arg.Length - 3; i++)
            {
                var str = arg.Substring(i, 2);
                var idx = arg.LastIndexOf(str);
                if (idx > i+1)
                {
                    pairFound = true;
                    break;
                }
            }

            if (!pairFound)
            {
                return false;
            }

            bool doublesFound = false;
            for (int i = 0; i < arg.Length - 2; i++)
            {
                if (arg[i] == arg[i + 2])
                {
                    doublesFound = true;
                    break;
                }
            }

            if (!doublesFound)
            {
                return false;
            }
            return true;
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
