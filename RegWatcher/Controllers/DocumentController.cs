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
        private readonly ITagRepository _tagRepository;
        private readonly IDocumentManager _documentManager;

        public DocumentController(UserManager<ApplicationUser> userManager, DataContext context,
            IDocumentRepository documentRepository, ITagRepository tagRepository, 
            IDocumentManager documentManager)
        {
            _userManager = userManager;
            _context = context;
            _documentRepository = documentRepository;
            _tagRepository = tagRepository;
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
                document.OwnerUser, document.ResponsibleUser, document.DocumentTags.Select(dt => dt.Tag));
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector,HeadOfDepartment")]
        [HttpGet]
        public DocumentLiteModel LoadById(int documentId)
        {
            var document = _documentRepository.GetDocument(documentId);

            return new DocumentLiteModel(document, 
                string.Format($"{document.File.FileName}{document.File.FileExtension.ExtensionName}"),
                document.OwnerUser, document.ResponsibleUser, document.DocumentTags.Select(dt => dt.Tag));
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector,HeadOfDepartment")]
        [HttpPost]
        public JsonResult AddToTags(int documentId, [FromBody] IEnumerable<int> tags)
        {
            var document = _documentRepository.GetDocument(documentId);
            IEnumerable<Tag> foundedTags = tags.Select(t=>_tagRepository.GetTag(t));
            _documentManager.AddDocumentToTags(document, foundedTags);
            object data = null;

            return new JsonResult(new { data, success = "true" });
        }

        [Authorize(Roles = "Administrator,Specialist,Inspector,HeadOfDepartment")]
        [HttpPost]
        public IEnumerable<DocumentLiteModel> GetDocumentsByTag(string tagName, int page, int countPerPage)
        {
            return _documentManager.GetDocumentsByTagName(tagName, page, countPerPage)
                .Select(d => new DocumentLiteModel(d,
                    string.Format($"{d.File.FileName}{d.File.FileExtension.ExtensionName}"),
                    d.OwnerUser, d.ResponsibleUser, d.DocumentTags.Select(dt => dt.Tag)))
                .ToList(); ;
        }

        [Authorize(Roles = "Inspector,Administrator,Specialist,HeadOfDepartment")]
        [HttpPost]
        public IEnumerable<DocumentLiteModel> GetFiltredDocuments(DocumentFilter filter,
            int page, int countPerPage = 10)
        {
            return _documentManager.GetDocumentsByFilter(filter, page, countPerPage)
                .Select(d => new DocumentLiteModel(d,
                    string.Format($"{d.File.FileName}{d.File.FileExtension.ExtensionName}"),
                    d.OwnerUser, d.ResponsibleUser, d.DocumentTags.Select(dt => dt.Tag)))
                .ToList();
        }

        [Authorize(Roles = "Inspector,Administrator,Specialist,HeadOfDepartment")]
        [HttpGet]
        public DocumentLiteModel ChangeDocumentStep(int documentId, int stepId)
        {
            try
            {
                var document = _documentManager.GetDocumentById(documentId);
                if (document == null)
                    throw new Exception("Документ не был найден");
                _documentManager.ChangeDocumentStep(document, stepId);
                return new DocumentLiteModel(document,
                    string.Format($"{document.File.FileName}{document.File.FileExtension.ExtensionName}"),
                    document.OwnerUser, document.ResponsibleUser, document.DocumentTags.Select(dt => dt.Tag));
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось поменять состояние документа из-за ошибки: {ex.Message}");
            }
        }

        [Authorize(Roles = "Inspector,Administrator,Specialist,HeadOfDepartment")]
        [HttpGet]
        public async Task<DocumentLiteModel> ChangeDocumentResponsibleUser(int documentId, string userId)
        {
            try
            {
                var document = _documentManager.GetDocumentById(documentId);
                if (document == null)
                    throw new Exception("Документ не был найден");
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    throw new Exception("Пользователь не был найден");
                _documentManager.ChangeResponsibleUser(document, user);
                return new DocumentLiteModel(document,
                    string.Format($"{document.File.FileName}{document.File.FileExtension.ExtensionName}"),
                    document.OwnerUser, document.ResponsibleUser, document.DocumentTags.Select(dt => dt.Tag));
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось поменять ответственного сотрудника документа из-за ошибки: {ex.Message}");
            }
        }
    }
}