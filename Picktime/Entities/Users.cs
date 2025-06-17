namespace Picktime.Entities
{
    public class Users : SharedClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public float Age {  get; set; }
        public int Points { get; set; }
        public string Gender { get; set; }

        public DateTime LastLoginTime { get; set; }
        public string? OTPCode { get; set; }
        public DateTime? OTPExipry { get; set; }
        public bool IsAdmin { get; set; } = false;
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Reviews> Reviews { get; set; }

        

    }
}
