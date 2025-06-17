using Picktime.DTOs;

namespace Picktime.Interfaces
{
    public interface IAuth
    {
        Task<string> Verification(VerificationInputDTO input);
        Task<bool> SendOTP(string email);
      
        Task<bool> SignOut(int userId);
    }
}
