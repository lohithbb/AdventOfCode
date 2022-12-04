using System.Text.RegularExpressions;

namespace Year2022.Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2022 - Day 3");

            #region Part 1 - Example
            {
                Console.WriteLine("Part 1 - Example");

                var exampleInput = File.ReadAllLines("example.txt");

                int sumOfPriorities = 0;

                foreach (var line in exampleInput)
                {
                    // split the string to get contents of each compartment
                    // range operator is perfect for this
                    string firstHalf = line[..(line.Length / 2)];
                    string secondHalf = line[(line.Length / 2)..];

                    var commonItem = firstHalf.Intersect(secondHalf).First();

                    var priority = GetPriority(commonItem);

                    sumOfPriorities += priority;
                }

                Console.WriteLine($"Sum of priorities: {sumOfPriorities}");
            }
            #endregion

            #region Part 1
            {
                Console.WriteLine("Part 1");

                var input = File.ReadAllLines("input.txt");

                int sumOfPriorities = 0;

                foreach (var line in input)
                {
                    // split the string to get contents of each compartment
                    // range operator is perfect for this
                    string firstHalf = line[..(line.Length / 2)];
                    string secondHalf = line[(line.Length / 2)..];

                    var commonItem = firstHalf.Intersect(secondHalf).First();

                    var priority = GetPriority(commonItem);

                    sumOfPriorities += priority;
                }

                Console.WriteLine($"Sum of priorities: {sumOfPriorities}");
            }
            #endregion

            #region Part 2
            {
                Console.WriteLine("Part 2");

                var input = File.ReadAllLines("input.txt");

                int sumOfPriorities = 0;

                for (int i = 0; i < input.Length; i = i + 3)
                {
                    var firstLine = input[i];
                    var secondLine = input[i + 1];
                    var thirdLine = input[i + 2];

                    var commonItem = firstLine.Intersect(secondLine).Intersect(thirdLine).First();
                    
                    var priority = GetPriority(commonItem);

                    sumOfPriorities += priority;
                }

                Console.WriteLine($"Sum of priorities: {sumOfPriorities}");
            }
            #endregion
        }

        private static int GetPriority(char commonItem)
        {
            var lowercase = new Regex(@"[a-z]");
            var uppercase = new Regex(@"[A-Z]");

            if (lowercase.IsMatch(commonItem.ToString()))
            {
                // the nuance here is that casting a char to int has specific values
                // (int) 'a' = 97
                // priority for 'a' = 1
                return ((int)commonItem - 96);
            }
            else if (uppercase.IsMatch(commonItem.ToString()))
            {
                // the nuance here is that casting a char to int has specific values
                // (int) 'A' = 65
                // priority for 'A' = 27
                return ((int)commonItem - 38);
            }
            else
                throw new Exception($"Unmatched char supplied: {commonItem}");
        }
    }
}