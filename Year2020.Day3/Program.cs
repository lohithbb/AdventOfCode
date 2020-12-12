using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2020.Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2020 - Day 3");

            // input.txt should be present in the /bin directory (Properties > Copy to output directory = Copy always)
            var input = File.ReadAllLines("input.txt");

            // prepare input data       
            // convert string[] -> char[][] (jagged)
            char[][] slope = ConvertString1DArrayToJaggedChar2DArray(input);
            
            //PrintChar2DArray(charInput);

            #region Part 1
            Console.WriteLine("Part 1");

            int numberOfTrees = 0;

            // start at [0,0] -> [i,j]
            // move [1,3] -> 1 down, 3 across
            int x = 0;
            int y = 0;

            int deltaX = 1;
            int deltaY = 3;

            while (x + deltaX < slope.Length)
            {
                x = x + deltaX;
                y = (y + deltaY) % slope[x].Length;

                if (slope[x][y] == '.')
                {
                    slope[x][y] = 'O';
                    continue;
                }
                if (slope[x][y] == '#')
                {
                    slope[x][y] = 'X';
                    numberOfTrees++;
                    continue;
                }
            }

            //PrintChar2DArray(charInput);
            Console.WriteLine($"Slope : ({deltaX},{deltaY})");
            Console.WriteLine($"Number of trees encountered : {numberOfTrees}");

            #endregion


            #region Part 2
            Console.WriteLine("Part 2");

            // required for part 2
            var inputSlopeVectors = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1,1),
                new Tuple<int, int>(1,3),
                new Tuple<int, int>(1,5),
                new Tuple<int, int>(1,7),
                new Tuple<int, int>(2,1)
            };
            var results = new Dictionary<Tuple<int, int>, long>();

            foreach (var slopeVector in inputSlopeVectors)
            {
                // input gets mutated so we need to generate a fresh one each time
                slope = ConvertString1DArrayToJaggedChar2DArray(input);

                numberOfTrees = TraverseSlope(slopeVector.Item1, slopeVector.Item2, slope);

                results.Add(slopeVector, numberOfTrees);
            }

            long productOfSlopes = results.Values.Aggregate(
                func: (p, i) => p * i);

            Console.WriteLine($"Product of slopes : {productOfSlopes}");
            #endregion

        }

        static char[][] ConvertString1DArrayToJaggedChar2DArray(string[] stringArray)
        {
            char[][] charArray = new char[stringArray.Length][];

            for (int i = 0; i < stringArray.Length; i++)
            {
                charArray[i] = stringArray[i].ToArray();
            }

            return charArray;
        }

        static void PrintChar2DArray(char[][] char2DArray)
        {
            for (int i = 0; i < char2DArray.Length; i++)
            {
                Console.WriteLine(new string(char2DArray[i]));
            }
        }

        static int TraverseSlope(int deltaX, int deltaY, char[][] slope)
        {
            int numberOfTrees = 0;

            // start at [0,0] -> [i,j]
            // move [1,3] -> 1 down, 3 across
            int x = 0;
            int y = 0;

            while (x + deltaX < slope.Length)
            {
                x = x + deltaX;
                y = (y + deltaY) % slope[x].Length;

                if (slope[x][y] == '.')
                {
                    slope[x][y] = 'O';
                    continue;
                }
                if (slope[x][y] == '#')
                {
                    slope[x][y] = 'X';
                    numberOfTrees++;
                    continue;
                }
            }

            //PrintChar2DArray(slope);
            Console.WriteLine($"Slope : ({deltaX},{deltaY})");
            Console.WriteLine($"Number of trees encountered : {numberOfTrees}");
            
            return numberOfTrees;
        }

    }
}
