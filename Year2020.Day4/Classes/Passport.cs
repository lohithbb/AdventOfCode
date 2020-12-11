using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using Year2020.Day4.Classes;
using Year2020.Day4.Structs;

namespace Year2020.Day4
{
    class Passport
    {
        public int BirthYear { get; set; }

        public int IssueYear { get; set; }

        public int ExpirationYear { get; set; }

        public Height Height { get; set; }

        public EyeColor EyeColor { get; set; }

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

            var issueYear = int.Parse(p.IssueYear);
            if (issueYear >= 2010 && issueYear <= 2020)
            {
                IssueYear = issueYear;
            }

            var expirationYear = int.Parse(p.ExpirationYear);
            if (expirationYear >= 2020 && expirationYear <= 2030)
            {
                ExpirationYear = expirationYear;
            }

            {
                string heightValidationRegex = "([0-9]+)([a-z]+)";
                var match = Regex.Match(p.Height, heightValidationRegex);
                var heightValue = int.Parse(match.Groups[1].Value);
                var heightUnits = match.Groups[2].Value;
                Height = new Height(heightValue, heightUnits);
            }
            

            EyeColor = new EyeColor(p.EyeColor);

            {
                string passportValidationRegex = "^[0-9]{9}$";
                if (Regex.IsMatch(p.PassportID, passportValidationRegex))
                {
                    PassportID = p.PassportID;
                }
            }

            // we dont validate the CountryID
            if (p.CountryID == null)
            {
                throw new Exception("CountryID is null;");
            }
            else
            {
                CountryID = p.CountryID;
            }
            
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }
    }
}
