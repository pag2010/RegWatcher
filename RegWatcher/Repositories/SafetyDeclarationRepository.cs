using RegWatcher.Data;
using RegWatcher.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Repositories
{
    public class SafetyDeclarationRepository : ISafetyDeclarationRepository
    {
        private readonly DataContext _context;

        public SafetyDeclarationRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(SafetyDeclaration declaration)
        {
            _context.SafetyDeclarations.Add(declaration);
        }

        public SafetyDeclaration GetById(int declarationId)
        {
           return _context.SafetyDeclarations.Where(sd=>sd.SafetyDeclarationId == declarationId).SingleOrDefault();
        }

        public void Change(SafetyDeclaration oldDeclaration, SafetyDeclaration newDeclaration)
        {
            oldDeclaration.GTSId = newDeclaration.GTSId;
            oldDeclaration.StartDate = newDeclaration.StartDate;
            oldDeclaration.EndDate = newDeclaration.EndDate;
        }

        public void AttachDocument(SafetyDeclaration declaration, Document document)
        {
            declaration.DocumentId = document.DocumentId;
        }
    }
}
