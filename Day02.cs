using System;
using Util;

namespace Day02
{
    public class Day02
    {
        static void Main(string[] args)
        {
            string[] input = Data.ToStringArray("D:/AoC/Data/02.txt");

            Console.WriteLine(Part01(input));
            Console.WriteLine(Part02(input));
        }

        static int Part01(string[] input)
        {
            int horizontalDisplacement = 0;
            int verticalDisplacement = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (string.IsNullOrEmpty(input[i])) continue;

                switch (input[i].Substring(0, 1))
                {
                    case "u": verticalDisplacement -= int.Parse(input[i].Substring(input[i].Length - 2));
                        break;
                    case "d": verticalDisplacement += int.Parse(input[i].Substring(input[i].Length - 2)); 
                        break;
                    case "f": horizontalDisplacement += int.Parse(input[i].Substring(input[i].Length - 2)); 
                        break;
                    default: throw new Exception("FUCK");
                }
            }

            return horizontalDisplacement * verticalDisplacement;
        }

        static int Part02(string[] input)
        {
            int horizontalDisplacement = 0;
            int verticalDisplacement = 0;
            int aim = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (string.IsNullOrEmpty(input[i])) continue;

                switch (input[i].Substring(0, 1))
                {
                    case "u": aim -= int.Parse(input[i].Substring(input[i].Length - 2)); 
                        break;
                    case "d": aim += int.Parse(input[i].Substring(input[i].Length - 2)); 
                        break;
                    case "f": int displacement = int.Parse(input[i].Substring(input[i].Length - 2)); horizontalDisplacement += displacement; verticalDisplacement +=  displacement * aim; 
                        break;
                    default: throw new Exception("FUCK");
                }
            }

            return horizontalDisplacement * verticalDisplacement;
        }
    }
}