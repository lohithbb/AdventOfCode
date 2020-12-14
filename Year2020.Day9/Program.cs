using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2020.Day9
{
    internal class Program
    {
        private const int preambleLength = 25;

        private static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2020 - Day 9");

            #region Part 1

            Console.WriteLine("Part 1");

            var input = ProcessInput();

            long invalidNumber = 0;

            {
                // iterate through the list
                for (int i = 0; i < input.Length; i++)
                {
                    long[] preamble = GetPreamble(input, i);

                    long nextNumber = GetNextNumber(input, i);

                    if (IsNextNumberValid(preamble, nextNumber))
                        continue;
                    else
                    {
                        invalidNumber = nextNumber;
                        Console.WriteLine($"Index : {i + preambleLength + 1}");
                        Console.WriteLine($"Invalid number : {invalidNumber}");
                        break;
                    }
                }
            }

            #endregion Part 1

            #region Part 2

            Console.WriteLine("Part 2");

            // find contiguous list of at least 2 numbers that sum to the invalid number
            var setSumToInvalidNumber = GetNumbersThatSumToInvalidNumber(input, invalidNumber);

            //
            var encyptionWeakness = setSumToInvalidNumber.Min<long>() + setSumToInvalidNumber.Max<long>();

            Console.WriteLine($"Encryption weakness : {encyptionWeakness}");

            #endregion Part 2
        }

        private static long[] ProcessInput()
        {
            var input = File.ReadAllLines("input.txt");
            //var input = File.ReadAllLines("example.txt");

            var output = new long[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                output[i] = long.Parse(input[i]);
            }

            return output;
        }

        private static long[] GetPreamble(long[] input, int index)
        {
            // preamble is 25 numbers
            long[] preamble = new long[preambleLength];

            for (int i = 0; i < preamble.Length; i++)
            {
                preamble[i] = input[i + index];
            }

            return preamble;
        }

        private static long GetNextNumber(long[] input, int i)
        {
            return input[i + preambleLength];
        }

        private static bool IsNextNumberValid(long[] preamble, long nextNumber)
        {
            for (int i = 0; i < preamble.Length; i++)
            {
                for (int j = i + 1; j < preamble.Length; j++)
                {
                    if (preamble[i] + preamble[j] == nextNumber)
                        return true;
                }
            }

            return false;
        }

        private static List<long> GetNumbersThatSumToInvalidNumber(long[] input, long invalidNumber)
        {
            // iterate over input, 'i' is the starting index
            for (int i = 0; i < input.Length; i++)
            {
                long sum = input[i];

                // iterate to computer the sum from index 'i'
                for (int j = i + 1; j < input.Length; j++)
                {
                    sum = sum + input[j];

                    if (sum == invalidNumber)
                    {
                        var result = new List<long>();
                        
                        for (int k = i; k <= j; k++)
                        {
                            result.Add(input[k]);
                        }

                        return result;
                    }
                }

                // need to break out of this loop too
                if (sum == invalidNumber)
                {
                    break;
                }
            }

            return null;
        }

        private static void PrintList(List<long> listOfNumbers)
        {
            foreach (var number in listOfNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}