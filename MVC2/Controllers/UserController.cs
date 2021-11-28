using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            UsersViewModel vm = new UsersViewModel();
            vm.Users = new List<UserViewModel>();
            List<ApplicationUser> users = _userManager.Users.ToList();
            foreach(ApplicationUser user in users)
            {
                UserViewModel userViewModel = new UserViewModel();
                userViewModel.ApplicationUser = user;
                userViewModel.UserId =await _userManager.GetUserIdAsync(user);
                userViewModel.Roles = _roleManager.Roles.ToList<IdentityRole>();
                foreach (IdentityRole r in _roleManager.Roles)
                {
                    if (await _userManager.IsInRoleAsync(user, r.ToString()))
                    {
                        userViewModel.Role = r.ToString();
                        userViewModel.Roles.Remove(r);
                    }
                }
                if(userViewModel.UserId == _userManager.GetUserId(HttpContext.User))
                {
                    userViewModel.IsCurrentUser = true;
                }
                else
                {
                    userViewModel.IsCurrentUser = false;
                }
                vm.Users.Add(userViewModel);
            }
            
            return View(vm);
        }
        public async Task<IActionResult> ChangeRole(UserViewModel vm)
        {
            ApplicationUser applicationUser = await _userManager.FindByIdAsync(vm.UserId);
            IdentityResult result = await _userManager.RemoveFromRoleAsync(applicationUser, vm.Role);
            result = await _userManager.AddToRoleAsync(applicationUser, vm.NewRole);
            return (RedirectToAction("Index"));
        }
    }
}
