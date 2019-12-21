using RegWatcher.Data;
using RegWatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IManagers
{
    public interface IDocumentManager
    {
        //IQueryable<Document> GetPagedDocuments(int page, int countPerPage);

        Task AddDocumentAsync(Document document);

        void AddDocumentToTags(Document document, IEnumerable<Tag> tags);

        IEnumerable<Document> GetDocumentsByTagName(string tagName, int page, int countPerPage);

        /*IEnumerable<Document> GetDocumentsByOwnerUser(DocumentFilter filter, int page, int countPerPage);

        IEnumerable<Document> GetDocumentsByResponsibleUser(DocumentFilter filter, int page, int countPerPage);*/
        IEnumerable<Document> GetDocumentsByFilter(DocumentFilter filter, int page, int countPerPage);
    }
}
