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
            var costs = distances.Select(distance => input.Select(position => Math.Abs(distance - position)));
            var part01 = costs.Select(cost => cost.Sum()).Min();
            var part02 = costs.Select(cost => cost.Select(baseCost => baseCost * (baseCost + 1) / 2).Sum()).Min();

            Console.WriteLine($"{part01}\n{part02}");
        }
    }
}