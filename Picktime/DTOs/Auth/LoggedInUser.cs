using Picktime.Helpers.Enums;

namespace Picktime.DTOs.Auth
{
    public class LoggedInUser
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string FullName { get; set; }
        public ELanguage SelectedLanguage { get; set; }
        public string IpAddress { get; set; }
        public UserType UserType { get; set; }
        public int? ProviderId { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? ProviderName { get; set; }
        public bool LoggedByEmail { get; set; }
        public bool LoggedByPhoneNumber { get; set; }


    }
}
