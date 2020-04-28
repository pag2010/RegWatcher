using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using RegWatcher.Data;
using RegWatcher.Data.Enums;
using RegWatcher.Interfaces.IManagers;
using RegWatcher.Interfaces.IRepositories;
using RegWatcher.Managers;
using RegWatcher.Models.ViewModels;

namespace RegWatcher.Tests
{
    public class DocumentManagerTests
    {
        private const string ExistingNumber = "existingDocNumber123";
        private const int page = 2;
        private const int count = 2;
    
        private readonly Mock<IDocumentRepository> _documentRepository = new Mock<IDocumentRepository>();
        private Document document = new Document() { Number = ExistingNumber, DocumentId = 1, StepId = Steps.Accepted };
        private DocumentFilter filter = new DocumentFilter() { IsOwner = true };
        private ApplicationUser user = new ApplicationUser() { Id = "72af2e71-1429-4d79-ad75-87ea557885b3" };

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestAddExistingDocumentNumber()
        {
            _documentRepository.Setup(d => d.GetDocument(ExistingNumber)).Returns(document);
            IDocumentManager manager = new DocumentManager(_documentRepository.Object, null, null, null);
            Assert.That(() => manager.AddDocumentAsync(document),
                Throws.Exception.With.Property("Message")
                .EqualTo($"Документ с номером { document.Number} уже существует"));
        }

        [Test]
        public void TestChangeDocumentStep()
        {
            _documentRepository.Setup(d => d.SaveChanges());
            _documentRepository.Setup(d => d.ChangeDocumentStep(document, (int)Steps.Completed));
            IDocumentManager manager = new DocumentManager(_documentRepository.Object, null, null, null);
            manager.ChangeDocumentStep(document, (int)Steps.Completed);
            _documentRepository.Verify();
        }

        [Test]
        public void TestGetDocumentsByFilter()
        {
            var queryList = new List<Document>();
            queryList.Add(document);
            queryList.Add(document);
            queryList.Add(new Document() { DocumentId = 3});
            queryList.Add(new Document() { DocumentId = 4});
            _documentRepository.Setup(d => d.GetDocumentsByFilter(filter))
                .Returns(queryList.AsQueryable());
            IDocumentManager manager = new DocumentManager(_documentRepository.Object, null, null, null);
            var result = manager.GetDocumentsByFilter(filter, page, count)
                .OrderBy(r=>r.DocumentId).ToList();
            for (int i = 0; i < count; i++)
            {
                if (result[i].DocumentId != queryList[(page - 1) * count + i].DocumentId)
                    Assert.Fail("Найдено несовпадение в ожидаемом списке и полученном");
            } 
        }

        [Test]
        public void TestChangeDocumentResponsibleUser()
        {
            _documentRepository.Setup(d=>d.ChangeResponsibleUser(document, user.Id));
            IDocumentManager manager = new DocumentManager(_documentRepository.Object, null, null, null);
            manager.ChangeResponsibleUser(document, user);
            _documentRepository.Verify(dr=>dr.ChangeResponsibleUser(It.IsAny<Document>(), user.Id));
        }
    }
}
