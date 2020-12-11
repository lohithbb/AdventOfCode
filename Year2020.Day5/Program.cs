using System;
using System.IO;

namespace Year2020.Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2020 - Day 5");


            #region Part 1

            Console.WriteLine("Part 1");

            // input.txt should be present in the /bin directory (Properties > Copy to output directory = Copy always)
            var input = File.ReadAllLines("input.txt");
            //var input = File.ReadAllLines("example.txt");

            // store 
            int[,] seatIDs = new int[128, 8];
            
            foreach (var line in input)
            {
                string rowPartOfInput = line.Substring(0, 7);
                string colPartOfInput = line.Substring(7, 3);

                rowPartOfInput = rowPartOfInput.Replace('F', '0');
                rowPartOfInput = rowPartOfInput.Replace('B', '1');
                colPartOfInput = colPartOfInput.Replace('L', '0');
                colPartOfInput = colPartOfInput.Replace('R', '1');

                int rowInputAsInt = Convert.ToInt32(rowPartOfInput, 2);
                int colInputAsInt = Convert.ToInt32(colPartOfInput, 2);

                int seatId = rowInputAsInt * 8 + colInputAsInt;

                seatIDs[rowInputAsInt, colInputAsInt] = seatId;

                // Noticed that they are binary representation of the numbers for the SeatID
                string mutableLine = line;

                mutableLine = mutableLine.Replace('F', '0');
                mutableLine = mutableLine.Replace('B', '1');
                mutableLine = mutableLine.Replace('L', '0');
                mutableLine = mutableLine.Replace('R', '1');

                int allInputAsInt = Convert.ToInt32(mutableLine, 2);
            }

            int max = 0;
            for (int i = 0; i < seatIDs.GetLength(0); i++)
            {
                for (int j = 0; j < seatIDs.GetLength(1); j++)
                {
                    if (max < seatIDs[i,j])
                    {
                        max = seatIDs[i, j];
                    }
                }
            }

            Console.WriteLine($"Maximum seatID = {max}");

            #endregion
        }
    }
}
