using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs.Auth;
using Picktime.Entities;
using Picktime.Interfaces;

namespace Picktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuth _IAuth;

        public AuthController(IAuth IUserAuth)
        {
            _IAuth = IUserAuth;
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(SignUpDTO input)
        {
            try
            {
                var result = await _IAuth.SignUp(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<IActionResult> SignUpCreators(SignUpCreatorDTO input)
        {
            try
            {
                var result = await _IAuth.SignUpCreator(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(SignInInputDTO input)
        {
            try
            {
                var result = await _IAuth.SignIn(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ResetPassword(ResetPasswordInputDTO input)
        {
            try
            {
                var result = await _IAuth.ResetPassword(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendOTP(string email)
        {
            try
            {
                var response = await _IAuth.SendOTP(email);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignOut(int userId)
        {
            try
            {
                var response = await _IAuth.SignOut(userId);
               
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Verification([FromBody] VerificationInputDTO input)
        {
            try
            {
                var response = await _IAuth.Verification(input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPatch("[action]")]
        public async Task<IActionResult> ToggleUserBlockStatus(int userId)
        {
            try
            {
                var response = await _IAuth.ToggleUserBlockStatus(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
