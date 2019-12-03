using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegWatcher.Data;
using RegWatcher.Data.Enums;
using RegWatcher.Filters;
using RegWatcher.Models.ViewModels;

namespace RegWatcher.Controllers
{
    [Route("api/[controller]")]
    [ActionFilterValidation]
    public class DocumentController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _context;

        public DocumentController(UserManager<ApplicationUser> userManager, DataContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [Authorize(Roles = "User,Administrator,Specialist,Inspector")]
        [HttpPost]
        public async Task<JsonResult> Upload(DocumentModel document)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            if (userId == null)
                throw new Exception("Пользователь не найден");

            var data = document.Data;
            var fileAttributes = document.FileName.Split('.');

            var doc = new Document()
            {
                Number = document.Number,
                OwnerUserId = userId,
                ResponsibleUserId = document.ResponsibleUserId,
                DocumentTypeId = document.DocumentType,
                DeadLine = document.DeadLine,
                CreationDate = DateTimeOffset.Now,
                File = new File()
                {
                    CreationDate = DateTimeOffset.Now,
                    Data = data,
                    FileExtensionId = (FileExtensions)Enum.Parse(typeof(FileExtensions), fileAttributes[1]),
                    FileName = fileAttributes[0],
                    Guid = Guid.NewGuid()
                },
                StepId = Steps.New
            };

            _context.Add(doc);

            await _context.SaveChangesAsync();

            return new JsonResult(new { success = true, data = doc.DocumentId });
        }
    }
}