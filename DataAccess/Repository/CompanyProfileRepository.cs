using DataAccess.Contracts;
using DataAccess.Dto;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.DataContextDapper;

namespace DataAccess.Repository
{
    public class CompanyProfileRepository : ICompanyProfileRepository
    {
        private readonly ApplicationDapperContext _context;

        public CompanyProfileRepository(ApplicationDapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyProfile>> GetCompanies()
        {
            var query = "SELECT * FROM Companies";

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<CompanyProfile>(query);
                return companies.ToList();
            }
        }

        public async Task<CompanyProfile> GetCompany(int id)
        {
            var query = "SELECT * FROM Companies WHERE CompanyId = @Id";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<CompanyProfile>(query, new { id });

                return company;
            }
        }

        public async Task<CompanyProfile> CreateCompany(CompanyProfileCreateDto company)
        {
            var query = "INSERT INTO Companies (CompanyName, IsActive, CreatedDate, CreatedBy, UpdatedDate, UpdatedBy) " +
                        "VALUES (@Companies, @IsActive, @GetUtcDate(), @CreatedBy, @GetUtcDate(),@UpdatedBy)" + "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("CompanyName", company.CompanyName, DbType.String);
            parameters.Add("IsActive", company.IsActive, DbType.Boolean);
            parameters.Add("CreatedBy", company.CreatedBy, DbType.String);
            parameters.Add("UpdatedBy", company.CreatedBy, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdCompany = new CompanyProfile
                {
                    CompanyId = id,
                    CompanyName = company.CompanyName,
                    IsActive = company.IsActive,
                    CreatedDate = company.CreatedDate,
                    CreatedBy = company.CreatedBy,
                    UpdatedDate = company.CreatedDate,
                    UpdatedBy = company.CreatedBy,
                };
                return createdCompany;
            }
        }

        public async Task UpdateCompany(int id, CompanyProfileUpdateDto company)
        {
            var query = "UPDATE Companies SET CompanyName = @CompanyName, IsActive = @IsActive, UpdatedBy = @UpdatedBy WHERE CompanyId = @CompanyId";

            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", id, DbType.Int32);
            parameters.Add("CompanyName", company.CompanyName, DbType.String);
            parameters.Add("IsActive", company.IsActive, DbType.Boolean);
            parameters.Add("UpdatedBy", company.UpdatedBy, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCompany(int id)
        {
            var query = "DELETE FROM Companies WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<CompanyProfile> GetCompanyByEmployeeId(int id)
        {
            var procedureName = "ShowCompanyForProvidedEmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<CompanyProfile>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }

        //public async Task<CompanyProfile> GetCompanyEmployeesMultipleResults(int id)
        //{
        //    var query = "SELECT * FROM Companies WHERE Id = @Id;" +
        //                "SELECT * FROM Employees WHERE CompanyId = @Id";

        //    using (var connection = _context.CreateConnection())
        //    using (var multi = await connection.QueryMultipleAsync(query, new { id }))
        //    {
        //        var company = await multi.ReadSingleOrDefaultAsync<CompanyProfile>();
        //        if (company != null)
        //            company.Employees = (await multi.ReadAsync<Employee>()).ToList();

        //        return company;
        //    }
        //}

        //public async Task<List<CompanyProfile>> GetCompaniesEmployeesMultipleMapping()
        //{
        //    var query = "SELECT * FROM Companies c JOIN Employees e ON c.Id = e.CompanyId";

        //    using (var connection = _context.CreateConnection())
        //    {
        //        var companyDict = new Dictionary<int, CompanyProfile>();

        //        var companies = await connection.QueryAsync<CompanyProfile, Employee, CompanyProfile>(
        //            query, (company, employee) =>
        //            {
        //                if (!companyDict.TryGetValue(company.Id, out var currentCompany))
        //                {
        //                    currentCompany = company;
        //                    companyDict.Add(currentCompany.Id, currentCompany);
        //                }

        //                currentCompany.Employees.Add(employee);
        //                return currentCompany;
        //            }
        //        );

        //        return companies.Distinct().ToList();
        //    }
        //}

        //public async Task CreateMultipleCompanies(List<CompanyProfileCreateDto> companies)
        //{
        //    var query = "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)";

        //    using (var connection = _context.CreateConnection())
        //    {
        //        connection.Open();

        //        using (var transaction = connection.BeginTransaction())
        //        {
        //            foreach (var company in companies)
        //            {
        //                var parameters = new DynamicParameters();
        //                parameters.Add("Name", company.CompanyName, DbType.String);
        //                parameters.Add("Address", company.Address, DbType.String);
        //                parameters.Add("Country", company.Country, DbType.String);

        //                await connection.ExecuteAsync(query, parameters, transaction: transaction);
        //                //throw new Exception();
        //            }

        //            transaction.Commit();
        //        }
        //    }
        //}
    }
}
