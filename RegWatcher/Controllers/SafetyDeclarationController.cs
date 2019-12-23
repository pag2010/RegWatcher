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
using RegWatcher.Models.ViewModels;

namespace RegWatcher.Controllers
{
    [Route("api/[controller]/[action]")]
    [ActionFilterValidation]
    public class SafetyDeclarationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISafetyDeclarationManager _safetyDeclarationManager;

        public SafetyDeclarationController(UserManager<ApplicationUser> userManager,
            ISafetyDeclarationManager safetyDeclarationManager)
        {
            _safetyDeclarationManager = safetyDeclarationManager;
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector,HeadOdDepartment")]
        [HttpPost]
        public SafetyDeclarationModel Add([FromBody]SafetyDeclarationModel safetyDeclarationModel)
        {
            var declaration = _safetyDeclarationManager.Add(safetyDeclarationModel);
            return new SafetyDeclarationModel(declaration);
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector,HeadOdDepartment")]
        [HttpPost]
        public SafetyDeclarationModel Change([FromBody]SafetyDeclarationModel safetyDeclarationModel)
        {
            var declaration = _safetyDeclarationManager.Change(safetyDeclarationModel);
            return new SafetyDeclarationModel(declaration);
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector,HeadOdDepartment")]
        [HttpGet]
        public SafetyDeclarationModel GetById(int declarationId)
        {
            var declaration = _safetyDeclarationManager.GetById(declarationId);
            return new SafetyDeclarationModel(declaration);
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector,HeadOdDepartment")]
        [HttpGet]
        public SafetyDeclarationModel AttachDocument(int declarationId, int documentId)
        {
            var declaration = _safetyDeclarationManager.AttachDocument(declarationId, documentId);
            return new SafetyDeclarationModel(declaration);
        }
    }
}