using System.Text.RegularExpressions;

namespace Year2022.Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2022 - Day 5");

            #region Part 1 - Example
            {
                Console.WriteLine("Part 1 - Example");

                var exampleInput = File.ReadAllLines("example.txt");

                Dictionary<int, Stack<char>> stacks = new Dictionary<int, Stack<char>>();
                Dictionary<int, int> positionalIndexes = new Dictionary<int, int>();

                ParseDataForStackCrateInfo(exampleInput, stacks, positionalIndexes);

                RunInstructions(exampleInput, stacks, positionalIndexes);
                // TODO - pipe output of refactored function to this
                //string[] instuctions;

                // now to parse for instuctions
                // ... and enact them?


                //{
                //    Regex r = new Regex(@"^move ([0-9]+) from ([0-9]+) to ([0-9]+)");
                //    var instructions = exampleInput
                //        .Where(l => r.IsMatch(l))
                //        .ToList<string>();

                //    foreach (var instruction in instructions)
                //    {
                //        var matches = Regex.Matches(instruction, r.ToString()).Cast<Match>().First().Groups;
                //        int noOfCratesToMove = int.Parse(matches[1].Value);
                //        int fromStack = int.Parse(matches[2].Value);
                //        int toStack = int.Parse(matches[3].Value);

                //        // do the moving
                //        while (noOfCratesToMove != 0)
                //        {
                //            // pop from the FROM stack
                //            var crate = stacks[fromStack].Pop();

                //            // push onto the TO stack
                //            stacks[toStack].Push(crate);

                //            noOfCratesToMove--;
                //        }
                //    }


                //}

                Console.Write("The crates at the top of each stack are : ");
                foreach (var s in stacks)
                {
                    Console.Write(s.Value.Peek() + "  ");                    
                }
            }
            #endregion

            #region Part 1
            {
                Console.WriteLine("Part 1");

                //var input = File.ReadAllLines("input.txt");
            }
            #endregion

            #region Part 2
            {
                Console.WriteLine("Part 2");

                //var input = File.ReadAllLines("input.txt");
            }
            #endregion
        }

        private static void ParseDataForStackCrateInfo(string[] input, Dictionary<int, Stack<char>> stacks, Dictionary<int, int> positionalIndexes)
        {
            // this is the line with the stack numbers (goes  1   2   3  etc.)
            int lineWithStackNumbers = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var currentLine = input[i];
                var pattern = "([0-9])";
                if (Regex.IsMatch(currentLine, pattern))
                {
                    var matches = Regex.Matches(currentLine, pattern).Cast<Match>();
                    foreach (var match in matches)
                    {
                        int stackNumber = int.Parse(match.Value);

                        // first pass, we make the empty stacks
                        stacks.Add(stackNumber, new Stack<char>());

                        // and store the position to retrive the crates later
                        positionalIndexes.Add(stackNumber, match.Index);
                    }

                    // once we find out how many stacks there are (however many there may be)
                    // we need to iterate upwards from that row to load the objects with the crates
                    lineWithStackNumbers = i;
                    break;
                }
            }

            // we want to iterate backward, from the line right above the stack numbers to 0
            for (int i = lineWithStackNumbers - 1; i >= 0; i--)
            {
                var currentLine = input[i];

                foreach (var positionalIndex in positionalIndexes)
                {
                    var mark = currentLine[positionalIndex.Value];
                    if (!char.IsWhiteSpace(mark))
                    {
                        stacks[positionalIndex.Key].Push(currentLine[positionalIndex.Value]);
                    }
                }
            }
        }

        private static void RunInstructions(string[] input, Dictionary<int, Stack<char>> stacks, Dictionary<int, int> positionalIndexes)
        {
            Regex r = new Regex(@"^move ([0-9]+) from ([0-9]+) to ([0-9]+)");
            var instructions = input
                .Where(l => r.IsMatch(l))
                .ToList<string>();

            foreach (var instruction in instructions)
            {
                var matches = Regex.Matches(instruction, r.ToString()).Cast<Match>().First().Groups;
                int noOfCratesToMove = int.Parse(matches[1].Value);
                int fromStack = int.Parse(matches[2].Value);
                int toStack = int.Parse(matches[3].Value);

                // do the moving
                while (noOfCratesToMove != 0)
                {
                    // pop from the FROM stack
                    var crate = stacks[fromStack].Pop();

                    // push onto the TO stack
                    stacks[toStack].Push(crate);

                    noOfCratesToMove--;
                }
            }

        }
    }
}