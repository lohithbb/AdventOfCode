using System;
using System.IO;
using System.Linq;

namespace Year2020.Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2020 - Day 6");


            #region Part 1

            Console.WriteLine("Part 1");

            // input.txt should be present in the /bin directory (Properties > Copy to output directory = Copy always)
            var input = File.ReadAllText("input.txt");
            //var input = File.ReadAllText("example.txt");

            // split the input into string[] as groups are separated by an empty line
            string doubleNewline = Environment.NewLine + Environment.NewLine;
            var groupedInput = input.Split(doubleNewline);

            // sanitise input
            var sanitisedInput = groupedInput
                // remove newlines
                .Select(i => i.Replace(Environment.NewLine, ""))
                // in each group, remove duplicates and arrange alphabetically
                .Select(c => String.Concat(c.ToCharArray().OrderBy(c => c).Distinct()));

            // a count is essentially the sum of distinct characters in a group
            var sumOfCountsPart1 = sanitisedInput
                .Select(l => l.Count())
                .Sum();

            // print output
            //foreach (var line in sanitisedInput)
            //{
            //    Console.WriteLine(line);
            //}
            Console.WriteLine($"Sum of counts : {sumOfCountsPart1}");

            #endregion


            #region Part 2

            Console.WriteLine("Part 2");

            // need to slightly change the way the input gets sanitised
            sanitisedInput = groupedInput
                // replace newlines with a space
                .Select(g => g.Replace(Environment.NewLine, " "));

            var sumOfCountsPart2 = sanitisedInput
                // split each group into each persons
                .Select(g => g.Split(" "))

                // not a bad code relic - this shows the inner workings of how i developed the aggregate function
                //.Select(g => g.Aggregate(
                //    "qwertyuiopasdfghjklzxcvbnm", // faceroll on the keyboard
                //    (result, next) => new String(result.Intersect(next).ToArray())
                //    ));

                // Intersect returns a IEnumerable<char> - so we need to convert that back to a string
                .Select(g => g.Aggregate((a, b) => new string(a.Intersect(b).ToArray())))
                .Select(g => g.Count())
                .Sum();

            Console.WriteLine($"Sum of counts : {sumOfCountsPart2}");

            #endregion
        }
    }
}
