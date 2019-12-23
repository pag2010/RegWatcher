using RegWatcher.Data;
using RegWatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IManagers
{
    public interface ISafetyDeclarationManager
    {
        SafetyDeclaration Add(SafetyDeclarationModel model);

        SafetyDeclaration Change(SafetyDeclarationModel model);

        SafetyDeclaration GetById(int declarationId);

        SafetyDeclaration AttachDocument(int declarationId, int documentId);
    }
}
