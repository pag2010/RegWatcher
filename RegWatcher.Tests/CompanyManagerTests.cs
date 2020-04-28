using Moq;
using NUnit.Framework;
using RegWatcher.Data;
using RegWatcher.Data.Enums;
using RegWatcher.Interfaces.IManagers;
using RegWatcher.Interfaces.IRepositories;
using RegWatcher.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Tests
{
    public class CompanyManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestGetCompany()
        {
            Mock<ICompanyRepository> companyRepository = new Mock<ICompanyRepository>();
            int id = 1;
            var company = new Company() { CompanyId = id};
            companyRepository.Setup(cr => cr.GetCompanyById(It.IsAny<int>())).Returns(company);
            ICompanyManager manager = new CompanyManager(null, companyRepository.Object);
            Assert.That(manager.GetCompanyById(id).CompanyId, Is.EqualTo(id));
        }

        [Test]
        public void TestChangeCompanyStep()
        {
            Mock<ICompanyRepository> companyRepository = new Mock<ICompanyRepository>();
            int id = 1;
            Steps step = Steps.New;
            var company = new Company() { CompanyId = id };
            companyRepository.Setup(cr => cr.ChangeCompanyStep(It.IsAny<Company>(),
                It.Is<int>(it=> (Enum.IsDefined(typeof(Steps), it)))));
            companyRepository.Setup(cr => cr.SaveChanges());
            ICompanyManager manager = new CompanyManager(null, companyRepository.Object);
            manager.ChangeCompanyStep(company, (int)step);
            companyRepository.Verify();
        }
    }
}
