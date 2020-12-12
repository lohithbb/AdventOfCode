using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using Year2020.Day4.Classes;

namespace Year2020.Day4
{
    class Passport
    {
        public int BirthYear { get; set; }

        public int IssueYear { get; set; }

        public int ExpirationYear { get; set; }

        public int Height { get; set; }

        public string HeightUnits { get; set; }

        public string HairColor { get; set; } 

        public string EyeColor { get; set; }

        public string PassportID { get; set; }

        public string CountryID { get; set; }

        /// <summary>
        /// Constructor that takes a RawPassport object.
        /// Desinged to throw errors if the data doesn't meeting the validation criteria.
        /// These will be caught and handled.
        /// </summary>
        /// <param name="p"></param>
        public Passport(RawPassport p)
        {
            if (!p.IsKindaValid())
            {
                throw new Exception("Passport is not valid.");
            }
            
            var birthyear = int.Parse(p.BirthYear);
            if (birthyear >= 1920 && birthyear <= 2002)
            {
                BirthYear = birthyear;
            }
            else throw new Exception();

            var issueYear = int.Parse(p.IssueYear);
            if (issueYear >= 2010 && issueYear <= 2020)
            {
                IssueYear = issueYear;
            }
            else throw new Exception();

            var expirationYear = int.Parse(p.ExpirationYear);
            if (expirationYear >= 2020 && expirationYear <= 2030)
            {
                ExpirationYear = expirationYear;
            }
            else throw new Exception();

            {
                string heightValidationRegex = "^([0-9]+)(cm|in)$";
                var match = Regex.Match(p.Height, heightValidationRegex);
                var heightValue = int.Parse(match.Groups[1].Value);
                var heightUnits = match.Groups[2].Value;
                switch (heightUnits)
                {
                    case "cm":
                        HeightUnits = heightUnits;
                        if (heightValue >= 150 && heightValue <= 193)
                        {
                            Height = heightValue;
                        }
                        else throw new Exception();
                        break;
                    case "in":
                        HeightUnits = heightUnits;
                        if (heightValue >= 59 && heightValue <= 76)
                        {
                            Height = heightValue;
                        }
                        else throw new Exception();
                        break;
                    default:
                        throw new Exception();
                        break;
                }
            }

            {
                string hairColorValidationRegex = "^[#][0-9a-f]{6}$";
                if (Regex.IsMatch(p.HairColor, hairColorValidationRegex))
                {
                    HairColor = p.HairColor;
                }
                else throw new Exception();
            }

            {
                string eyeColorValidationRegex = "^(amb|blu|brn|gry|grn|hzl|oth)$";
                if (Regex.IsMatch(p.EyeColor, eyeColorValidationRegex))
                {
                    EyeColor = p.EyeColor;
                }
                else throw new Exception();
            }

            {
                string passportValidationRegex = "^[0-9]{9}$";
                if (Regex.IsMatch(p.PassportID, passportValidationRegex))
                {
                    PassportID = p.PassportID;
                }
                else throw new Exception();
            }

            // we dont validate the CountryID
            CountryID = p.CountryID;            
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }
    }
}
