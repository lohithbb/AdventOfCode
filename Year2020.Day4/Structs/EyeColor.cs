using System;
using System.Collections.Generic;
using System.Text;

namespace Year2020.Day4.Structs
{
    struct EyeColor
    {
        public EyeColors Color { get; set; }

        public EyeColor(string eyeColor)
        {
            Color = eyeColor switch
            {
                "amb" => EyeColors.amb,
                "blu" => EyeColors.blu,
                "brn" => EyeColors.brn,
                "gry" => EyeColors.gry,
                "grn" => EyeColors.grn,
                "hzl" => EyeColors.hzl,
                "oth" => EyeColors.oth,
                _ => throw new Exception("Invalid eye color.")
            };
        }
    }
}
