namespace Year2020.Day8
{
    public class Instruction
    {
        public string Operation { get; set; }
        public int Argument { get; set; }

        public Instruction(string operation, int argument)
        {
            Operation = operation;
            Argument = argument;
        }
    }
}