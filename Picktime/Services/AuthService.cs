using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs;
using Picktime.Entities;
using Picktime.Heplers.Email;
using Picktime.Heplers.Hashing;
using Picktime.Interfaces;
using System;

namespace Picktime.Services
{
    public class AuthService : IAuth
    {
        private readonly PickTimeDbContext _context;
        public AuthService(PickTimeDbContext context)
        {
            _context = context;
        }
        public async Task<string> SignUp(SignUpInputDTO input)
        {
            Users user = new Users();

            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.Email = HashingHelper.HashValueWith384(input.Email);
            user.Password = HashingHelper.HashValueWith384(input.Password);
            user.PhoneNumber = HashingHelper.HashValueWith384(input.PhoneNumber);
            user.Age = input.Age;
            user.Gender = input.Gender;
            user.CreationDate = DateTime.Now;
            //send OTP
            await EmailHelper.SendEmail(input.Email, user.OTPCode, "Sign Up  OTP", "Complete Sign Up Operation");
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "Account Created Successfully";
        }



        public async Task<string> SignIn(SignInInputDTO input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.PhoneNumber) && string.IsNullOrEmpty(input.Email))
                    throw new Exception("Email or Phone Number must be provided.");
                string originalUserName = input.PhoneNumber ?? input.Email;

                Users user = null;


                if (user.IsLoggedIn == true)
                {
                    throw new Exception("You Are Already LoggedIn");
                }


                if (!string.IsNullOrEmpty(input.PhoneNumber))
                {
                    var hashedPhone = HashingHelper.HashValueWith384(input.PhoneNumber);
                    user = await _context.Users.Where(x => x.PhoneNumber == hashedPhone &&
                        x.IsLoggedIn == false).SingleOrDefaultAsync();
                }
                else if (!string.IsNullOrEmpty(input.Email))
                {
                    user = await _context.Users.Where(x =>
                        x.Email == input.Email &&
                        x.IsLoggedIn == false).SingleOrDefaultAsync();
                }

                if (user == null)
                {
                    throw new Exception("User Not Found");
                }
                else
                {
                    //SendOTP
                    user.IsLoggedIn = true;
                    await _context.SaveChangesAsync();
                    await EmailHelper.SendEmail(user.Email ?? originalUserName, user.OTPCode, "Sign In OTP", "Complete Sign In Operation");
                }
                //var role = user.IsAdmin ? "Admin" : "User";
                //var token = TokenHelper.GenerateJWTToken(user.Id.ToString(), role);
                //return token;
                return "Check Your Email";
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }




        public async Task<bool> ResetPassword(ResetPasswordInputDTO input)
        {
            try
            {
                //SendOTP
                if (string.IsNullOrEmpty(input.PhoneNumber) && string.IsNullOrEmpty(input.Email))
                    throw new Exception("Email or Phone Number must be provided."); 

                string originalUserName = input.PhoneNumber ?? input.Email;

                var user = _context.Users.Where(u => (u.Email == input.Email || u.PhoneNumber == input.PhoneNumber) && u.OTPCode == input.OTP
                && u.IsLoggedIn == false && u.OTPExpiry > DateTime.Now).SingleOrDefault();

                await EmailHelper.SendEmail(user.Email ?? originalUserName, user.OTPCode, "Sign In OTP", "Complete Sign In Operation");

                if (user == null)
                {
                    return false;
                }
                if (input.Password != input.ConfirmPassword)
                {
                    return false;
                }
                user.Password = input.ConfirmPassword;
                user.OTPCode = null;
                user.OTPExpiry = null;

                _context.Update(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        
    }
}
