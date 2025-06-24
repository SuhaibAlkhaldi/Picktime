namespace Picktime.DTOs.Auth
{
    public class LoginResponseDTO
    {
        public bool NeedOTP { get; set; }
        public string? Token { get; set; }
    }
}
