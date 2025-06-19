using Picktime.Heplers.Enums;

namespace Picktime.DTOs
{
    public class SignUpInputDTO
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
}
