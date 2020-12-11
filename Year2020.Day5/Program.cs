using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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


            #region Part 2

            Print2DArray(seatIDs);
            // its somewhere in the middle, I can see it

            var seatIDKeyValuePairs = new Dictionary<Tuple<int,int>,int>();
            for (int i = 0; i < seatIDs.GetLength(0); i++)
            {
                for (int j = 0; j < seatIDs.GetLength(1); j++)
                {
                    seatIDKeyValuePairs.Add(new Tuple<int,int>(i,j), seatIDs[i,j]);
                }
            }

            var seat = seatIDKeyValuePairs
                .Where(x => x.Value == 0 && x.Key.Item1 > 2) // "> 2" determined using the printed output
                .First();

            Console.WriteLine($"Your seat : {seat.Key.Item1} , {seat.Key.Item2}");
            
            {
                var seatId = seat.Key.Item1 * 8 + seat.Key.Item2;
                Console.WriteLine($"Your seat Id : {seatId}");
            }
                        
            #endregion

        }


        public static void Print2DArray(int[,] input)
        {
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    Console.Write(input[i,j] + " ");
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
