using System.Security.Cryptography;
using System.Text;

namespace Picktime.Helpers.Hashing
{
    public static class HashingHelper
    {
        public static string HashValueWith384(string inputValue)
        {
            var inputBytes = Encoding.UTF8.GetBytes(inputValue);

            var hasher = SHA384.Create();

            var hashedByte = hasher.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedByte).Replace("-", "").ToLower();
        }
    }
}
