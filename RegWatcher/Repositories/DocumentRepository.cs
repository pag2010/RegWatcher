using RegWatcher.Data;
using RegWatcher.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DataContext _context;

        public DocumentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddDocumentAsync(Document document)
        {
            await _context.AddAsync(document);
        }

        public Document GetDocument(int documentId)
        {
            return _context.Documents.Where(d=>d.DocumentId == documentId).SingleOrDefault();
        }

        public Document GetDocument(string documentNumber)
        {
            return _context.Documents.Where(d => d.Number.ToLower() == documentNumber.ToLower()).SingleOrDefault();
        }

        public IQueryable<Document> GetPagedDocuments(int page, int countPerPage)
        {
            return _context.Documents
                .Skip((page-1) * countPerPage)
                .Take(countPerPage);
        }
    }
}
