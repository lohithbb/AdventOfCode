using System;

namespace Year2020.Day4
{
    struct Height
    {
        public int Value { get; set; }

        public HeightUnits Units { get; set; }

        public Height(int value, string units)
        {
            switch (units)
            {
                case "cm":
                    Units = HeightUnits.centimetres;
                    if (value >= 150 && value <= 193)
                    {
                        Value = value;
                    }
                    else
                    {
                        throw new Exception("Invalid height in centimetres.");
                    }
                    break;
                case "in":
                    Units = HeightUnits.inches;
                    if (value >= 59 && value <= 76)
                    {
                        Value = value;
                    }
                    else
                    {
                        throw new Exception("Invalid height in inches.");
                    }
                    break;
                default:
                    throw new Exception("Invalid height.");
            }
        }
    }
}