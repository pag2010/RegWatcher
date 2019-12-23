using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegWatcher.Data;
using RegWatcher.Interfaces.IManagers;
using RegWatcher.Interfaces.IRepositories;
using RegWatcher.Models.ViewModels;

namespace RegWatcher.Managers
{
    public class SafetyDeclarationManager : ISafetyDeclarationManager
    {
        private readonly ISafetyDeclarationRepository _safetyDeclarationRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly DataContext _context;

        public SafetyDeclarationManager(DataContext context, ISafetyDeclarationRepository safetyDeclarationRepository,
             IDocumentRepository documentRepository)
        {
            _context = context;
            _safetyDeclarationRepository = safetyDeclarationRepository;
            _documentRepository = documentRepository;
        }

        public SafetyDeclaration Add(SafetyDeclarationModel model)
        {
            var safetyDeclaration = model.GetSafetyDeclaration();
            _safetyDeclarationRepository.Add(safetyDeclaration);
            _context.SaveChanges();
            return safetyDeclaration;
        }

        public SafetyDeclaration AttachDocument(int declarationId, int documentId)
        {
            var declaration = GetById(declarationId);
            var document = _documentRepository.GetDocument(documentId);

            if (declaration == null || document == null)
                throw new Exception("Декларация безопасности или документ не найдены");

            _safetyDeclarationRepository.AttachDocument(declaration, document);
            _context.SaveChanges();
            return declaration;
        }

        public SafetyDeclaration Change(SafetyDeclarationModel model)
        {
            var newSafetyDeclaration = model.GetSafetyDeclaration();
            var oldSafetyDeclaration = GetById(newSafetyDeclaration.SafetyDeclarationId);

            if (oldSafetyDeclaration == null)
                throw new Exception("Не удалось найти декларацию безопасности");

            _safetyDeclarationRepository.Change(oldSafetyDeclaration, newSafetyDeclaration);

            return oldSafetyDeclaration;
        }

        public SafetyDeclaration GetById(int declarationId)
        {
            return _safetyDeclarationRepository.GetById(declarationId);
        }
    }
}
