using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs;
using Picktime.Entities;
using Picktime.Interfaces;

namespace Picktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuth _IAuth;

        public  AuthController(IAuth IUserAuth)
        {
            _IAuth = IUserAuth;
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(SignUpInputDTO input)
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
                if (!response)
                    return BadRequest("Invalid email or already logged in.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult>  SignOut(int userId)
        {
            try
            {
                var response = await _IAuth.SignOut(userId);
                if (!response)
                    return NotFound("User not found or already signed out.");

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
    }
}
