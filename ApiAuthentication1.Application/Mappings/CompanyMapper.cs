using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Domain.Entities;


namespace ApiAuthentication1.Application.Mappings
{
    public static class CompanyMapper
    {
        public static CompanyReadDTO ToReadDTO(Company company)
        {
            if (company == null) return null;
            return new CompanyReadDTO
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                IsActive = company.IsActive,
                CreationDate = company.CreationDate,
            };
        }
        
        public static Company toCompany(CompanyInsertDTO companyInsertDTO)
        {
            return new Company
            {
                CompanyName = companyInsertDTO.CompanyName,
                IsActive = true,
                CreationDate=DateTime.Now,
            };
        }

        public static void toCompanyUpdateDTO(Company company, CompanyUpdateDTO companyUpdateDTO)
        {
            if (company == null) return;
     
            if(companyUpdateDTO.CompanyName!= null) company.CompanyName = companyUpdateDTO.CompanyName;
            if(companyUpdateDTO.IsActive.HasValue) company.IsActive = companyUpdateDTO.IsActive.Value;
        }
    }
}
