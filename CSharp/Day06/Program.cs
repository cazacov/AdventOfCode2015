using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = System.IO.File.ReadAllLines("input.txt");

            Puzzle1(commands);
            Puzzle2(commands);
        }

        private static void Puzzle1(string[] commands)
        {
            var lights = new bool[1000, 1000];
            foreach (var str in commands)
            {
                var command = new Command(str);

                for (int x = command.From.X; x <= command.To.X; x++)
                {
                    for (int y = command.From.Y; y <= command.To.Y; y++)
                    {
                        switch (command.Action)
                        {
                            case Action.TurnOn:
                                lights[x, y] = true;
                                break;
                            case Action.TurnOff:
                                lights[x, y] = false;
                                break;
                            case Action.Toggle:
                                lights[x, y] = !lights[x, y];
                                break;
                        }
                    }
                }
            }

            var onCount = 0;
            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    if (lights[x, y])
                    {
                        onCount++;
                    }
                }
            }

            Console.WriteLine($"{onCount} lights are lit");
        }

        private static void Puzzle2(string[] commands)
        {
            var lights = new int[1000, 1000];
            foreach (var str in commands)
            {
                var command = new Command(str);

                for (int x = command.From.X; x <= command.To.X; x++)
                {
                    for (int y = command.From.Y; y <= command.To.Y; y++)
                    {
                        switch (command.Action)
                        {
                            case Action.TurnOn:
                                lights[x, y] +=1;
                                break;
                            case Action.TurnOff:
                                if (lights[x, y] > 0)
                                {
                                    lights[x, y] -= 1;
                                }
                                break;
                            case Action.Toggle:
                                lights[x, y] += 2;
                                break;
                        }
                    }
                }
            }

            var brightness = 0L;
            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    brightness += lights[x, y];
                }
            }

            Console.WriteLine($"Total brightness: {brightness}");
        }
    }
}
