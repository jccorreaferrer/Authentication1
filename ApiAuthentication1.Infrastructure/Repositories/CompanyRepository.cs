using ApiAuthentication1.Application.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

using ApiAuthentication1.Domain.Entities;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiAuthentication1.Infrastructure.Data.Configurations;

namespace ApiAuthentication1.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Company> GetByIdAsync(int companyId)
        {
            return await _context.Companies.FindAsync(companyId);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }
        public string GetConnectionStrignDB()
        {
            var builder = new SqlConnectionStringBuilder(_context.Database.GetConnectionString());
            return builder.InitialCatalog;
        }
    }
}