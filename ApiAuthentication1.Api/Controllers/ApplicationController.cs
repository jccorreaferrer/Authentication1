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
    public class ApplicationController : ControllerBase
    {
        private readonly IAppService _appService;
        public ApplicationController(IAppService appService)
        {
            _appService = appService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var result = await _appService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplication(int id)
        {
            var result = await _appService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        //[Authorize(Policy = "AdminOrManager")]
        public async Task<IActionResult> CreateApp([FromBody] AppInsertDTO appInsertDTO)
        {
            var (isSuccess, message, data) = await _appService.AddAsync(appInsertDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return CreatedAtAction(nameof(GetApplication), new { id = data.AppId }, data);
        }
        [HttpPut("{id}")]
        //[Authorize(Policy = "AdminOrManager")]
        public async Task<IActionResult> UpdateApp(int id, [FromBody] AppUpdateDTO appUpdateDTO)
        {
            if (id != appUpdateDTO.AppId) return BadRequest("ID mismatch");
            var (isSuccess, message) = await _appService.UpdateAsync(appUpdateDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return NoContent();
        }
        [HttpDelete]
        //[Authorize(Policy = "SuperAdminOnly")]
        public async Task<IActionResult> DeleteApp([FromBody] AppDeleteDTO appDeleteDTO)
        {
            var (isSuccess, message) = await _appService.DeleteAsync(appDeleteDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return NoContent();
        }
    }
}
