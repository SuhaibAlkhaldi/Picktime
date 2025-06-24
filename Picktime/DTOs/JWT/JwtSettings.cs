namespace Picktime.DTOs.JWT
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int Portal_AccessTokenExpirationInMinutes { get; set; }
    }
}
