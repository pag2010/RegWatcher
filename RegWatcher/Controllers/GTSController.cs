using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegWatcher.Data;
using RegWatcher.Filters;
using RegWatcher.Interfaces.IManagers;
using RegWatcher.Models.ViewModels;

namespace RegWatcher.Controllers
{
    [Route("api/[controller]/[action]")]
    [ActionFilterValidation]
    public class GTSController : Controller
    {
        private readonly IGTSManager _gtsManager;

        public GTSController(IGTSManager gtsManager)
        {
            _gtsManager = gtsManager;
        }

        [Authorize(Roles = "Inspector,Administrator,Specialist,HeadOfDepartment")]
        [HttpPost]
        public GTSModel Add([FromBody]GTSModel gtsModel)
        {
            var gts = _gtsManager.Add(gtsModel);
            return new GTSModel(gts);
        }

        [Authorize(Roles = "Inspector,Administrator,Specialist,HeadOfDepartment")]
        [HttpPost]
        public GTSModel Change([FromBody]GTSModel gtsModel)
        {
            var gts = _gtsManager.Change(gtsModel);
            return new GTSModel(gts);
        }

        [Authorize(Roles = "Inspector,Administrator,Specialist,HeadOfDepartment")]
        [HttpGet]
        public GTSModel GetById(int gtsId)
        {
            var gts = _gtsManager.GetById(gtsId);
            return new GTSModel(gts);
        }
    }
}