using Picktime.DTOs.Auth;
using Picktime.DTOs.Errors;

namespace Picktime.Interfaces
{
    public interface IAuth
    {

        Task<AppResponse> SignUp(SignUpDTO input);
        Task<AppResponse> SignUpCreator(SignUpCreatorDTO input);
        Task<AppResponse<LoginResponseDTO>> SignIn(SignInInputDTO input);
        Task<AppResponse<bool>> ResetPassword(ResetPasswordInputDTO input);
        Task<string> Verification(VerificationInputDTO input);
        Task<AppResponse<bool>> SendOTP(string email);
        Task<AppResponse<bool>> SignOut(int userId);
        Task<bool> ToggleUserBlockStatus(int userId);

    }
}
