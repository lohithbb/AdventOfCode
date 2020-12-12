namespace Year2020.Day8
{
    internal class Instruction
    {
        private string Operation { get; set; }
        private int Argument { get; set; }

        public Instruction(string operation, int argument)
        {
            Operation = operation;
            Argument = argument;
        }
    }
}