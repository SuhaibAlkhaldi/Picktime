using Picktime.DTOs;

namespace Picktime.Interfaces
{
    public interface IAuth
    {
        public Task<string> SignUp(SignUpInputDTO input);
        Task<string> SignIn(SignInInputDTO input);
        Task<bool> ResetPassword(ResetPasswordInputDTO input);
    }
}
