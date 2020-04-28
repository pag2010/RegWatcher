using Microsoft.AspNetCore.Identity;
using RegWatcher.Data;
using RegWatcher.Interfaces.IManagers;
using RegWatcher.Interfaces.IRepositories;
using RegWatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Managers
{
    public class DocumentManager : IDocumentManager
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly ITagRepository _tagRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _context;

        public DocumentManager(IDocumentRepository documentRepository, ITagRepository tagRepository, 
            UserManager<ApplicationUser> userManager, DataContext context)
        {
            _documentRepository = documentRepository;
            _tagRepository = tagRepository;
            _userManager = userManager;
            _context = context;
        }

        public async Task AddDocumentAsync(Document document)
        {
            if (_documentRepository.GetDocument(document.Number) != null)
            {
                throw new Exception($"Документ с номером {document.Number} уже существует");
            }
            await _documentRepository.AddDocumentAsync(document);
        }

        public void AddDocumentToTags(Document document, IEnumerable<Tag> tags)
        {
            foreach (var t in tags)
            {
                if (document.DocumentTags.Any(dt => dt.TagId == t.TagId))
                    continue;
                _documentRepository.AddDocumentToTag(document, t);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Document> GetDocumentsByTagName(string tagName, int page, int countPerPage=10)
        {
            var tag = _tagRepository.GetTag(tagName);
            if (tag == null)
                throw new Exception($"Тег {tagName} не найден");
            return tag.DocumentTags.Select(dt => dt.Document).
                Skip((page-1)*countPerPage).
                Take(countPerPage);
        }

        public IEnumerable<Document> GetDocumentsByFilter(DocumentFilter filter, int page, int countPerPage)
        {
            var documents = _documentRepository.GetDocumentsByFilter(filter);
            return documents.Skip((page - 1) * countPerPage)
                .Take(countPerPage)
                .ToList();
        }

        public Document GetDocumentById(int documentId)
        {
            return _documentRepository.GetDocument(documentId);
        }

        public void ChangeDocumentStep(Document document, int stepId)
        {
            _documentRepository.ChangeDocumentStep(document, stepId);
            _documentRepository.SaveChanges();
        }

        public void ChangeResponsibleUser(Document document, ApplicationUser user)
        {
            _documentRepository.ChangeResponsibleUser(document, user.Id);
            _documentRepository.SaveChanges();
        }

        public Document GetDocument(string documentNumber)
        {
            return _documentRepository.GetDocument(documentNumber);
        }
    }
}
