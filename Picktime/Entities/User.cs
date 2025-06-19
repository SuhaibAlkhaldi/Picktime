using Picktime.Heplers.Enums;

namespace Picktime.Entities
{
    public class User : SharedClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly? Birthdate { get; set; }
        public int Points { get; set; }
        public string Gender { get; set; }
        public ELanguage SelectedLanguage { set; get; }
        public bool IsLoggedIn { get; set; }
        public string? LastLoggedInDeviceAddress { get; set; }
        public bool? IsVerfied { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public string? OTPCode { get; set; }
        public DateTime? OTPExpiry { get; set; }
        public bool IsAdmin { get; set; } = false;
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<UserReviewService> UserReviewServices { get; set; }

        

    }
}
