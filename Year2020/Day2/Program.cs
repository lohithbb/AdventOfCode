using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Year2020.Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2020 - Day 1");

            // input.txt should be present in the /bin directory (Properties > Copu to output directory = Copy always)
            var input = File.ReadAllLines("input.txt");


            #region Part 1
            {
                Console.WriteLine("Part 1");
                
                int numberOfValidPasswords = 0;

                foreach (var line in input)
                {
                    /*
                     * ([\d]+[-][\d]+) - match a number, a dash, then another number - group[1]
                     * then a space " "
                     * ([a-z]) - then any SINGLE character - group[2]
                     * then a colon ":"
                     * then anything - it needs to be anything as we dont know what the erroneous password may contain - group[3]
                     */
                    string parseRegex = @"([\d]+)[-]([\d]+) ([a-z]): (.*)";

                    Match match = Regex.Match(line, parseRegex);
                    var character = match.Groups[3].Value;
                    var characterConstraintsMin = int.Parse(match.Groups[1].Value);
                    var characterConstraintsMax = int.Parse(match.Groups[2].Value);
                    var password = match.Groups[4].Value;

                    // check password has required occurrences of a character
                    int occurrences = Regex.Matches(password, character).Count;

                    if (occurrences >= characterConstraintsMin && occurrences <= characterConstraintsMax)
                    {
                        numberOfValidPasswords++;
                    }
                }

                Console.WriteLine($"Number of valid passwords : {numberOfValidPasswords}");
            }
            #endregion


            #region Part 2
            {
                Console.WriteLine("Part 2");
                
                int numberOfValidPasswords = 0;

                foreach (var line in input)
                {
                    /*
                     * ([\d]+[-][\d]+) - match a number, a dash, then another number - group[1]
                     * then a space " "
                     * ([a-z]) - then any SINGLE character - group[2]
                     * then a colon ":"
                     * then anything - it needs to be anything as we dont know what the erroneous password may contain - group[3]
                     */
                    string parseRegex = @"([\d]+)[-]([\d]+) ([a-z]): (.*)";

                    Match match = Regex.Match(line, parseRegex);
                    
                    // working with characters  instead of strings
                    var character = match.Groups[3].Value.ToCharArray()[0];

                    // need -1 because they're not programmers
                    var characterConstraintA = int.Parse(match.Groups[1].Value) - 1;
                    var characterConstraintB = int.Parse(match.Groups[2].Value) - 1;

                    // character arrays have O(1) lookup time
                    var password = match.Groups[4].Value.ToCharArray();

                    try
                    {
                        // the XOR operator is key here
                        if (password[characterConstraintA] == character ^ password[characterConstraintB] == character)
                        {
                            numberOfValidPasswords++;
                        }
                    }
                    // in case either of the numbers is greater than password
                    catch (IndexOutOfRangeException) { }
                }

                Console.WriteLine($"Number of valid passwords : {numberOfValidPasswords}");
            }
            #endregion
        }
    }
}
