using System;
using System.Collections.Generic;

namespace Year2020.Day8
{
    internal class Processor
    {
        private List<Instruction> Instructions { get; set; }

        public Processor(List<Instruction> instructions)
        {
            Instructions = instructions;
        }

        internal void Process()
        {
            long accumulator = 0;
            var cycleDectector = new HashSet<int>();

            // start at the first instruction
            int indexCurrentInstruction = 0;
            // end at the last instruction
            while (indexCurrentInstruction < Instructions.Count)
            {
                // load current instruction
                var currentInstruction = Instructions[indexCurrentInstruction];

                // cycle detection is done by maintaining a list of instrcutions that have been executed
                // when the same instruction is run, the addition to the HashSet fails and it will bomb out
                if (cycleDectector.Add(indexCurrentInstruction))
                {
                    switch (currentInstruction.Operation)
                    {
                        case "acc":
                            accumulator = accumulator + currentInstruction.Argument;
                            indexCurrentInstruction++;
                            continue;

                        case "jmp":
                            indexCurrentInstruction = indexCurrentInstruction + currentInstruction.Argument;
                            continue;

                        case "nop":
                            indexCurrentInstruction++;
                            continue;

                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Cycle detected at instruction {indexCurrentInstruction} : {currentInstruction.Operation} {currentInstruction.Argument}");
                    Console.WriteLine($"Accumulator : {accumulator}");
                    throw new Exception("Cycle detected. Stopping...");
                }
            }
        }
    }
}