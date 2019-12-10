using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IRepositories
{
    public interface IDocumentRepository
    {
        Task AddDocumentAsync(Document document);
        Document GetDocument(int documentId);
        Document GetDocument(string number);
        IQueryable<Document> GetPagedDocuments(int page, int countPerPage);
    }
}
