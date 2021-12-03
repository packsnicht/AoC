using System;
using System.Collections.Generic;
using Util;

namespace Day03
{
    class Day03
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>(Data.ToStringArray("D:/AoC/Data/03.txt"));
            
            Console.WriteLine(Part01(input));
            Console.WriteLine(Part02(input));
        }

        static int CountSetBitsInPosition(List<string> input, int position)
        {
            int setBits = 0;

            for (int row = 0; row < input.Count; row++)
            {
                setBits += input[row].Substring(position, 1) == "1" ? 1 : 0;
            }

            return setBits;
        }

        static int[] CountSetBits(List<string> input)
        {

            int[] setBits = new int[input[0].Length];

            for (int position = 0; position < input[0].Length; position++)
            {
                setBits[position] = CountSetBitsInPosition(input, position);
            }

            return setBits;
        }

        static int Part01(List<string> input)
        {
            int gamma = 0;
            int epsilon = 0;

            int[] setBits = CountSetBits(input);

            for (int i = 0; i < input[0].Length; i++)
            {
                if (setBits[i] > input.Count * 0.5) gamma |= 1 << 11-i;
            }

            epsilon = ~gamma & 0xFFF;

            return epsilon * gamma;
        }
       
        static int Part02(List<string> input)
        {
            List<string> oxigenGeneratorRatings = new List<string>(input);
            List<string> co2ScrubberRatings = new List<string>(input);

            for (int position = 0; position < input[0].Length; position++)
            {
                string oxigenGeneratorBitToLookFor = CountSetBitsInPosition(oxigenGeneratorRatings, position) >= oxigenGeneratorRatings.Count * 0.5f ? "1" : "0";

                for (int i = oxigenGeneratorRatings.Count - 1; i >= 0; i--)
                {
                    if (oxigenGeneratorRatings.Count == 1) break;
                    if (!oxigenGeneratorRatings[i].Substring(position, 1).Equals(oxigenGeneratorBitToLookFor)) oxigenGeneratorRatings.RemoveAt(i);
                }

                string co2ScrubberBitToLookFor = CountSetBitsInPosition(co2ScrubberRatings, position) >= co2ScrubberRatings.Count * 0.5f ? "0" : "1";

                for (int i = co2ScrubberRatings.Count - 1; i >= 0; i--)
                {
                    if (co2ScrubberRatings.Count == 1) break;
                    if (!co2ScrubberRatings[i].Substring(position, 1).Equals(co2ScrubberBitToLookFor)) co2ScrubberRatings.RemoveAt(i);
                }
            }

            return Convert.ToInt32(oxigenGeneratorRatings[0], 2) * Convert.ToInt32(co2ScrubberRatings[0], 2);
        }
    }
}
