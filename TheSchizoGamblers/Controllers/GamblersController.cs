﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using TheSchizoGamblers.Data;
using TheSchizoGamblers.Models;
using TheSchizoGamblers.Models.ViewModels;

namespace TheSchizoGamblers.Controllers
{
    public class GamblersController : Controller
    {
        private readonly GamblersContext gamblersContext;
        private readonly UserManager<GamblersModel> _userManager;
        private readonly SignInManager<GamblersModel> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GamblersController(GamblersContext gamblersContext,
            UserManager<GamblersModel> userManager,
            SignInManager<GamblersModel> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.gamblersContext = gamblersContext;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Gamblers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Gamblers(GamblersViewModel addGamblerRequest)
        {
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (ModelState.IsValid)
            {

                GamblersModel user = new GamblersModel()
                {
                    UserName = addGamblerRequest.Username,
                    Email = addGamblerRequest.Email,
                    DateOfBirth = addGamblerRequest.DateOfBirth
                };
                var result = await _userManager.CreateAsync(user, addGamblerRequest.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(addGamblerRequest);
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel addLogInRequest)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByNameAsync(addLogInRequest.Username);

                if (user != null)
                {
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, addLogInRequest.Password);

                    if (passwordCheck)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, addLogInRequest.Password, false, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    TempData["Error"] = "The password or username doesn't match.";
                    return View(addLogInRequest);
                }
                TempData["Error"] = "The password or username doesn't match.";
            }

            return View(addLogInRequest);

        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}