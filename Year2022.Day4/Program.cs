using System.Text.RegularExpressions;

namespace Year2022.Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2022 - Day 4");

            #region Part 1 - Example
            {
                Console.WriteLine("Part 1 - Example");

                var exampleInput = File.ReadAllLines("example.txt");

                // regex to match input format
                var regex = new Regex("([0-9]+)-([0-9]+),([0-9]+)-([0-9]+)");
                //                     ^        ^        ^        ^
                //                     1        2        3        4
                //                     Capture Groups

                // we need to store the line numbers as we need to return them later
                var sectionAssignments = new Dictionary<int, SectionAssignment>();

                int lineNumber = 0;
                foreach (var line in exampleInput)
                {
                    ++lineNumber;

                    var match = Regex.Match(line, regex.ToString());

                    var sectionAssignment = new SectionAssignment();
                    sectionAssignment.PairOneStart = int.Parse(match.Groups[1].Value);
                    sectionAssignment.PairOneEnd = int.Parse(match.Groups[2].Value);
                    sectionAssignment.PairTwoStart = int.Parse(match.Groups[3].Value);
                    sectionAssignment.PairTwoEnd = int.Parse(match.Groups[4].Value);

                    sectionAssignments.Add(lineNumber, sectionAssignment);
                }

                var sectionAssingmentLineNumbersWithOverlap = new List<int>();

                foreach (var sectionAssignment in sectionAssignments)
                {
                    if (CheckForCompleteOverlap(sectionAssignment.Value))
                    {
                        sectionAssingmentLineNumbersWithOverlap.Add(sectionAssignment.Key);
                    }
                }

                Console.WriteLine(
                    "Number of pairs with complete overlap : {0}",
                    sectionAssingmentLineNumbersWithOverlap.Count);
            }
            #endregion

            #region Part 1
            {
                Console.WriteLine("Part 1");

                var input = File.ReadAllLines("input.txt");

                // regex to match input format
                var regex = new Regex("([0-9]+)-([0-9]+),([0-9]+)-([0-9]+)");
                //                     ^        ^        ^        ^
                //                     1        2        3        4
                //                     Capture Groups

                // we need to store the line numbers as we need to return them later
                var sectionAssignments = new Dictionary<int, SectionAssignment>();

                int lineNumber = 0;
                foreach (var line in input)
                {
                    ++lineNumber;

                    var match = Regex.Match(line, regex.ToString());

                    var sectionAssignment = new SectionAssignment();
                    sectionAssignment.PairOneStart = int.Parse(match.Groups[1].Value);
                    sectionAssignment.PairOneEnd = int.Parse(match.Groups[2].Value);
                    sectionAssignment.PairTwoStart = int.Parse(match.Groups[3].Value);
                    sectionAssignment.PairTwoEnd = int.Parse(match.Groups[4].Value);

                    sectionAssignments.Add(lineNumber, sectionAssignment);
                }

                var sectionAssingmentLineNumbersWithOverlap = new List<int>();

                foreach (var sectionAssignment in sectionAssignments)
                {
                    if (CheckForCompleteOverlap(sectionAssignment.Value))
                    {
                        sectionAssingmentLineNumbersWithOverlap.Add(sectionAssignment.Key);
                    }
                }

                Console.WriteLine(
                    "Number of pairs with complete overlap : {0}",
                    sectionAssingmentLineNumbersWithOverlap.Count);
            }
            #endregion

            #region Part 2
            {
                Console.WriteLine("Part 2");

                var input = File.ReadAllLines("input.txt");

                // regex to match input format
                var regex = new Regex("([0-9]+)-([0-9]+),([0-9]+)-([0-9]+)");
                //                     ^        ^        ^        ^
                //                     1        2        3        4
                //                     Capture Groups

                // we need to store the line numbers as we need to return them later
                var sectionAssignments = new Dictionary<int, SectionAssignment>();

                int lineNumber = 0;
                foreach (var line in input)
                {
                    ++lineNumber;

                    var match = Regex.Match(line, regex.ToString());

                    var sectionAssignment = new SectionAssignment();
                    sectionAssignment.PairOneStart = int.Parse(match.Groups[1].Value);
                    sectionAssignment.PairOneEnd = int.Parse(match.Groups[2].Value);
                    sectionAssignment.PairTwoStart = int.Parse(match.Groups[3].Value);
                    sectionAssignment.PairTwoEnd = int.Parse(match.Groups[4].Value);

                    sectionAssignments.Add(lineNumber, sectionAssignment);
                }

                var sectionAssingmentLineNumbersWithOverlap = new List<int>();

                foreach (var sectionAssignment in sectionAssignments)
                {
                    if (CheckForAnyOverlap(sectionAssignment.Value))
                    {
                        sectionAssingmentLineNumbersWithOverlap.Add(sectionAssignment.Key);
                    }
                }

                Console.WriteLine(
                    "Number of pairs with any overlap : {0}",
                    sectionAssingmentLineNumbersWithOverlap.Count);

            }
            #endregion
        }

        /// <summary>
        ///     Returns true if either pair completely overlaps/encompasses the other. False otherwise.
        /// </summary>
        private static bool CheckForCompleteOverlap(SectionAssignment sa)
        {
            if ((sa.PairOneStart <= sa.PairTwoStart && sa.PairOneEnd >= sa.PairTwoEnd) ||
                (sa.PairTwoStart <= sa.PairOneStart && sa.PairTwoEnd >= sa.PairOneEnd))
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        ///     Returns true if either pair has any overlaps/encompasses the other. False otherwise.
        /// </summary>
        private static bool CheckForAnyOverlap(SectionAssignment sa)
        {
            if ((sa.PairOneStart <= sa.PairTwoStart && sa.PairOneEnd >= sa.PairTwoStart) ||
                (sa.PairOneStart > sa.PairTwoStart && sa.PairOneStart <= sa.PairTwoEnd))
            {
                return true;
            }
            else
                return false;
        }
    }
}