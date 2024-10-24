using System.Globalization;
using System.Text.RegularExpressions;

namespace ContactBookManagement
{
    public class Validator
    {

        public static bool IsValidName(string name)
        {
            return name.Length >= 5;
        }

        public static bool IsEmpty(string name)
        {
            return name.Length == 0;
        }

        public static bool IsValidMobileNumber(string mobileNumber)
        {
            // Check if the input is not null or empty
            if (string.IsNullOrWhiteSpace(mobileNumber))
            {
                return false;
            }

            // Check if the length is exactly 9
            if (mobileNumber.Length != 9)
            {
                return false;
            }

            // Check if the first character is not '0'
            if (mobileNumber[0] == '0')
            {
                return false;
            }

            // Check if the length of Phone number is 9 digits
            if (mobileNumber.Length != 9)
            {
                return false;
            }

            // Check if all characters are digits
            foreach (char c in mobileNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            // If all checks are passed, return true
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            // Regular expression pattern for validating an email address
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Use Regex to check if the email matches the pattern
            return Regex.IsMatch(email, pattern);
        }

        public static bool TryAddBirthdate(string input, out DateTime birthdate)
        {
            // Specify the expected date format
            string format = "d MMM yyyy"; // Day (1-31), Month (Jan-Dec), Year (4 digits)

            // Try to parse the input string to DateTime
            return DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out birthdate);
        }
    }
}
