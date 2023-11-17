using System.Text.RegularExpressions;

namespace AssessmentAddressAPI.Validation
{
    public static class PostCodeValidator
    {
        private static readonly Regex PostCodeRegex = new Regex("^[A-Za-z][1-9][1-9][A-Za-z]{2}$");

        public static bool IsValidPostCode(string postCode)
        {
            if (string.IsNullOrEmpty(postCode)) return false;

            return PostCodeRegex.IsMatch(postCode);
        }
    }
}
