
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Picktime.Context;
using Picktime.DTOs.Auth;
using Picktime.Entities;
using Picktime.Helpers.Email;
using Picktime.Helpers.Enums;
using Picktime.Helpers.Hashing;
using Picktime.Helpers.Token;
using Picktime.Helpers.Validation;
using Picktime.Interfaces;
using SendGrid.Helpers.Mail;
using System.Security.Claims;
using Picktime.DTOs.JWT;
using Picktime.DTOs.Category;
using Picktime.DTOs.Errors;
using Picktime.Helpers.Error;

namespace Picktime.Services
{
    public class AuthService : IAuth
    {
        private readonly PickTimeDbContext _context;
        private readonly BaseDTO _baseDTO;
        private readonly UserConfiguration _userConfiguration;
        private readonly ITokenService _tokenService;

        public AuthService(PickTimeDbContext context, BaseDTO baseDTO, UserConfiguration userConfiguration, ITokenService tokenService)
        {
            _context = context;
            _baseDTO = baseDTO;
            _userConfiguration = userConfiguration;
            _tokenService = tokenService;
        }

        public async Task<AppResponse> SignUp(SignUpDTO input)
        {
            try
            {

                if (ValidationUserHelper.IsFirstNameValid(input.FirstName) && ValidationUserHelper.IsLastNameValid(input.LastName) && ValidationUserHelper.IsValidPhoneNumber(input.PhoneNumber)
                    && ValidationUserHelper.IsPasswordValid(input.Password) && ValidationUserHelper.IsValidEmail(input.Email))
                {
                    User user = new User();

                    user.FirstName = input.FirstName;
                    user.LastName = input.LastName;
                    user.Email = input.Email.ToLower();
                    user.Password = HashingHelper.HashValueWith384(input.Password);
                    user.PhoneNumber = input.PhoneNumber;
                    user.Birthdate = input.Birthdate;
                    user.Gender = input.Gender;
                    user.CreationDate = DateTime.Now;
                    user.IsLoggedIn = false;
                    user.SelectedLanguage = input.Language;
                    user.UserType = UserType.Client;

                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    var otp = await SendOTP(user.Email);
                    await EmailHelper.SendEmail(input.Email, otp.ToString(), "Sign Up  OTP", "Complete Sign Up Operation", _userConfiguration.EmailConfig);

                }
                return AppResponse.Success();
            }
            catch (Exception ex)
            {
                return AppResponse<AppResponse>.Error(new Error { Message = ErrorKeys.ErrorInSignUp, Category = "Auth" });
            }

        }
        public async Task<AppResponse> SignUpCreator(SignUpCreatorDTO input)
        {
            try
            {

                if (ValidationUserHelper.IsFirstNameValid(input.FirstName) && ValidationUserHelper.IsLastNameValid(input.LastName) && ValidationUserHelper.IsValidPhoneNumber(input.PhoneNumber)
                    && ValidationUserHelper.IsPasswordValid(input.Password) && ValidationUserHelper.IsValidEmail(input.Email))
                {
                    var selectedCategory = new Category();
                    var selectedProvider = new Provider();


                    if (input.CategoryId.HasValue)
                    {
                        selectedCategory = await _context.Categories.Where(x => x.Id == input.CategoryId).FirstOrDefaultAsync();
                        if (selectedCategory is null)
                        {
                            return AppResponse.Error(new Error { Message = "Category Not Found." });
                        }
                    }

                    if (input.ProviderId.HasValue)
                    {
                        selectedProvider = _context.Providers.Where(x => x.Id == input.ProviderId).Include(x => x.Category).FirstOrDefault();
                        if (selectedProvider is null)
                        {
                            return AppResponse.Error(new Error { Message = "Category Not Found." });
                        }
                    }

                    User user = new User
                    {
                        FirstName = input.FirstName,
                        LastName = input.LastName,
                        Email = input.Email,
                        Password = HashingHelper.HashValueWith384(input.Password),
                        PhoneNumber = input.PhoneNumber,
                        Birthdate = input.Birthdate,
                        Gender = input.Gender,
                        CreationDate = DateTime.Now,
                        IsLoggedIn = false,
                        SelectedLanguage = input.Language,
                        UserType = input.UserType,
                        CategoryId = input.CategoryId.HasValue ? selectedCategory.Id : input.ProviderId.HasValue ? selectedProvider.CategoryId : null,
                        ProviderId = input.ProviderId.HasValue ? selectedProvider.Id : null,
                    };

                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                }
                return AppResponse.Success();
            }
            catch (Exception ex)
            {
                return AppResponse<AppResponse>.Error(new Error { Message = ErrorKeys.ErrorInSignUp, Category = "Auth" });
            }
        }
        public async Task<AppResponse<LoginResponseDTO>> SignIn(SignInInputDTO input)
        {
            try
            {
                
                if (string.IsNullOrEmpty(input.UserName))
                    return AppResponse<LoginResponseDTO>.Error(new Error { Message = "Email or Phone Number must be provided." });
                

                var CheckUserName = ValidationUserHelper.GetVarifiedUserName(input.UserName);

                var user = new User();


                var hasPhoneNumber = CheckUserName.IsVarifiedPhoneNumber;
                var hasEmail = CheckUserName.IsVarifiedEamil;


                if (!hasPhoneNumber && !hasEmail)
                {
                    return AppResponse<LoginResponseDTO>.Error(new Error { Message = "Please Enter Valid Phone number Or Email." });
                    
                }

                user = await _context.Users.Where(x =>
                hasPhoneNumber ? x.PhoneNumber == input.UserName :
                hasEmail ? x.Email == input.UserName
                : false)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return AppResponse<LoginResponseDTO>.Error(new Error { Message = "User Not Found." });

                }



                if (user.IsBlocked && _userConfiguration.BlockedFeatures)
                {
                    await SendOTP(user.Email);
                    return AppResponse<LoginResponseDTO>.Error(new Error { Message = "The User is Blocked and OTP is Send By Email." });
                }

                var hashedPass = HashingHelper.HashValueWith384(input.Password);

                if (user.Password != hashedPass)
                {
                    if (_userConfiguration.BlockedFeatures)
                    {
                        user.NumberOfTry++;
                        if (user.NumberOfTry == 3)
                        {
                            user.IsBlocked = true;
                        }
                        await EmailHelper.SendEmail(user.Email ?? user.Email, user.OTPCode, "Sign In OTP", "Complete Sign In Operation", _userConfiguration.EmailConfig);
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                    return AppResponse<LoginResponseDTO>.Error(new Error { Message = "Password is Wrong." });
                }

                if (user?.LastLoggedInDeviceAddress != _baseDTO.MacAddress && user.UserType == UserType.Client)
                {
                    await SendOTP(user.Email);
                    return new AppResponse<LoginResponseDTO>
                    {
                        Data = new LoginResponseDTO
                        {
                            NeedOTP = true,
                            Token = null
                        }
                    };
                }
                if (user == null)
                {
                    return AppResponse<LoginResponseDTO>.Error(new Error { Message = "User Not Found." });
                }
                else
                {
                    user.IsLoggedIn = true;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    await EmailHelper.SendEmail(user.Email ?? user.Email, user.OTPCode, "Sign In OTP", "Complete Sign In Operation", _userConfiguration.EmailConfig);
                }
                var token = _tokenService.GenerateAccessToken(GetClaims(user, hasPhoneNumber));


                return new AppResponse<LoginResponseDTO>
                {
                    Data = new LoginResponseDTO
                    {
                        NeedOTP = false,
                        Token = token
                    }
                };
            }
            catch (Exception ex)
            {
                return AppResponse<LoginResponseDTO>.Error(new Error { Message = ErrorKeys.ErrorInSignIn, Category = "Auth" });
            }

        }
        public async Task<AppResponse<bool>> ResetPassword(ResetPasswordInputDTO input)
        {
            try
            {
                var hashedPassword = HashingHelper.HashValueWith384(input.Password);

                if (string.IsNullOrEmpty(input.PhoneNumber) && string.IsNullOrEmpty(input.Email))
                    return AppResponse<bool>.Error(new Error { Message = "Email or Phone Number must be provided." });
                string originalUserName = input.PhoneNumber ?? input.Email;

                //var hashedEmail = HashingHelper.HashValueWith384(input.Email);
                //var hashedPhone = HashingHelper.HashValueWith384(input.PhoneNumber);

                var user = _context.Users.Where(u => (u.Email == input.Email || u.PhoneNumber == input.PhoneNumber)).SingleOrDefault();
                var otp = SendOTP(input.Email);
                await EmailHelper.SendEmail(input.Email, otp.ToString(), "Reset Password", "Reset Password Done Successfully", _userConfiguration.EmailConfig);

                if (user == null)
                {
                    return AppResponse<bool>.Error(new Error { Message = "false" });
                }
                if (input.Password != input.ConfirmPassword)
                {
                    return AppResponse<bool>.Error(new Error { Message = "false" });
                }

                user.Password = HashingHelper.HashValueWith384(input.ConfirmPassword);
                user.OTPCode = null;
                user.OTPExpiry = null;
                var oldPassword = _context.Users.Where(x => x.Password == hashedPassword).FirstOrDefault();
                if (oldPassword.Password == input.Password)
                {
                    return AppResponse<bool>.Error(new Error { Message = "false" });
                }

                _context.Update(user);
                await _context.SaveChangesAsync();

                return AppResponse<bool>.Error(new Error { Message = "true" }); 
            }
            catch (Exception ex)
            {
                return AppResponse<bool>.Error(new Error { Message = ErrorKeys.ErrorInResetPassword, Category = "Auth" });

            }
        }
        public async Task<AppResponse<bool>> SendOTP(string email)
        {

            var user = _context.Users.Where(u => (u.Email == email)).SingleOrDefault();
            if (user == null)
            {
                return AppResponse<bool>.Error(new Error { Message = "false" });
            }
            Random otp = new Random();
            user.OTPCode = otp.Next(11111, 99999).ToString();
            user.OTPExpiry = DateTime.Now.AddMinutes(5);

            //Send via email
            await EmailHelper.SendEmail(email, user.OTPCode, "Sending OTP", "OTP was Sent to your email", _userConfiguration.EmailConfig);

            _context.Update(user);
            _context.SaveChanges();

            return AppResponse<bool>.Error(new Error { Message = "true" });
        }
        public async Task<AppResponse<bool>> SignOut(int userId)
        {
            var user = _context.Users.Where(u => u.Id == userId && u.IsLoggedIn == true).SingleOrDefault();
            if (user == null)
            {
                return AppResponse<bool>.Error(new Error { Message = "false" });
            }

            user.LastLoginTime = DateTime.Now;
            user.IsLoggedIn = false;

            _context.Update(user);
            _context.SaveChanges();

            return AppResponse<bool>.Error(new Error { Message = "true" });
        }
        public async Task<string> Verification(VerificationInputDTO input)
        {
            var user = _context.Users.Where(u => u.Email == input.Email && u.OTPCode == input.OTPCode
            && u.OTPExpiry > DateTime.Now).SingleOrDefault();
            if (user == null)
            {
                return "User Not Found." ;
            }

            if (_userConfiguration.BlockedFeatures)
            {

                if (user.IsBlocked)
                {
                    user.NumberOfTry = 0;
                    user.IsBlocked = false;
                }

                _context.Update(user);
                await _context.SaveChangesAsync();
            }

            user.LastLoginTime = DateTime.Now;
            user.IsLoggedIn = true;

            user.OTPExpiry = null;
            user.OTPCode = null;
            user.LastLoggedInDeviceAddress = _baseDTO.MacAddress;
            _context.Update(user);
            _context.SaveChanges();
            await EmailHelper.SendEmail(input.Email, user.OTPCode, "Verifying OTP", "OTP Verified Successfully", _userConfiguration.EmailConfig);
            //for client false , to be an admin must be true argument 
            var response = _tokenService.GenerateAccessToken(GetClaims(user, false));
            return response;
        }
        public async Task<bool> ToggleUserBlockStatus(int userId)
        {
            var user = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
            user.IsBlocked = !user.IsBlocked;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user.IsBlocked;
        }
        private IEnumerable<Claim> GetClaims(User user, bool LoggedByPhoneNumber)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            LoggedInUser loggedInUser = new LoggedInUser
            {
                Email = user.Email,
                FullName = user.FirstName + " " + user.LastName,
                Id = user.Id,
                MobileNumber = user.PhoneNumber,
                IpAddress = _baseDTO.MacAddress,
                UserType = user.UserType,
                SelectedLanguage = user.SelectedLanguage,
                LoggedByPhoneNumber = LoggedByPhoneNumber,
                LoggedByEmail = !LoggedByPhoneNumber,
                CategoryId = user.CategoryId.HasValue ? user.CategoryId.Value : null,
                CategoryName = user.Category != null ? user.Category.CategoryName : null,
                ProviderId = user.ProviderId.HasValue ? user.ProviderId.Value : null,
                ProviderName = user.Provider != null ? user.Provider.Name : null,
            };

            var loggedInUserjson = JsonConvert.SerializeObject(loggedInUser, settings);
            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(UserSettingsClaimTypes.LoggedInUser,loggedInUserjson),
               new Claim("UserType", ((UserType)user.UserType).GetDescription())

            };
            if (Enum.IsDefined(typeof(UserType), user.UserType))
            {
                var roleName = ((UserType)user.UserType).ToString();
                claims.Add(new Claim(ClaimTypes.Role, roleName));
            }

            return claims;
        }
    }
}
