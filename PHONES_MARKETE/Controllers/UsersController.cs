using Bl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PHONES_MARKETE.Areas.admin.Controllers;
using PHONES_MARKETE.Models;
using System.Collections.Generic;

namespace PHONES_MARKETE.Controllers
{
    public class UsersController : Controller
    {

        UserManager<MyApplicationUser> _userManager;
        SignInManager<MyApplicationUser> _signInManager;
        public UsersController(UserManager<MyApplicationUser> userManager,
            SignInManager<MyApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login(string returnUrl)
        {
            UserModelUrl model = new UserModelUrl()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        public async Task<IActionResult> LoginOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public IActionResult Register()
        {
            return View(new UserModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            if (!ModelState.IsValid)
                return View("Register", model);

            var user = new MyApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                 PhoneNumber = model.PhoneNumber,
                City = model.City
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // If the user is signed in and in the Admin role, then it is
                    // the Admin user that is creating a new user. So redirect the
                    // Admin user to ListRoles action
                    if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        var User = await _userManager.FindByEmailAsync(user.Email);
                        await _userManager.AddToRoleAsync(User, "Customer");

                        return RedirectToAction("List","AllUsers", new { area = "admin" });
                      
                    }

                    var loginResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                    var myUser = await _userManager.FindByEmailAsync(user.Email);
                    await _userManager.AddToRoleAsync(myUser, "Customer");
                    if (loginResult.Succeeded)
                        return RedirectToAction("Index", "Home");
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
            return View(new UserModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModelUrl model)
        {
            MyApplicationUser user = new MyApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email
            };
            try
            {
                var loginResult = await _signInManager.PasswordSignInAsync(user.Email, model.Password, true, true);
                if (loginResult.Succeeded)
                {
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                        return Redirect("~/");
                    else
                        return Redirect(model.ReturnUrl);
                }
            }
            catch (Exception ex)
            {

            }
            return View(new UserModel());
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
