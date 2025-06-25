using Picktime.Helpers.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public DateOnly? Birthdate { get; set; }
        public int Points { get; set; }
        public string Gender { get; set; }
        public ELanguage SelectedLanguage { set; get; }
        public bool IsLoggedIn { get; set; }
        public string LastLoggedInDeviceAddress { get; set; } = "NotLocated"; 
        public bool? IsVerfied { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public string? OTPCode { get; set; }
        public DateTime? OTPExpiry { get; set; }
        public bool IsBlocked { get; set; } = false;
        public int NumberOfTry { get; set; } = 0;

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("ProviderId")]
        public int? ProviderId { get; set; }
        public Provider? Provider { get; set; }

        
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public ICollection<UserReview> UserReviewServices { get; set; } = new HashSet<UserReview>();
    }


    

}
