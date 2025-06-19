namespace Picktime.DTOs
{
    public class LoginResponseDTO
    {
        public bool NeedOTP { get; set; }
        public string? Token { get; set; }
    }
}
