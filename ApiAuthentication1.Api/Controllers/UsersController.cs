using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Application.Interfaces.Services;

namespace ApiAuthentication1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public UsersController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _appUserService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _appUserService.GetByIdAsync(id);
            if (result == null)  return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOrManager")]
        public async Task<IActionResult> CreateUser([FromBody] AppUserInsertDTO appUserInsertDTO)
        {
            var (isSuccess, message, data) = await _appUserService.AddAsync(appUserInsertDTO);
            if (!isSuccess)  return BadRequest(new { error = message });
            return CreatedAtAction(nameof(GetUser), new { id = data.AppUserId }, data);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminOrManager")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] AppUserUpdateDTO appUserUpdateDTO)
        {

            if (id != appUserUpdateDTO.AppUserId)  return BadRequest("ID mismatch");
            var (isSuccess, message) = await _appUserService.UpdateAsync(appUserUpdateDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return NoContent();
        }

        [HttpDelete]
        [Authorize(Policy = "SuperAdminOnly")]
        public async Task<IActionResult> DeleteUser([FromBody] AppUserDeleteDTO appUserDeleteDTO)
        {
            var (isSuccess, message) = await _appUserService.DeleteAsync(appUserDeleteDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return NoContent();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] AppUserChangePasswordDTO appUserChangePasswordDTO)
        {
            var (isSuccess, message) = await _appUserService.ChangePasswordAsync(appUserChangePasswordDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return NoContent();
        }
    }
}
