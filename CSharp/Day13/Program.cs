using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Int32;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            var happinesMatrix = ReadHappiness("input.txt");
            Puzzle1(happinesMatrix);
            Puzzle2(happinesMatrix);
        }

        private static void Puzzle1(Dictionary<string, Dictionary<string, int>> happinesMatrix)
        {
            var persons = happinesMatrix.Keys.ToList();

            var maxHappiness = FindMaxHappiness(happinesMatrix, persons);
            Console.WriteLine(maxHappiness);
        }

        private static void Puzzle2(Dictionary<string, Dictionary<string, int>> happinesMatrix)
        {
            var persons = happinesMatrix.Keys.ToList();
            AddMe(happinesMatrix, persons);

            var maxHappiness = FindMaxHappiness(happinesMatrix, persons);
            Console.WriteLine(maxHappiness);
        }

        private static int FindMaxHappiness(Dictionary<string, Dictionary<string, int>> happinesMatrix, List<string> persons)
        {
            var allPermutations = GetAllPermutations(persons.Count);
            var maxHappiness = MinValue;
            foreach (var permutation in allPermutations)
            {
                var happiness = GetHappiness(persons, happinesMatrix, permutation);
                if (happiness > maxHappiness)
                {
                    maxHappiness = happiness;
                }
            }
            return maxHappiness;
        }

        private static void AddMe(Dictionary<string, Dictionary<string, int>> happinesMatrix, List<string> persons)
        {
            foreach (var person in persons)
            {
                happinesMatrix[person]["me"] = 0;
            }

            happinesMatrix["me"] = persons.ToDictionary(person => person, value => 0);
            persons.Add("me");
        }

        private static int GetHappiness(List<string> persons, Dictionary<string, Dictionary<string, int>> happinessMatrix, List<int> order)
        {
            var result = 0;
            var n = persons.Count;
            for (var i = 0; i < n; i++)
            {
                var person = persons[order[i]];
                var leftPerson = persons[order[(i + n - 1) % n]];
                var rightPerson = persons[order[(i + 1) % n]];

                result += happinessMatrix[person][leftPerson];
                result += happinessMatrix[person][rightPerson];
            }
            return result;
        }

        private static IEnumerable<List<int>> GetAllPermutations(int permutations)
        {
            var result = Enumerable.Range(0, permutations).ToList();
            
            do
            {
                yield return result;

                var i = permutations - 2;
                while (result[i] > result[i + 1])
                {
                    i--;
                    if (i < 0)
                    {
                        yield break;
                    }
                }

                var j = permutations - 1;
                while (result[j] < result[i])
                {
                    j--;
                }

                // swap
                var t = result[i];
                result[i] = result[j];
                result[j] = t;

                i++;
                j = permutations - 1;
                while (i < j)
                {
                    // swap
                    var t2 = result[j];
                    result[j] = result[i];
                    result[i] = t2;
                    i++;
                    j--;
                }
            } while (true);
        }

        private static Dictionary<string,Dictionary<string,int>> ReadHappiness(string fileName)
        {
            var result = new Dictionary<string, Dictionary<string, int>>();
            var pattern = "(\\w+) would (gain|lose) (\\d+) happiness units by sitting next to (\\w+).";

            foreach (var line in File.ReadAllLines(fileName))
            {
                var match = Regex.Match(line, pattern);
                var person1 = match.Groups[1].Value;
                var person2 = match.Groups[4].Value;
                var happiness = Parse(match.Groups[3].Value);
                if (match.Groups[2].Value == "lose")
                {
                    happiness = -happiness;
                }
                if (result.ContainsKey(person1))
                {
                    result[person1][person2] = happiness;
                }
                else
                {
                    result[person1] = new Dictionary<string, int>() { {person2, happiness}};
                }
            }
            return result;
        }
    }
}
