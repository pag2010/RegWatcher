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
using RegWatcher.Interfaces.IManagers;
using RegWatcher.Interfaces.IRepositories;
using RegWatcher.Models.ViewModels;

namespace RegWatcher.Controllers
{
    [Route("api/[controller]/[action]")]
    [ActionFilterValidation]
    public class DocumentController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _context;
        private readonly IDocumentRepository _documentRepository;
        private readonly IDocumentManager _documentManager;

        public DocumentController(UserManager<ApplicationUser> userManager, DataContext context,
            IDocumentRepository documentRepository, IDocumentManager documentManager)
        {
            _userManager = userManager;
            _context = context;
            _documentRepository = documentRepository;
            _documentManager = documentManager;
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector")]
        [HttpPost]
        public async Task<JsonResult> Upload([FromBody]DocumentModel document)
        {
            var user = await _userManager.GetUserAsync(User);

            var data = document.Data;
            var fileAttributes = document.FileName.Split('.');

            var doc = new Document()
            {
                Number = document.Number,
                OwnerUserId = user.Id,
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

            await _documentRepository.AddDocumentAsync(doc);

            await _context.SaveChangesAsync();

            return new JsonResult(new { success = true, data = doc.DocumentId });
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector,HeadOfDepartment")]
        [HttpGet]
        public DocumentLiteModel LoadByNumber(string documentNumber)
        {
            var document = _documentRepository.GetDocument(documentNumber);

            return new DocumentLiteModel(document, 
                string.Format($"{document.File.FileName}{document.File.FileExtension.ExtensionName}"),
                document.OwnerUser, document.ResponsibleUser);
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector,HeadOfDepartment")]
        [HttpGet]
        public DocumentLiteModel LoadById(int documentId)
        {
            var document = _documentRepository.GetDocument(documentId);

            return new DocumentLiteModel(document, 
                string.Format($"{document.File.FileName}{document.File.FileExtension.ExtensionName}"),
                document.OwnerUser, document.ResponsibleUser );
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector,HeadOfDepartment")]
        [HttpGet]
        public IEnumerable<DocumentLiteModel> LoadPaged(int page, int countPerPage = 10)
        {
            var documents = _documentManager.GetPagedDocuments(page, countPerPage);
            var docModels = documents.Select(d => new DocumentLiteModel(d, 
                string.Format($"{d.File.FileName}{d.File.FileExtension.ExtensionName}"), d.OwnerUser, d.ResponsibleUser))
            .ToList();
                
            return docModels;
        }
    }
}