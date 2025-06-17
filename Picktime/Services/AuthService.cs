using Picktime.Context;
using Picktime.DTOs;
using Picktime.Heplers;
using Picktime.Interfaces;

namespace Picktime.Services
{
    public class AuthService : IAuth
    {
        private readonly PickTimeDbContext _context;

        public AuthService(PickTimeDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SendOTP(string email)
        {
            var user = _context.Users.Where(u => u.Email == email && u.IsLogedIn == false).SingleOrDefault();
            if (user == null)
            {
                return false;
            }
            Random otp = new Random();
            user.OTPCode = otp.Next(11111, 99999).ToString();
            user.OTPExipry = DateTime.Now.AddMinutes(5);

            //Send via email 

            _context.Update(user);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> SignOut(int userId)
        {
            var user = _context.Users.Where(u => u.Id == userId && u.IsLogedIn == true).SingleOrDefault();
            if (user == null)
            {
                return false;
            }

            user.LastLoginTime = DateTime.Now;
            user.IsLogedIn = false;

            _context.Update(user);
            _context.SaveChanges();

            return true;
        }

        public async Task<string> Verification(VerificationInputDTO input)
        {
            
            var user = _context.Users.Where(u => (u.Email == input.Email) && u.OTPCode == input.OTPCode
            && u.IsLogedIn == false && u.OTPExipry > DateTime.Now).SingleOrDefault();
            if (user == null)
            {
                return "User not found";
            }

            if (input.IsSignup)
            {
                user.IsVerfied = true;
            }
            else
            {
                user.LastLoginTime = DateTime.Now;
                user.IsLogedIn = true;
            }

            user.OTPExipry = null;
            user.OTPCode = null;

            _context.Update(user);
            _context.SaveChanges();

            //for client false , to be an admin must be true argument 
            var response = TokenHelper.GenerateJWTToken(user.Id.ToString(), false);
            return response;
        }
    }
}
