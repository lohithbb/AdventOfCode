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

            var instructions = ProcessInput();

            {
                var processor = new Processor(instructions);

                try
                {
                    processor.Process();
                }
                catch (Exception) { }
            }

            #endregion Part 1

            #region Part 2

            Console.WriteLine("Part 2");

            // need to successively mutate the input until we find a solution
            for (int i = 0; i < instructions.Count; i++)
            {
                Instruction instruction = instructions[i];
                FlipOperation(instruction);

                var processor = new Processor(instructions);

                try
                {                    
                    processor.Process();
                }
                catch (Exception)
                {
                    // if the flip didn't work, revert it
                    FlipOperation(instruction);
                    continue;
                }

                // if it successfully gets out of the try catch block - a solution has been found
                Console.WriteLine($"Swapping operation at index : {i} results in successful execution of program.");
                break;
            }

            #endregion Part 2
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

        private static void FlipOperation(Instruction instruction)
        {
            if (instruction.Operation == "jmp")
                instruction.Operation = "nop";
            else if (instruction.Operation == "nop")
                instruction.Operation = "jmp";
        }
    }
}