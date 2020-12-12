using System.Collections.Generic;

namespace Year2020.Day8
{
    class Processor
    {
        List<Instruction> Instructions { get; set; }

        public Processor(List<Instruction> instructions)
        {
            Instructions = instructions;
        }
    }
}