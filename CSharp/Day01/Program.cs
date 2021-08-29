using System;

namespace AdventOfCode2015.Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var instructions = System.IO.File.ReadAllText("input.txt");
            Puzzle1(instructions);
        }

        public static void Puzzle1(string instructions)
        {
            var floor = 0;
            var steps = 0;
            foreach (var ch in instructions)
            {
                if (ch == '(')
                {
                    floor++;
                }

                if (ch == ')')
                {
                    floor--;
                }

                steps++;
                if (floor == -1)
                {
                    Console.WriteLine($"Santa enters basement at step {steps}");
                }
            }
            Console.WriteLine($"Santa is at floor #{floor}");
        }
    }
}
