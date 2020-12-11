using System.Text.Json;

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

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }
    }
}
