﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Year2020.Day4.Classes;

namespace Year2020.Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2020 - Day 4");

            // input.txt should be present in the /bin directory (Properties > Copy to output directory = Copy always)
            //var input = File.ReadAllLines("input.txt");
            var inputAll = File.ReadAllText("input.txt");

            var newLineFixedInput = FixNewLinesInInput(inputAll);

            var entries = newLineFixedInput.Split(Environment.NewLine);

            // get "raw" passports - these are just strings (have not been interpreted)
            var rawPassports = ProcessPassportEntries(entries);

            var nValidPassports = rawPassports.Count(p => p.IsValid());
            var nKindaValidPassports = rawPassports.Count(p => p.IsKindaValid());

            Console.WriteLine($"Number of valid passports : {nValidPassports}");
            Console.WriteLine($"Number of valid passports (ignoring CountryID) : {nKindaValidPassports}");
        }

        static string FixNewLinesInInput(string input)
        {
            // make sure there are no double whitespaces already in the input
            var cleanInput = Regex.Replace(input, " {2,}", " ");

            return cleanInput
                .Replace(Environment.NewLine, " ")      // replace newline with a space - an empty line will produce 2 spaces
                .Replace("  ", Environment.NewLine);    // replace double space with newline
        }

        static List<RawPassport> ProcessPassportEntries(string[] passportEntries)
        {
            List <RawPassport> output = new List<RawPassport>();

            foreach (var (passportEntry, i) in passportEntries.Select((x, i) => (x, i)))
            {
                try
                {
                    var rawPassport = DeserialisePassportEntry(passportEntry);
                    Console.WriteLine(rawPassport.ToString());
                    output.Add(rawPassport);
                }
                catch (Exception)
                {
                    Console.Error.WriteLine($"Error parsing entry at line {i} : '{passportEntry}'");
                    continue;
                }
            }

            return output;
        }

        static RawPassport DeserialisePassportEntry(string passportEntry)
        {
            RawPassport rawPassport = new RawPassport();
            
            // split the entries seperated by whitespace
            var fieldKeyValuePairs = passportEntry.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var fieldKeyValuePair in fieldKeyValuePairs)
            {
                try
                {
                    var key = fieldKeyValuePair.Split(':')[0];
                    var value = fieldKeyValuePair.Split(':')[1];

                    switch (key)
                    {
                        case "byr":
                            rawPassport.BirthYear = value;
                            break;
                        case "iyr":
                            rawPassport.IssueYear = value;
                            break;
                        case "eyr":
                            rawPassport.ExpirationYear = value;
                            break;
                        case "hgt":
                            rawPassport.Height = value;
                            break;
                        case "hcl":
                            rawPassport.HairColor = value;
                            break;
                        case "ecl":
                            rawPassport.EyeColor = value;
                            break;
                        case "pid":
                            rawPassport.PassportID = value;
                            break;
                        case "cid":
                            rawPassport.CountryID = value;
                            break;
                        default:
                            Console.Error.WriteLine($"Unknwon field key parsed - {fieldKeyValuePair}");
                            break;
                    }
                }
                catch (Exception) { }
            }

            return rawPassport;
        }
    }
}
