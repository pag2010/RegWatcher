using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegWatcher.Data;
using RegWatcher.Filters;
using RegWatcher.Models.ViewModels;

namespace RegWatcher.Controllers
{
    [Route("api/[controller]/[action]")]
    [ActionFilterValidation]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IdentityResult> Registration(RegistrationUser user)
        {
            var applicationUser = new ApplicationUser()
            {
                Email = user.Email,
                UserName = user.Email
            };

            return await _userManager.CreateAsync(applicationUser, user.Password);
        }

        [HttpPost]
        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(AuthenticationUser user, string returnUrl)
        {
            var applicationUser = await _userManager.FindByEmailAsync(user.Email);
            var r = await _signInManager.PasswordSignInAsync(applicationUser, user.Password, user.RememberMe, false);
            return r;
        }

    }
}