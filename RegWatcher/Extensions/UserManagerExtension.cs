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

namespace RegWatcher.Extensions
{
    public static class UserManagerExtension
    {
        public static IEnumerable<ApplicationUserModel> GetPagedUsers(this UserManager<ApplicationUser> userManager, IUserRepository userRepository,int page, int countPerPage)
        {
            var pagedUsers = userRepository.GetPagedUsers(page, countPerPage);
            return pagedUsers.Select(u =>
                new ApplicationUserModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    IsEmailConfirmed = u.EmailConfirmed,
                    Name = u.UserName,
                    Roles = userManager.GetRolesAsync(u).Result
                }).ToList();
        }
    }
}
