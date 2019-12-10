using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IManagers
{
    public interface IDocumentManager
    {
        IQueryable<Document> GetPagedDocuments(int page, int countPerPage);
    }
}
