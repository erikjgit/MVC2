using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.ViewModel
{
    public class UserViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public string UserId { get; set; }
        public bool IsCurrentUser { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public string Role { get; set; }
        public string NewRole { get; set; }
    }
}
