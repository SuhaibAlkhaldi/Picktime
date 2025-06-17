namespace Picktime.DTOs
{
    public class ResetPasswordInputDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string OTP { get; set; }
    }
}
