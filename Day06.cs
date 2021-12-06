using System;
using System.Linq;
using Util;

namespace Day06
{
    class Day06
    {
        static void Main(string[] args)
        {
            int[] input = Data.ToIntArray("D:/AoC/Data/06.txt", ',');

            long[] fish = new long[9];
            for (int i = 0; i < input.Length; i++)
            {
                fish[input[i]]++;
            }

            Console.WriteLine(Simulate((long[])fish.Clone(), 80).Sum());
            Console.WriteLine(Simulate((long[])fish.Clone(), 256).Sum());

        }

        static long[] Simulate(long[] fish, int days)
        {
            do
            {
                long spawn = fish[0];

                for (int i = 0; i < fish.Length - 1; i++)
                {
                    fish[i] = fish[i + 1];
                }
                fish[6] += spawn;
                fish[8] = spawn;

                days--;
            } while (days > 0);

            return fish;
        }

    }
}

