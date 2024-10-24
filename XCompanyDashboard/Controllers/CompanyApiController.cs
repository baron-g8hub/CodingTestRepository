using DataAccess.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace XCompanyDashboard.Controllers
{

    // TODO: Implement User Role filtering

    [Route("api/company")]
    [ApiController]
    public class CompanyApiController : ControllerBase
    {

        private readonly ICompanyProfileRepository _companyRepo;

        public CompanyApiController(ICompanyProfileRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _companyRepo.GetCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
