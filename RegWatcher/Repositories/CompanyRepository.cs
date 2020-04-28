using RegWatcher.Data;
using RegWatcher.Data.Enums;
using RegWatcher.Interfaces.IRepositories;
using RegWatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;
        public CompanyRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCompany(Company company)
        {
            _context.Companies.Add(company);
        }

        public void ChangeCompany(Company company, Company newCompany, string userId)
        {
            company.Address = newCompany.Address;
            company.BusinessSubject = newCompany.BusinessSubject;
            company.Comment = newCompany.Comment;
            company.FormKindId = newCompany.FormKindId;
            company.FullName = newCompany.FullName;
            company.Inn = newCompany.Inn;
            company.Kpp = newCompany.Kpp;
            company.Ogrn = newCompany.Ogrn;
            company.PersonId = newCompany.PersonId;
            company.ShortName = newCompany.ShortName;
            company.UpdateTime = DateTime.Now;
            company.UserId = userId;
        }

        public void ChangeCompanyStep(Company company, int stepId)
        {
            company.StepId = (Steps)stepId;
        }

        public IQueryable<Company> GetCompanies(CompanyFilter filter)
        {
            var query = from company in _context.Companies
                        where filter.Address == null || company.Address.ToLower().Contains(filter.Address.ToLower())
                        && (filter.BusinessSubject == null || company.BusinessSubject.ToLower()
                            .Contains(filter.BusinessSubject.ToLower()))
                        && (!filter.FormKindId.HasValue || company.FormKindId == filter.FormKindId)
                        && (filter.Inn == null || company.Inn.Contains(filter.Inn))
                        && (filter.Kpp == null || company.Kpp.Contains(filter.Kpp))
                        && (filter.Name == null || company.FullName.ToLower().Contains(filter.Name)
                            || company.ShortName.ToLower().Contains(filter.Name.ToLower()))
                        && (filter.Ogrn == null || company.Ogrn.Contains(filter.Ogrn))
                        orderby company.Inn
                        select company;
            return query;
        }

        public Company GetCompanyById(int companyId)
        {
            return _context.Companies.Where(c => c.CompanyId == companyId).SingleOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
