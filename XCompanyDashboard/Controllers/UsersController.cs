using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using XCompanyDashboard.Models;
using XCompanyDashboard.ViewModels;

namespace XCompanyDashboard.Controllers
{
    public class UsersController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var vm = new UsersViewModel();
                var list = new List<User>();
                //vm.EntityList = list;
                //using (var httpClient = new HttpClient())
                //{
                //    var url = "http://" + HttpContext.Request.Host.Value;
                //    if (Request.Host.Host == "localhost")
                //    {
                //        url = "https://" + HttpContext.Request.Host.Value;
                //    }
                //    using (var response = await httpClient.GetAsync(url + "/AccountsApi/GetAccounts"))
                //    {
                //        if (response.IsSuccessStatusCode)
                //        {
                //            string apiResponse = await response.Content.ReadAsStringAsync();
                //            vm.EntityList = JsonConvert.DeserializeObject<List<Account>>(apiResponse);
                //        }
                //    }
                //}
                return View(vm);
            }
            catch (Exception ex)
            {
                //TODO: Log error
                return StatusCode(500, ex.Message);
            }
        }


    }
}
