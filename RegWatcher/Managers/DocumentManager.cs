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
        private readonly DataContext _context;

        public DocumentManager(IDocumentRepository documentRepository, DataContext context)
        {
            _documentRepository = documentRepository;
            _context = context;
        }

        public IQueryable<Document> GetPagedDocuments(int page, int countPerPage)
        {
            return _documentRepository.GetPagedDocuments(page, countPerPage);
        }

        public async Task AddDocumentAsync(Document document)
        {
            if (_context.Documents.Any(d=>d.Number.ToLower() == document.Number.ToLower()))
            {
                throw new Exception($"Документ с номером {document.Number} уже существует");
            }
            await _documentRepository.AddDocumentAsync(document);
        }
    }
}
