using Microsoft.AspNetCore.Mvc;
using Business.Dto;
using UI.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Contracts.Persistence.IRepository;
using Business.Services;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ILoginRepository _loginRep;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly UserAppService _userAppService;

        public AccountController(ILogger<AccountController> logger, ILoginRepository loginRep,
            UserManager<ApplicationUser> userManager,
            UserAppService userAppService,
            IConfiguration configuration)
        {
            _logger = logger;
            _loginRep = loginRep;
            _userManager = userManager;
            _configuration = configuration;
            _userAppService = userAppService;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginAsync(LoginDto login)
        {
            if (ModelState.IsValid)
            {
                var user = await _userAppService.Login(login);

                if (user != null)
                {
                    return Redirect("/home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return View(login);
        }

        [Authorize]
        public async Task<ActionResult> Logout()
        {
            var isLogout = await _userAppService.Logout();
            if (isLogout)
            {
                return Redirect("/home");
            }
            return RedirectToAction("Login");
        }
    }
}