using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegWatcher.Data;
using RegWatcher.Filters;
using RegWatcher.Interfaces.IManagers;
using RegWatcher.Managers;
using RegWatcher.Models.ViewModels;

namespace RegWatcher.Controllers
{
    [Route("api/[controller]/[action]")]
    [ActionFilterValidation]
    public class CheckingController : Controller
    {
        public readonly ICheckingManager _checkingManager;
        public readonly UserManager<ApplicationUser> _userManager;

        public CheckingController(ICheckingManager checkingManager, UserManager<ApplicationUser> userManager)
        {
            _checkingManager = checkingManager;
            _userManager = userManager;
        }

        [Authorize(Roles = "Administrator,Inspector,HeadOfDepartment")]
        [HttpPost]
        public CheckingModel Add([FromBody]CheckingModel model)
        {
            var checking = _checkingManager.Add(model);
            return new CheckingModel(checking);
        }

        [Authorize(Roles = "Administrator,Inspector,HeadOfDepartment")]
        [HttpPost]
        public CheckingModel Change([FromBody]CheckingModel model)
        {
            var checking = _checkingManager.Change(model);
            return new CheckingModel(checking);
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector,HeadOfDepartment")]
        [HttpGet]
        public CheckingModel GetById(int checkingId)
        {
            var checking = _checkingManager.GetById(checkingId);
            return new CheckingModel(checking);
        }
    }
}