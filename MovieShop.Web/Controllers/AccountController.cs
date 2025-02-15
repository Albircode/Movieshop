﻿using Limilabs.Client.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.models.Request;
using MovieShop.Core.models.Response;
using MovieShop.Core.SeviceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUser(model);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel loginRequest , string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (!ModelState.IsValid) return View();
            var user = await _userService.ValidateUser(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname,  user.LastName),
                new Claim(ClaimTypes.NameIdentifier,  user.Id.ToString())
            };

var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = true });

            return LocalRedirect(returnUrl);
        }

      
    }
}
