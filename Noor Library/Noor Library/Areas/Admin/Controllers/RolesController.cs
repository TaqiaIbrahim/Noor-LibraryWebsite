using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Noor_Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;

namespace Noor_Library.Areas.Admin.Controllers
{
   
    [Area("Admin")]
  
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(IdentityRole model)
        {
            if(!ModelState.IsValid)
                return View("Index",await _roleManager.Roles.ToListAsync());
            if (await _roleManager.RoleExistsAsync(model.Name))
            {
                ModelState.AddModelError("Name", "هذه الصالحية موجودة بالفعل");
                return View("Index",await _roleManager.Roles.ToListAsync());

            }
            await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>Delete(string id)
        {
            var role= await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();
                await _roleManager.DeleteAsync(role);
            return RedirectToAction(nameof(Index));

            
        }









        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Add(RoleFormViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Index", await _roleManager.Roles.ToListAsync());
        //    }
        //  if(await _roleManager.RoleExistsAsync(model.Name))
        //    {
        //        ModelState.AddModelError("Name", "هذه الصلاحية موجودة بالفعل");
        //        return View("Index", await _roleManager.Roles.ToListAsync());
        //    }
        //    await _roleManager.CreateAsync(new IdentityRole  (  model.Name.Trim()));
        //    return RedirectToAction(nameof(Index));
        //}
        //public async Task<IActionResult> ManagePremissions(string roleId)
        //{
        //    var role = await _roleManager.FindByIdAsync(roleId);
        //    if (role == null)
        //        return NotFound();
        //    var roleclaims = _roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
        //    var allClaims = Premissions.GenerateAllPermissions();
        //    var allPremissions = allClaims.Select(p => new CheckBoxViewModel { DisplayValue = p }).ToList();
        //    foreach (var premission in allPremissions)
        //    {
        //        if (roleclaims.Any(c => c == premission.DisplayValue))
        //            premission.IsSelected = true;


        //    }
        //    var viewModel = new PermissionFormViewModel
        //    {
        //        RoleId = roleId,
        //        RoleName = role.Name,
        //        RoleClaims = allPremissions
        //    };
        //    return View(viewModel);


        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ManagePremissions(PermissionFormViewModel model)
        //{
        //    var role = await _roleManager.FindByIdAsync(model.RoleId);
        //    if (role == null)
        //        return NotFound();
        //    var roleclaims = await _roleManager.GetClaimsAsync(role);

        //    foreach (var claim in roleclaims)
        //    {
        //        await _roleManager.RemoveClaimAsync(role,claim);
        //    }
        //    var selectedClaims = model.RoleClaims.Where(c => c.IsSelected).ToList();
        //    foreach (var claim in selectedClaims)
        //        await _roleManager.AddClaimAsync(role, new Claim("Premission",claim.DisplayValue));
        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> Delete(string roleId)
        //{
        //    var role = await _roleManager.FindByIdAsync(roleId);
        //    if (role== null)
        //        return NotFound();

        //    await _roleManager.DeleteAsync(role);
        //    return RedirectToAction(nameof(Index));
    //}
}


    }
