using System.Text.RegularExpressions;

namespace Year2022.Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2022 - Day 6");

            #region Part 1 - Example 1
            {
                Console.WriteLine("Part 1 - Example 1");

                var exampleInput = File.ReadAllText("example1.txt");

                int distinctNumberOfChar = 4;
                int finalOffset = 0;

                for (int i = 0; i < exampleInput.Length; i++)
                {
                    // take the 4 character long substring from ... where we are in the string
                    var substring = exampleInput
                        .ToCharArray()
                        .Skip(i)
                        .Take(distinctNumberOfChar)
                        .ToArray();

                    if (CheckForRepeatedCharacters(substring))
                    {
                        finalOffset = i;
                        break;
                    }
                }

                var charactersBeforeStartOfPacketMarker = finalOffset + distinctNumberOfChar;

                Console.WriteLine(
                    "{0} characters need to be processed before the first start-of-packet marker is detected",
                    charactersBeforeStartOfPacketMarker);
            }
            #endregion

            #region Part 1 - Example 2
            {
                Console.WriteLine("Part 1 - Example 2");

                var exampleInput = File.ReadAllText("example2.txt");

                int distinctNumberOfChar = 4;
                int finalOffset = 0;

                for (int i = 0; i < exampleInput.Length; i++)
                {
                    // take the 4 character long substring from ... where we are in the string
                    var substring = exampleInput
                        .ToCharArray()
                        .Skip(i)
                        .Take(distinctNumberOfChar)
                        .ToArray();

                    if (CheckForRepeatedCharacters(substring))
                    {
                        finalOffset = i;
                        break;
                    }
                }

                var charactersBeforeStartOfPacketMarker = finalOffset + distinctNumberOfChar;

                Console.WriteLine(
                    "{0} characters need to be processed before the first start-of-packet marker is detected",
                    charactersBeforeStartOfPacketMarker);
            }
            #endregion

            #region Part 1 - Example 3
            {
                Console.WriteLine("Part 1 - Example 3");

                var exampleInput = File.ReadAllText("example3.txt");

                int distinctNumberOfChar = 4;
                int finalOffset = 0;

                for (int i = 0; i < exampleInput.Length; i++)
                {
                    // take the 4 character long substring from ... where we are in the string
                    var substring = exampleInput
                        .ToCharArray()
                        .Skip(i)
                        .Take(distinctNumberOfChar)
                        .ToArray();

                    if (CheckForRepeatedCharacters(substring))
                    {
                        finalOffset = i;
                        break;
                    }
                }

                var charactersBeforeStartOfPacketMarker = finalOffset + distinctNumberOfChar;

                Console.WriteLine(
                    "{0} characters need to be processed before the first start-of-packet marker is detected",
                    charactersBeforeStartOfPacketMarker);
            }
            #endregion

            #region Part 1 - Example 4
            {
                Console.WriteLine("Part 1 - Example 4");

                var exampleInput = File.ReadAllText("example4.txt");

                int distinctNumberOfChar = 4;
                int finalOffset = 0;

                for (int i = 0; i < exampleInput.Length; i++)
                {
                    // take the 4 character long substring from ... where we are in the string
                    var substring = exampleInput
                        .ToCharArray()
                        .Skip(i)
                        .Take(distinctNumberOfChar)
                        .ToArray();

                    if (CheckForRepeatedCharacters(substring))
                    {
                        finalOffset = i;
                        break;
                    }
                }

                var charactersBeforeStartOfPacketMarker = finalOffset + distinctNumberOfChar;

                Console.WriteLine(
                    "{0} characters need to be processed before the first start-of-packet marker is detected",
                    charactersBeforeStartOfPacketMarker);
            }
            #endregion

            #region Part 1 - Example 5
            {
                Console.WriteLine("Part 1 - Example 5");

                var exampleInput = File.ReadAllText("example5.txt");

                int distinctNumberOfChar = 4;
                int finalOffset = 0;

                for (int i = 0; i < exampleInput.Length; i++)
                {
                    // take the 4 character long substring from ... where we are in the string
                    var substring = exampleInput
                        .ToCharArray()
                        .Skip(i)
                        .Take(distinctNumberOfChar)
                        .ToArray();

                    if (CheckForRepeatedCharacters(substring))
                    {
                        finalOffset = i;
                        break;
                    }
                }

                var charactersBeforeStartOfPacketMarker = finalOffset + distinctNumberOfChar;

                Console.WriteLine(
                    "{0} characters need to be processed before the first start-of-packet marker is detected",
                    charactersBeforeStartOfPacketMarker);
            }
            #endregion

            #region Part 1
            {
                Console.WriteLine("Part 1");

                var input = File.ReadAllText("input.txt");

                int distinctNumberOfChar = 4;
                int finalOffset = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    // take the 4 character long substring from ... where we are in the string
                    var substring = input
                        .ToCharArray()
                        .Skip(i)
                        .Take(distinctNumberOfChar)
                        .ToArray();

                    if (CheckForRepeatedCharacters(substring))
                    {
                        finalOffset = i;
                        break;
                    }
                }

                var charactersBeforeStartOfPacketMarker = finalOffset + distinctNumberOfChar;

                Console.WriteLine(
                    "{0} characters need to be processed before the first start-of-packet marker is detected",
                    charactersBeforeStartOfPacketMarker);
            }
            #endregion

            #region Part 2
            {
                Console.WriteLine("Part 2");

                var input = File.ReadAllText("input.txt");

                int distinctNumberOfChar = 14;
                int finalOffset = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    // take the 4 character long substring from ... where we are in the string
                    var substring = input
                        .ToCharArray()
                        .Skip(i)
                        .Take(distinctNumberOfChar)
                        .ToArray();

                    if (CheckForRepeatedCharacters(substring))
                    {
                        finalOffset = i;
                        break;
                    }
                }

                var charactersBeforeStartOfPacketMarker = finalOffset + distinctNumberOfChar;

                Console.WriteLine(
                    "{0} characters need to be processed before the first start-of-packet marker is detected",
                    charactersBeforeStartOfPacketMarker);
            }
            #endregion
        }

        /// <summary>
        ///     Returns true if there are no repeated characters. False otherwise.
        /// </summary>
        private static bool CheckForRepeatedCharacters(char[] substring)
        {
            var substringHashSet = new HashSet<char>();
            foreach ( char c in substring )
            {
                if (!substringHashSet.Add(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}