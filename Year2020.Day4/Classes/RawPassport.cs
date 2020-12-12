using System.Text.Json;
using System.Text.RegularExpressions;

namespace Year2020.Day4.Classes
{
    class RawPassport
    {
        public string BirthYear { get; set; } = null;

        public string IssueYear { get; set; } = null;

        public string ExpirationYear { get; set; } = null;

        public string Height { get; set; } = null;

        public string HairColor { get; set; } = null;

        public string EyeColor { get; set; } = null;

        public string PassportID { get; set; } = null;

        public string CountryID { get; set; } = null;

        /// <summary>
        /// Simple validity check
        /// </summary>
        /// <returns>True, if ALL fields are not null</returns>
        public bool IsValid()
        {
            return (BirthYear != null)
                && (IssueYear != null)
                && (ExpirationYear != null)
                && (Height != null)
                && (HairColor != null)
                && (EyeColor != null)
                && (PassportID != null)
                && (CountryID != null);
        }

        /// <summary>
        /// Validity check but ignore CountryID
        /// </summary>
        /// <returns>True, if all fields are not null barring CountryID</returns>
        public bool IsKindaValid()
        {
            return (BirthYear != null)
                && (IssueYear != null)
                && (ExpirationYear != null)
                && (Height != null)
                && (HairColor != null)
                && (EyeColor != null)
                && (PassportID != null);
        }

        //public bool IsStrictlyValid()
        //{
        //    if (!IsKindaValid())
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        var birthyear = int.Parse(BirthYear);
        //        if (!(birthyear >= 1920 && birthyear <= 2002))
        //        {
        //            return false;
        //        }

        //        var issueYear = int.Parse(IssueYear);
        //        if (!(issueYear >= 2010 && issueYear <= 2020))
        //        {
        //            return false;
        //        }

        //        var expirationYear = int.Parse(ExpirationYear);
        //        if (!(expirationYear >= 2020 && expirationYear <= 2030))
        //        {
        //            return false;
        //        }

        //        {
        //            string heightValidationRegex = "([0-9]+)([a-z]+)";
        //            var match = Regex.Match(p.Height, heightValidationRegex);
        //            var heightValue = int.Parse(match.Groups[1].Value);
        //            var heightUnits = match.Groups[2].Value;
        //        }

        //        return true;
        //    }
        //}

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }
    }
}
