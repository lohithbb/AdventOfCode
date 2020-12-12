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

            for (int indexCurrentInstruction = 0; indexCurrentInstruction < Instructions.Count; indexCurrentInstruction++)
            {
                // load current instruction
                var currentInstruction = Instructions[indexCurrentInstruction];

                // cycle detection is done by maintaining an instrcutions that have been executed
                // when the same instruction is run, the addition to the HashSet fails and it will bomb out
                try
                {
                    cycleDectector.Add(indexCurrentInstruction);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Cycle detected at instruction {indexCurrentInstruction} : {currentInstruction.Operation} {currentInstruction.Argument}");
                    throw;
                }

                switch (currentInstruction.Operation)
                {
                    case "acc":
                        accumulator = accumulator + currentInstruction.Argument;
                        break;

                    case "jmp":
                        indexCurrentInstruction = indexCurrentInstruction + currentInstruction.Argument;
                        break;

                    case "nop":
                        continue;

                    default:
                        break;
                }
            }
        }
    }
}