using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using XCompanyDashboard.Models;

namespace XCompanyDashboard.ViewModels
{
    public class UsersViewModel
    {
        public UsersViewModel()
        {
            EntityList = new List<User>();
            SelectListUserTypes = LoadUserTypes();
            SelectListCompanies = LoadCompanies();
        }

        public List<User>? EntityList { get; set; }
        public List<SelectListItem> SelectListUserTypes { get; set; }
        public List<SelectListItem> SelectListCompanies { get; set; }

        public List<SelectListItem> LoadUserTypes()
        {
            var types = new List<SelectListItem>()
            {
                new SelectListItem { Value = "1", Text = "Admin" },
                new SelectListItem { Value = "2", Text = "FlatUser" },
                new SelectListItem { Value = "3", Text = "Guest" },
            };
            return types;
        }

        // TODO: Get data from Company Repository
        public List<SelectListItem> LoadCompanies()
        {
            var types = new List<SelectListItem>()
            {
                new SelectListItem { Value = "1", Text = "Company1111" },
                new SelectListItem { Value = "2", Text = "Company2222" },
                new SelectListItem { Value = "3", Text = "Company3333" },
            };
            return types;
        }

        public int UserId { get; set; }


        [Required]
        [Display(Name = "User Name")]
        public string? Username { get; set; }

        [Required]
        [Display(Name = "User Type")]
        public int UserType { get; set; }

        [Required]
        [Display(Name = "User Company")]
        public int CompanyUid { get; set; }


        public bool IsActive { get; set; }

        public byte[]? RowVersion { get; set; }

    }
}
