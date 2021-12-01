using System;
using Util;

namespace Day01
{
    class Day01
    {
        static void Main(string[] args)
        {
            int[] input = Data.ToIntArray("D:/AoC/Data/01.txt");

            Console.WriteLine(Part01(input)); 
            Console.WriteLine(Part02(input));

        }

        static int Part01(int[] input)
        {
            int count = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] < input[i]) count++;
            }
            return count;
        }

        static int Part02(int[] input)
        {
            int count = 0;
            for (int i = 1; i < input.Length - 2; i++)
            {
                var previous = input[i - 1] + input[i] + input[i + 1];
                var current = input[i] + input[i + 1] + input[i + 2];

                if (previous < current) count++;
            }
            return count;
        }
    }
}
