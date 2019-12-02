using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegWatcher.Data;
using RegWatcher.Filters;
using RegWatcher.Interfaces;
using RegWatcher.Models.ViewModels;
using RegWatcher.Notifiers;
using RegWatcher.Notifiers.Email;

namespace RegWatcher.Controllers
{
    [Route("api/[controller]/[action]")]
    [ActionFilterValidation]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly INotifierFabric _computerFabric;
        private readonly DataContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, DataContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _computerFabric = new ComputerNotifierFabric();
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Registration(RegistrationUser user)
        {
            try
            {
                _context.Database.BeginTransaction();
                var applicationUser = new ApplicationUser()
                {
                    Email = user.Email,
                    UserName = string.Format($"{user.FirstName.Trim().Replace(" ", "_")} {user.SecondName.Trim().Replace(" ", "_")} {user.LastName.Trim().Replace(" ", "_")}")
                };

                var regResult = await _userManager.CreateAsync(applicationUser, user.Password);

                if (regResult.Succeeded)
                {
                    var registredUser = await _userManager.FindByEmailAsync(user.Email);
                    var token = _userManager.GenerateEmailConfirmationTokenAsync(registredUser);
                    var emailNotifier = _computerFabric.CreateEmailConfirmationNotifier();
                    emailNotifier.Notify(registredUser, await token, new EmailSender());

                    _context.Database.CommitTransaction();
                    return new JsonResult(new { success = true, data = token });
                }
                else
                {
                    _context.Database.RollbackTransaction();
                    throw new Exception("Ошибка при регистрации пользователя");
                }
                
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                throw ex;
            }
        }

        [HttpGet]
        [Authorize]
        public async Task GenerateEmailConfirmationToken()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);
            var token = _userManager.GenerateEmailConfirmationTokenAsync(user);
            var emailNotifier = _computerFabric.CreateEmailConfirmationNotifier();
            emailNotifier.Notify(user, await token, new EmailSender());
        }

        [HttpGet]
        [Authorize]
        public async Task<IdentityResult> ConfirmEmail(ConfirmEmailModel data)
        {
            var user = await _userManager.FindByEmailAsync(data.Email);
            var res = await _userManager.ConfirmEmailAsync(user, data.Token);
            if (res.Succeeded)
                return await _userManager.AddToRoleAsync(user, Roles.User.ToString());
            return res;
        }

        /*[HttpPost]
        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(AuthenticationUser user)
        {
            var applicationUser = await _userManager.FindByEmailAsync(user.Email);
            var r = await _signInManager.PasswordSignInAsync(applicationUser, user.Password, user.RememberMe, false);
            return r;
        }*/

        [HttpPost]
        public async Task<RedirectResult> Login(AuthenticationUser user, string returnUrl)
        {
            var applicationUser = await _userManager.FindByEmailAsync(user.Email);
            var r = await _signInManager.PasswordSignInAsync(applicationUser, user.Password, user.RememberMe, false);
            if (r.Succeeded)
                return Redirect(returnUrl);
            throw new Exception("Пользователь не найден или неверно указаны почта или пароль");
        }

        [HttpGet]
        [Authorize]
        public async Task<IList<string>> GetMyRoles()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var requestedUser = await _userManager.FindByIdAsync(userId);
            return await _userManager.GetRolesAsync(requestedUser);
        }
    }
}