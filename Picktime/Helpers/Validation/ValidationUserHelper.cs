using Picktime.DTOs.Validation;
using System.Text.RegularExpressions;

namespace Picktime.Helpers.Validation
{
    public static class ValidationUserHelper
    {
        public static bool IsFirstNameValid(string firstName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName) || firstName.Length > 50)
                throw new Exception("First Name is required and should not be more than 50 characters.");

            foreach (char c in firstName)
            {
                if (char.IsDigit(c))
                    throw new Exception("First Name should not contain numbers.");

                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    throw new Exception("First Name should only contain letters and white spaces.");
            }

            return true;
        }



        public static bool IsLastNameValid(string lastName)
        {
            if (string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName) || lastName.Length > 50)
                throw new Exception("Last Name is required and should not be more than 50 characters.");

            foreach (char c in lastName)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    throw new Exception("Name should only contain letters and white spaces. No numbers or special characters allowed.");
            }

            return true;
        }


        public static UserNameDTO GetVarifiedUserName(string userName)
        {
            return new UserNameDTO
            {
                IsVarifiedEamil = IsValidEmail(userName),
                IsVarifiedPhoneNumber = IsValidPhoneNumber(userName),
            };
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(077|078|079)\d{7}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@(gmail\.com|hotmail\.com|outlook\.com|zoho\.com)$";
            return Regex.IsMatch(email.ToLower(), pattern);
        }
        public static bool IsPasswordValid(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }
    }
}
