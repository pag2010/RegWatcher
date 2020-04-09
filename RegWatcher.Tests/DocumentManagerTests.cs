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
            IDocumentManager manager = new DocumentManager(_documentRepository.Object, null, null, null);
            manager.ChangeDocumentStep(document, (int)Steps.Accepted);
            Assert.That(document.StepId, Is.EqualTo(Steps.Accepted));
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
    }
}
