using DataAccess.Dto;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface ICompanyProfileRepository
    {
        public Task<IEnumerable<CompanyProfile>> GetCompanies();
        public Task<CompanyProfile> GetCompany(int id);
        public Task<CompanyProfile> CreateCompany(CompanyProfileCreateDto company);
        public Task UpdateCompany(int id, CompanyProfileUpdateDto company);
        public Task DeleteCompany(int id);
        public Task<CompanyProfile> GetCompanyByEmployeeId(int id);
        //public Task<CompanyProfile> GetCompanyEmployeesMultipleResults(int id);
        //public Task<List<CompanyProfile>> GetCompaniesEmployeesMultipleMapping();
        //public Task CreateMultipleCompanies(List<CompanyProfileCreateDto> companies);
    }
}
