using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Resource;

namespace infarstuructre.ViewModel
{
    public class RolesViewModel
    {
        public RolesViewModel()
        {
            Roles = new List<IdentityRole>();
            NewRole = new NewRole();
        }
        public List<IdentityRole> Roles { get; set; }
        public NewRole NewRole { get; set; }

    }
    public class NewRole
    {
        public string Id { get; set; }
        //[Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RoleName")]
        public string RoleName { get; set; }
    }
}
