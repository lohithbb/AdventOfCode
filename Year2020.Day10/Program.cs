using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2020.Day10
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2020 - Day 9");

            #region Part 1

            Console.WriteLine("Part 1");

            {
                var sortedListOfAdapters = ProcessInput();

                var deltas = ComputeDeltas(sortedListOfAdapters);

                var nDelta1Jolt = deltas.Where(d => d == 1).Count();
                var nDelta3Jolt = deltas.Where(d => d == 3).Count();

                var product = nDelta1Jolt * nDelta3Jolt;

                Console.WriteLine($"Number of 1-jolt differences : {nDelta1Jolt}");
                Console.WriteLine($"Number of 3-jolt differences : {nDelta3Jolt}");
                Console.WriteLine($"Product : {product}");
            }

            #endregion Part 1

            #region Part 2

            Console.WriteLine("Part 2");

            {
                var sortedListOfAdapters = ProcessInput();

                // list to store valid adapter combinations
                var validAdapterCombinations = new List<int[]>();
                // transient list to store valid adapter combinations
                var validAdapterCombinationsInThisIteration = new List<int[]>();

                // list to store solutions to test
                var adapterCombinations = new List<int[]>();
                adapterCombinations.Add(sortedListOfAdapters);

                // while there are combinations to test
                while (adapterCombinations.Any())
                {
                    // empty list of valid combinations in this iteration (as it has just started)
                    validAdapterCombinationsInThisIteration.RemoveAll(x => true);

                    // foreach of the combinations, test if they are valid and store them
                    foreach (var combination in adapterCombinations)
                    {
                        if (IsCombinationValid(combination))
                        {
                            validAdapterCombinations.Add(combination);
                            validAdapterCombinationsInThisIteration.Add(combination);
                        }
                    }

                    // remove combinations and add new ones
                    adapterCombinations.RemoveAll(x => true);

                    // produce combinations with 1 less element from valid combinations
                    var newAdapterCombinations = ProduceCombinations(validAdapterCombinationsInThisIteration);

                    // add to adapter combinations to test
                    adapterCombinations.AddRange(newAdapterCombinations);
                }
            }

            #endregion Part 2
        }

        private static int[] ProcessInput()
        {
            //var input = File.ReadAllLines("input.txt");
            var input = File.ReadAllLines("example.txt");

            var rawOutput = input.Select(line => int.Parse(line)).ToList();

            // add 0 for starting point
            rawOutput.Add(0);

            // add Max() + 3 for the ending point
            var max = rawOutput.Max();
            rawOutput.Add(max + 3);

            var output = rawOutput
                .OrderBy(i => i)
                .ToArray();

            return output;
        }

        private static int[] ComputeDeltas(int[] input)
        {
            var output = new int[input.Length - 1];

            for (int i = 0; i < input.Length - 1; i++)
            {
                output[i] = input[i + 1] - input[i];
            }

            return output;
        }

        private static bool IsCombinationValid(int[] combination)
        {
            var deltas = ComputeDeltas(combination);

            return !deltas.Any(d => (d != 1 && d != 3));
        }

        private static List<int[]> ProduceCombinations(List<int[]> adapterCombinations)
        {
            var output = new List<int[]>();

            foreach (var combination in adapterCombinations)
            {
                // iterate over the array and remove each element
                for (int i = 0; i < combination.Length; i++)
                {
                    var c = combination.ToList();
                    c.RemoveAt(i);

                    // store the resulting combination in the output
                    output.Add(c.ToArray());
                }
            }

            return output;
        }
    }
}