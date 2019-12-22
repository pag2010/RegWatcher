using RegWatcher.Data;
using RegWatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IRepositories
{
    public interface ICompanyRepository
    {
        void AddCompany(Company company);
        IQueryable<Company> GetCompanies(CompanyFilter filter);
        Company GetCompanyById(int companyId);
        void ChangeCompany(Company company, Company newCompany, string userId);
        void ChangeCompanyStep(Company company, int stepId);
    }
}
