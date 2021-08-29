using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            var listPositions = System.IO.File.ReadAllLines("list.txt");

            var totalPaper = 0L;
            var totalRibbon = 0L;

            foreach (var position in listPositions)
            {
                var dimensions = ParseDimensions(position);
                var paperSize = CalculateSurfaces(dimensions);

                totalPaper += paperSize;
                var ribbonLength = CalculateRibbonLength(dimensions);
                totalRibbon += ribbonLength;

            }
            Console.WriteLine($"The elves must order {totalPaper} square feet of wrapping paper");
            Console.WriteLine($"They should also order {totalRibbon} feet of ribbon");
        }

        private static int CalculateRibbonLength(List<int> dimensions)
        {
            var max = dimensions.Max();
            var loop = (dimensions.Sum() - max) * 2;
            var bow = dimensions.Aggregate(1, (acc, next) => acc * next);
            return loop + bow;
        }

        private static int CalculateSurfaces(List<int> dimsensions)
        {
            var surfaces =  new List<int>()
            {
                dimsensions[0] * dimsensions[1],
                dimsensions[1] * dimsensions[2],
                dimsensions[2] * dimsensions[0]
            };
            var min = surfaces.Min();
            var paperSize = surfaces.Sum() * 2 + min;
            return paperSize;
        }

        private static List<int> ParseDimensions(string position)
        {
            return position.Split("x".ToCharArray()).ToList().ConvertAll(int.Parse);
        }
    }
}
