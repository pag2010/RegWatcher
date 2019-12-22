using RegWatcher.Data;
using RegWatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IManagers
{
    public interface ICompanyManager
    {
        Company AddCompany(CompanyModel company, string userId);
        IQueryable<Company> GetCompanies(CompanyFilter filter);
        Company ChangeCompany(CompanyModel company, string userId);
        Company GetCompanyById(int companyId);
        Company ChangeCompanyStep(Company company, int stepId);
    }
}
