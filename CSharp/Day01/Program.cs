using System;

namespace AdventOfCode2015.Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var instructions = System.IO.File.ReadAllText("input.txt");

            var floor = 0;
            var steps = 0;
            bool basementVisisted = false;
            foreach (var ch in instructions)
            {
                switch (ch)
                {
                    case '(':
                        floor++;
                        break;
                    case ')':
                        floor--;
                        break;
                }
                steps++;

                if (floor == -1 && !basementVisisted)
                {
                    Console.WriteLine($"Santa enters basement at step {steps}");
                    basementVisisted = true;
                }
            }
            Console.WriteLine($"Santa is at floor #{floor}");
        }
    }
}
