
using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs;
using Picktime.Entities;
using Picktime.Heplers.Email;
using Picktime.Heplers.Hashing;
using Picktime.Heplers.Token;
using Picktime.Heplers.Validation;
using Picktime.Interfaces;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Picktime.Services
{
    public class AuthService : IAuth
    {
        private readonly PickTimeDbContext _context;
        private readonly BaseDTO _baseDTO;

        public AuthService(PickTimeDbContext context , BaseDTO baseDTO)
        {
            _context = context;
            _baseDTO = baseDTO; 
        }

        public async Task<string> SignUp(SignUpInputDTO input)
        {
            try
            {
                if (ValidationUserHelper.IsFirstNameValid(input.FirstName) && ValidationUserHelper.IsLastNameValid(input.LastName) && ValidationUserHelper.IsPhoneNumberValid(input.PhoneNumber)
                    && ValidationUserHelper.IsPasswordValid(input.Password) &&ValidationUserHelper.IsEmailValid(input.Email))
                {
                    User user = new User();

                    user.FirstName = input.FirstName;
                    user.LastName = input.LastName;
                    user.Email = HashingHelper.HashValueWith384(input.Email);
                    user.Password = HashingHelper.HashValueWith384(input.Password);
                    user.PhoneNumber = HashingHelper.HashValueWith384(input.PhoneNumber);
                    user.Birthdate = input.Birthdate;
                    user.Gender = input.Gender;
                    user.CreationDate = DateTime.Now;
                    user.IsLoggedIn = false;
                    user.SelectedLanguage = input.Language;
                    var otp = SendOTP(user.Email);
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    await EmailHelper.SendEmail(input.Email, otp.ToString(), "Sign Up  OTP", "Complete Sign Up Operation");
                    
                }
                return "Account Created Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }



        public async Task<LoginResponseDTO> SignIn(SignInInputDTO input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.PhoneNumber) && string.IsNullOrEmpty(input.Email))
                    throw new Exception("Email or Phone Number must be provided.");
                string originalUserName = input.PhoneNumber ?? input.Email;


                var user = new User();

                if (!string.IsNullOrEmpty(input.PhoneNumber))
                {
                    var hashedPhone = HashingHelper.HashValueWith384(input.PhoneNumber);
                    user = await _context.Users.Where(x => x.PhoneNumber == hashedPhone &&
                        x.IsLoggedIn == false).SingleOrDefaultAsync();
                }
                else if (!string.IsNullOrEmpty(input.Email))
                {
                    var hashedEmail = HashingHelper.HashValueWith384(input.Email);
                    user = await _context.Users.Where(x =>
                        x.Email == hashedEmail &&
                        x.IsLoggedIn == false).SingleOrDefaultAsync();
                }
                
                if (user?.IsLoggedIn == true || user?.LastLoggedInDeviceAddress == _baseDTO.MacAddress)
                {
                    await SendOTP(input.Email);
                    return new LoginResponseDTO
                    {
                        NeedOTP = true,
                        Token = null
                    };
                }
                if (user == null)
                {
                    throw new Exception("User Not Found");
                }
                else
                {
                    await SendOTP(input.Email);
                    user.IsLoggedIn = true;
                    await _context.SaveChangesAsync();
                    await EmailHelper.SendEmail(user.Email ?? originalUserName, user.OTPCode, "Sign In OTP", "Complete Sign In Operation");
                }
                var role = user.IsAdmin ? "Admin" : "Client";
                var token = TokenHelper.GenerateJWTToken(user,role); 


                return new LoginResponseDTO
                {
                    Token = token,  
                    NeedOTP = false 
                };
                


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
                
                if (string.IsNullOrEmpty(input.PhoneNumber) && string.IsNullOrEmpty(input.Email))
                    throw new Exception("Email or Phone Number must be provided."); 

                string originalUserName = input.PhoneNumber ?? input.Email;

                var hashedEmail = HashingHelper.HashValueWith384(input.Email);
                //var hashedPhone = HashingHelper.HashValueWith384(input.PhoneNumber);

                var user = _context.Users.Where(u => (u.Email == hashedEmail || u.PhoneNumber == input.PhoneNumber)).SingleOrDefault();
                var otp = SendOTP(input.Email);
                await EmailHelper.SendEmail(input.Email, otp.ToString(), "Reset Password", "Reset Password Done Successfully");

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

        

        

        public async Task<bool> SendOTP(string email)
        {
            var hashedEmail = HashingHelper.HashValueWith384(email);
            var user = _context.Users.Where(u => u.Email == hashedEmail).SingleOrDefault();
            if (user == null)
            {
                return false;
            }
            Random otp = new Random();
            user.OTPCode =HashingHelper.HashValueWith384(otp.Next(11111, 99999).ToString());
            user.OTPExpiry = DateTime.Now.AddMinutes(5);
             
            //Send via email
            EmailHelper.SendEmail(email, user.OTPCode, "Sending OTP", "OTP was Sent to your email");

            _context.Update(user);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> SignOut(int userId)
        {
            var user = _context.Users.Where(u => u.Id == userId && u.IsLoggedIn == true).SingleOrDefault();
            if (user == null)
            {
                return false;
            }

            user.LastLoginTime = DateTime.Now;
            user.IsLoggedIn = false;

            _context.Update(user);
            _context.SaveChanges();

            return true;
        }

        public async Task<string> Verification(VerificationInputDTO input)
        {
            var hashedOTP = HashingHelper.HashValueWith384(input.OTPCode);
            var hashedEmail = HashingHelper.HashValueWith384(input.Email);
            var user = _context.Users.Where(u => (u.Email == hashedEmail) && u.OTPCode == hashedOTP
            && u.IsLoggedIn == false && u.OTPExpiry > DateTime.Now).SingleOrDefault();
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
                user.IsLoggedIn = true;
            }

            user.OTPExpiry = null;
            user.OTPCode = null;

            _context.Update(user);
            _context.SaveChanges();
            EmailHelper.SendEmail(input.Email, user.OTPCode, "Verifying OTP", "OTP Verified Successfully");
            var role = user.IsAdmin ? "Admin" : "Client";
            //for client false , to be an admin must be true argument 
            var response = TokenHelper.GenerateJWTToken(user, role);
            return response;
        }

    }
}
