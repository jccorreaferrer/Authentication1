using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuthentication1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IAppRoleService _appRoleService;
        public RoleController(IAppRoleService appRoleService)
        {
                _appRoleService = appRoleService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var result = await _appRoleService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("by-app/{appId}")]
        public async Task<IActionResult> GetByAppIdAsync(int appId)
        {
            var result = await _appRoleService.GetByIdAsync(appId);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        //[Authorize(Policy = "AdminOrManager")]
        public async Task<IActionResult> CreateRole([FromBody] AppRoleInsertDTO appRoleInsertDTO)
        {
            var (isSuccess, message, data) = await _appRoleService.AddAsync(appRoleInsertDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return CreatedAtAction(nameof(GetRole), new { id = data.AppRoleId}, data);
        }
        [HttpPut("{id}")]
        //[Authorize(Policy = "AdminOrManager")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] AppRoleUpdateDTO appRoleUpdateDTO)
        {
            if (id != appRoleUpdateDTO.AppRoleId) return BadRequest("ID mismatch");
            var (isSuccess, message) = await _appRoleService.UpdateAsync(appRoleUpdateDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return NoContent();
        }
        [HttpDelete]
        //[Authorize(Policy = "SuperAdminOnly")]
        public async Task<IActionResult> DeleteRole([FromBody] AppRoleDeleteDTO appRoleDeleteDTO)
        {
            var (isSuccess, message) = await _appRoleService.DeleteAsync(appRoleDeleteDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return NoContent();
        }
    }
}
