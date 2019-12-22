using RegWatcher.Data;
using RegWatcher.Models.ViewModels;
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
        void AddDocumentToTag(Document document, Tag tag);
        IQueryable<Document> GetDocumentsByFilter(DocumentFilter filter);
        void ChangeDocumentStep(Document document, int stepId);
        void ChangeResponsibleUser(Document document, string userId);
    }
}
