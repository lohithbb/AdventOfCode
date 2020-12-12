using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Year2020.Day8
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2020 - Day 8");

            #region Part 1

            Console.WriteLine("Part 1");

            var instrctions = ProcessInput();



            #endregion Part 1
        }

        private static List<Instruction> ProcessInput()
        {
            var input = File.ReadAllLines("input.txt");
            //var input = File.ReadAllLines("example.txt");

            var output = new List<Instruction>();

            foreach (var line in input)
            {
                string regex = @"^(acc|jmp|nop) ([+-][0-9]+)$";

                Match m = Regex.Match(line, regex);
                var operation = m.Groups[1].Value;
                var argument = int.Parse(m.Groups[2].Value);

                output.Add(new Instruction(operation, argument));
            }

            return output;
        }
    }
}