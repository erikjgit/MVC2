using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC2.Models.ViewModel
{
    public class UsersViewModel
    {
        public List<UserViewModel> Users { get; set; }
        
    }
}
