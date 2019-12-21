using RegWatcher.Data;
using RegWatcher.Interfaces.IRepositories;
using RegWatcher.Models.ViewModels;
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

        public void AddDocumentToTag(Document document, Tag tag)
        {
            DocumentTag documentTag = new DocumentTag()
            {
                Document = document,
                Tag = tag
            };
            document.DocumentTags.Add(documentTag);
        }

        public IQueryable<Document> GetDocumentsByFilter(DocumentFilter filter)
        {
            var query = from document in _context.Documents
                        where (!filter.StartDate.HasValue || document.DeadLine >= filter.StartDate)
                        && (!filter.EndDate.HasValue || document.DeadLine < filter.EndDate)
                        && (!filter.StepId.HasValue || (int)document.StepId == filter.StepId.Value)
                        && (!filter.DocumentTypeId.HasValue || (int)document.DocumentTypeId == filter.DocumentTypeId)
                        && (!filter.IsResponsible || document.ResponsibleUserId.Contains(filter.UserId))
                        && (!filter.IsOwner || document.OwnerUserId.Contains(filter.UserId))
                        && (!(filter.DocumentNumber != null) 
                            || document.Number.ToLower().Contains(filter.DocumentNumber.ToLower()))
                        select document;

            return query;
        }
    }
}
