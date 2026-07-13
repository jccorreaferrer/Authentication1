using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading.Tasks;


namespace ApiAuthentication1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LicenseController : ControllerBase
    {

        private readonly ILicenseService _licenseService;

        public LicenseController(ILicenseService licenseService)
        {
         _licenseService = licenseService;       
        }
        [HttpGet]
        public async Task<IActionResult> GetLicenses()
        {
            var result = await _licenseService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLicense(int id)
        {
            var result = await _licenseService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        //[Authorize(Policy = "AdminOrManager")]
        public async Task<IActionResult> CreateLicense([FromBody] LicenseInsertDTO licenseInsertDTO)
        {
            var (isSuccess, message, data) = await _licenseService.AddAsync(licenseInsertDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return CreatedAtAction(nameof(GetLicense), new { id = data.LicenseId }, data);
        }
        [HttpPut("{id}")]
        //[Authorize(Policy = "AdminOrManager")]
        public async Task<IActionResult> UpdateLicense(int id, [FromBody] LicenseUpdateDTO licenseUpdateDTO)
        {
            if (id != licenseUpdateDTO.LicenseId) return BadRequest("ID mismatch");
            var (isSuccess, message) = await _licenseService.UpdateAsync(licenseUpdateDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return NoContent();
        }
        [HttpDelete]
        //[Authorize(Policy = "SuperAdminOnly")]
        public async Task<IActionResult> DeleteLicense([FromBody] LicenseDeleteDTO licenseDeleteDTO)
        {
            var (isSuccess, message) = await _licenseService.DeleteAsync(licenseDeleteDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return NoContent();
        }
    }
}
