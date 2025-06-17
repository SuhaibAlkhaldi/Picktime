namespace Picktime.DTOs
{
    public class SignInInputDTO
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool? IsLoggedIn { get; set; }
    }
}
