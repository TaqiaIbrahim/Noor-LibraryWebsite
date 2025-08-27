using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Noor_Library.Models;
using Noor_Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Noor_Library.Areas.Admin.Controllers
{


    [Area("Admin")]

    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                firstName = user.firstName,
                lastName = user.lastName,
                UserName = user.UserName,
                Email = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result

            }).ToListAsync();

            return View(users);

        }
        public async Task<IActionResult> ManageRole(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
                return NotFound();
            var roles = await _roleManager.Roles.ToListAsync();
            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(role => new RoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRole(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();
            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in model.Roles)
            {

                if (userRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}


