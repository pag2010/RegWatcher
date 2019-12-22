using RegWatcher.Data;
using RegWatcher.Interfaces.IManagers;
using RegWatcher.Interfaces.IRepositories;
using RegWatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Managers
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly DataContext _context;
        public CompanyManager(DataContext context, ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
            _context = context;
        }

        public Company AddCompany(CompanyModel companyСlient, string userId)
        {
            var company = companyСlient.GetCompany();
            company.UserId = userId;
            _companyRepository.AddCompany(company);
            _context.SaveChanges();
            return company;
        }

        public Company ChangeCompany(CompanyModel companyModel, string userId)
        {
            var companyClient = companyModel.GetCompany();
            var company = _companyRepository.GetCompanyById(companyClient.CompanyId);
            if (company == null)
                throw new Exception("Компания не была найдена");
            _companyRepository.ChangeCompany(company, companyClient, userId);
            _context.SaveChanges();

            return company;
        }

        public Company ChangeCompanyStep(Company company, int stepId)
        {
            _companyRepository.ChangeCompanyStep(company, stepId);
            _context.SaveChanges();
            return company;
        }

        public IQueryable<Company> GetCompanies(CompanyFilter filter)
        {
            return _companyRepository.GetCompanies(filter);
        }

        public Company GetCompanyById(int companyId)
        {
            return _companyRepository.GetCompanyById(companyId);
        }
    }
}
