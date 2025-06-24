using Picktime.Entities;
using Picktime.Heplers.Enums;
using System.ComponentModel.DataAnnotations;

namespace Picktime.DTOs.Auth
{
    public class SignUpDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly? Birthdate { get; set; }
        public string Gender { get; set; }
        public ELanguage Language { get; set; }
    }
    public class SignUpCreatorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly? Birthdate { get; set; }
        public string Gender { get; set; }
        public ELanguage Language { get; set; }
        public UserType UserType { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "ProviderId must be greater than 0")]
        public int? ProviderId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "ProviderId must be greater than 0")]
        public int? CategoryId { get; set; }
    }
}
