using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Day07
{
    class Day07
    {
        static void Main(string[] args)
        {
            var input = Data.ToIntArray("D:/AoC/Data/07.txt", ',');
            var min = input.Min();
            var max = input.Max();
            var distances = Enumerable.Range(min, max - min);
            var costs = distances.Select(d => input.Select(i => Math.Abs(d - i)));
            var part01 = costs.Select(c => c.Sum()).Min();
            var part02 = costs.Select(c => c.Select(i => i * (i + 1) / 2).Sum()).Min();

            Console.WriteLine($"{part01}\n{part02}");
        }
    }
}