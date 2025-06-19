namespace Picktime.DTOs
{
    public class SignInInputDTO : BaseDTO
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
