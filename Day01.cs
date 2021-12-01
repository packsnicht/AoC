using System;
using Util;

namespace Day01
{
    class Day01
    {
        static void Main(string[] args)
        {
            int[] input = Data.ToIntArray("D:/AoC/Data/01.txt", '\n');

            Console.WriteLine(Part01(input)); 
            Console.WriteLine(Part02(input));

        }

        static int Part01(int[] input)
        {
            int increased = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] < input[i]) increased++;
            }
            return increased;
        }

        static int Part02(int[] input)
        {
            int increased = 0;
            for (int i = 1; i < input.Length - 2; i++)
            {
                var previous = input[i - 1] + input[i] + input[i + 1];
                var current = input[i] + input[i + 1] + input[i + 2];

                if (previous < current) increased++;
            }
            return increased;
        }
    }
}
