using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegWatcher.Data;
using RegWatcher.Filters;
using RegWatcher.Interfaces;
using RegWatcher.Interfaces.IRepositories;
using RegWatcher.Models.ViewModels;
using RegWatcher.Notifiers;
using RegWatcher.Notifiers.Email;
using RegWatcher.Extensions;

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
        private readonly IUserRepository _userRepository;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
            DataContext context, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _computerFabric = new ComputerNotifierFabric();
            _context = context;
            _userRepository = userRepository;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Registration([FromBody]RegistrationUser user)
        {
            try
            {
                _context.Database.BeginTransaction();
                var applicationUser = new ApplicationUser()
                {
                    Email = user.Email,
                    UserName = user.Email,
                    FirstName = user.FirstName.Trim(),
                    SecondName = user.SecondName.Trim(),
                    LastName = user.LastName != null ? user.LastName.Trim() : ""
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
            var user = await _userManager.GetUserAsync(User);
            var token = _userManager.GenerateEmailConfirmationTokenAsync(user);
            var emailNotifier = _computerFabric.CreateEmailConfirmationNotifier();
            emailNotifier.Notify(user, await token, new EmailSender());
        }

        [HttpGet]
        [Authorize]
        public async Task<IdentityResult> ConfirmEmail(ConfirmEmailModel data)
        {
            var user = await _userManager.GetUserAsync(User);
            var res = await _userManager.ConfirmEmailAsync(user, data.Token);
            if (res.Succeeded)
                return await _userManager.AddToRoleAsync(user, Roles.Administrator.ToString());
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
        public async Task<RedirectResult> Login([FromBody]AuthenticationUser user, string returnUrl)
        {
            var applicationUser = await _userManager.FindByEmailAsync(user.Email);
            var r = await _signInManager.PasswordSignInAsync(applicationUser, user.Password, user.RememberMe, false);
            if (!r.Succeeded)
                throw new Exception("Пользователь не найден или неверно указаны почта или пароль");

            return Redirect(string.IsNullOrEmpty(returnUrl) ? "/Home/" : returnUrl);
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<string>> GetMyRoles()
        {
            var requestedUser = await _userManager.GetUserAsync(User);
            return requestedUser != null ? 
                await _userManager.GetRolesAsync(requestedUser) : 
                throw new Exception("Не удалось найти пользователя. Перезайдите в приложение");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IEnumerable<string>> GetRoles(string userId)
        {
            var requestedUser = await _userManager.FindByIdAsync(userId);
            return requestedUser != null ?
                await _userManager.GetRolesAsync(requestedUser) :
                throw new Exception("Не удалось найти профиль запрошенного пользователя.");
        }

        [HttpPost]
        [Authorize(Roles = "User,Administrator")]
        public async Task<IdentityResult> AddToRoles([FromBody]IEnumerable<string> roles, string userId)
        {
            var requestedUser = await _userManager.FindByIdAsync(userId);
            if (requestedUser == null)
                throw new Exception("Не удалось найти профиль запрошенного пользователя.");
            return await _userManager.AddToRolesAsync(requestedUser, roles);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IdentityResult> RemoveFromRoles([FromBody]IEnumerable<string> roles, string userId)
        {
            var requestedUser = await _userManager.FindByIdAsync(userId);
            if (requestedUser == null)
                throw new Exception("Не удалось найти профиль запрошенного пользователя.");
            return await _userManager.RemoveFromRolesAsync(requestedUser, roles);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IEnumerable<ApplicationUserModel> GetUsers(int page, int countPerPage = 10)
        {
            return _userManager.GetPagedUsers(_userRepository, page, countPerPage);
        }

        [HttpPost]
        [Authorize]
        public async Task<IdentityResult> ChangePassword([FromBody]string currentPassword, [FromBody]string newPassword )
        {
            var user = await _userManager.GetUserAsync(User);
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IEnumerable<string> GetAllRoles()
        {
            return _context.ApplicationRoles.Select(r => r.Name);
        }

    }
}