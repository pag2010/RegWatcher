using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegWatcher.Data;
using RegWatcher.Filters;
using RegWatcher.Interfaces.IRepositories;
using RegWatcher.Models.ViewModels;

namespace RegWatcher.Controllers
{
    [Route("api/[controller]/[action]")]
    [ActionFilterValidation]
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;
        private readonly DataContext _context;

        public TagController(DataContext context, ITagRepository tagRepository)
        {
            _context = context;
            _tagRepository = tagRepository;
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector,HeadOfDepartment")]
        [HttpGet]
        public async Task<JsonResult> AddTag(string tagName)
        {
            var tag = new Tag()
            {
                Name = tagName
            };

            await _tagRepository.AddTag(tag);

            await _context.SaveChangesAsync();

            object data = null;

            return new JsonResult(new { data, success = true});
        }
    }
}