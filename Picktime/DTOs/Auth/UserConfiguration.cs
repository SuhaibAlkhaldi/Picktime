namespace Picktime.DTOs.Auth
{
    public class UserConfiguration
    {
        public bool BlockedFeatures { get; set; }
        public bool SendOTPFeatures { get; set; }
        public int MaxFailedPasswordAttempts { get; set; }
        public string? MaxFaEmailAddressiledPasswordAttempts { get; set; }
        public EmailConfig EmailConfig { get; set; }
    }

    public class EmailConfig
    {
        public string? EmailAPIKey { get; set; }
        public string? EmailAddress { get; set; }
    }
} 
