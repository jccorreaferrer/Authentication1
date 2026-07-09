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
    //[Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var result = await _companyService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var result = await _companyService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        //[Authorize(Policy = "AdminOrManager")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyInsertDTO companyInsertDTO)
        {
            var (isSuccess, message, data) = await _companyService.AddAsync(companyInsertDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return CreatedAtAction(nameof(GetCompany), new { id = data.CompanyId }, data);
        }
        [HttpPut("{id}")]
        //[Authorize(Policy = "AdminOrManager")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompanyUpdateDTO companyUpdateDTO)
        {
            if (id != companyUpdateDTO.CompanyId) return BadRequest("ID mismatch");
            var (isSuccess, message) = await _companyService.UpdateAsync(companyUpdateDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return NoContent();
        }
        [HttpDelete]
        //[Authorize(Policy = "SuperAdminOnly")]
        public async Task<IActionResult> DeleteCompany([FromBody] CompanyDeleteDTO companyDeleteDTO)
        {
            var (isSuccess, message) = await _companyService.DeleteAsync(companyDeleteDTO);
            if (!isSuccess) return BadRequest(new { error = message });
            return NoContent();
        }

        [HttpGet("db")]
        public IStatusCodeActionResult db() 
        {
            return Ok(_companyService.GetConnectionStrignDB());        
        }
    }
}
