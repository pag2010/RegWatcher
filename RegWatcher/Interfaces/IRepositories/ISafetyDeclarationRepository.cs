using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IRepositories
{
    public interface ISafetyDeclarationRepository
    {
        void Add(SafetyDeclaration declaration);

        SafetyDeclaration GetById(int declarationId);

        void Change(SafetyDeclaration oldDeclaration, SafetyDeclaration newDeclaration);

        void AttachDocument(SafetyDeclaration declaration, Document document);
    }
}
