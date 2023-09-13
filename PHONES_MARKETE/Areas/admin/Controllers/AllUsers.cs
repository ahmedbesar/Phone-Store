using Bl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PHONES_MARKETE.Areas.admin.Models;
using System.Data;

namespace PHONES_MARKETE.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin,Data Entry")]
    public class AllUsers : Controller
    {
        UserManager<MyApplicationUser> usermanager;
        RoleManager<IdentityRole> roleManager;
        public AllUsers( UserManager<MyApplicationUser>Usermanager ,RoleManager<IdentityRole> RoleManager)
        {
            usermanager=Usermanager;
            roleManager = RoleManager;

        }

        public async Task<IActionResult>List()
        {
            var UserList=await usermanager.Users.ToListAsync();
            var users = UserList.Select(u => new MyApplicationUser()
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                City = u.City,
                UserRoles=string.Join(", ",usermanager.GetRolesAsync(u).Result.ToArray() )

            });
           
            
            return View(users);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await usermanager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            // GetClaimsAsync retunrs the list of user Claims
            var userClaims = await usermanager.GetClaimsAsync(user);
            // GetRolesAsync returns the list of user Roles
            var userRoles = await usermanager.GetRolesAsync(user);

            var model = new VmEditUser
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                City = user.City,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,

                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VmEditUser model)
        {
            var user = await usermanager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.City = model.City;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                                
                var result = await usermanager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await usermanager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await usermanager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("List");
            }
        }


        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userId = userId;

            var user = await usermanager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var model = new List<VmEditRoleInUser>();

            foreach (var role in roleManager.Roles.ToList())
            {
                var userRolesViewModel = new VmEditRoleInUser
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await usermanager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>ManageUserRoles(List<VmEditRoleInUser> model, string userId)
           {
            var user = await usermanager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var roles = await usermanager.GetRolesAsync(user);
            var result = await usermanager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await usermanager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("Edit", new { Id = userId });
        }
    }
}
