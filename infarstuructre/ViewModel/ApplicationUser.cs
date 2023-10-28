using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infarstuructre.ViewModel
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string ImegeUser { get; set; }
        public bool ActionUser { get; set; }


    }
}
