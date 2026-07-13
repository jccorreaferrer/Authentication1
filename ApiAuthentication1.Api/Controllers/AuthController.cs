using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiAuthentication1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IPasswordResetService _passwordResetService;

        public AuthController(IAuthService authService, IPasswordResetService passwordResetService)
        {
            _authService = authService;
            _passwordResetService = passwordResetService;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] string user, [FromQuery] string password, [FromQuery] int applicationId)
        {
            var token = await _authService.LoginAsync(user, password, applicationId);
            if (token == null)
            {
                return Unauthorized("Invalid credentials or license.");
            }
            return Ok(new { token });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (login == null)
            {
                return BadRequest("Request is required.");
            }

            if (string.IsNullOrWhiteSpace(login.User))
            {
                return BadRequest("User is required.");
            }

            if (string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest("Password is required.");
            }

            if (login.ApplicationId <= 0)
            {
                return BadRequest("ApplicationId is required.");
            }
            var token = await _authService.LoginAsync(login.User, login.Password, login.ApplicationId);
            if (token == null)
            {
                return Unauthorized("Invalid credentials or license.");
            }

            return Ok(new { token });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordDTO)
        {
            var (isSuccess, message) = await _passwordResetService.ForgotPasswordAsync(forgotPasswordDTO);
            if (!isSuccess)
                return BadRequest(new { error = message });
            return Ok(new { message });
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var (isSuccess, message) = await _passwordResetService.ResetPasswordAsync(resetPasswordDTO);
            if (!isSuccess)
                return BadRequest(new { error = message });
            return Ok(new { message });
        }

    }
}