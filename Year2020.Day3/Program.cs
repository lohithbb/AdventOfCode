using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Year2020.Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2020 - Day 2");

            // input.txt should be present in the /bin directory (Properties > Copu to output directory = Copy always)
            var input = File.ReadAllLines("input.txt");

            // prepare input data       
            // convert string[] -> char[][] (jagged)
            char[][] charInput = ConvertString1DArrayToJaggedChar2DArray(input);

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

            while (x + deltaX < charInput.Length)
            {
                x = x + deltaX;
                y = (y + deltaY) % charInput[x].Length;

                if (charInput[x][y] == '.')
                {
                    charInput[x][y] = 'O';
                    continue;
                }
                if (charInput[x][y] == '#')
                {
                    charInput[x][y] = 'X';
                    numberOfTrees++;
                    continue;
                }
            }

            //PrintChar2DArray(charInput);
            Console.WriteLine($"Number of trees encountered : {numberOfTrees}");

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

    }
}
