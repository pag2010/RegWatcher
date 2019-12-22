using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegWatcher.Data;
using RegWatcher.Filters;
using RegWatcher.Interfaces.IManagers;
using RegWatcher.Models.ViewModels;

namespace RegWatcher.Controllers
{
    [Route("api/[controller]/[action]")]
    [ActionFilterValidation]
    public class CompanyController : Controller
    {
        private readonly ICompanyManager _companyManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public CompanyController(ICompanyManager companyManager, UserManager<ApplicationUser> userManager)
        {
            _companyManager = companyManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Specialist,HeadOfDepartment,Inspector")]
        public async Task<Company> CreateCompany([FromBody]CompanyModel companyClient)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    throw new Exception("Невозможно определить пользователя. Перезайдите в систему");
                var company = _companyManager.AddCompany(companyClient, user.Id);
                return company;
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось добавить компанию из-за ошибки {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Specialist,HeadOfDepartment,Inspector")]
        public IEnumerable<CompanyModel> FindCompanies(CompanyFilter filter, [Required]int page, int countPerPage = 10)
        {
            try
            {
                var companies = _companyManager.GetCompanies(filter)
                    .Skip((page-1)*countPerPage)
                    .Take(countPerPage)
                    .Select(c=>new CompanyModel(c, c.Person))
                    .ToList();
                return companies;
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось найти компанию из - за ошибки { ex.Message }");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Specialist,HeadOfDepartment,Inspector")]
        public async Task<CompanyModel> ChangeCompany([FromBody]CompanyModel companyClient)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    throw new Exception("Невозможно определить пользователя. Перезайдите в систему");
                var company = _companyManager.ChangeCompany(companyClient, user.Id);
                return new CompanyModel(company, company.Person);
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось изменить компанию из - за ошибки { ex.Message }");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,Specialist,HeadOfDepartment,Inspector")]
        public CompanyModel GetCompanyById(int companyId)
        {
            try
            {
                var company = _companyManager.GetCompanyById(companyId);
                if (company == null)
                    throw new Exception("Компания не найдена");
                return new CompanyModel(company, company.Person);
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось найти компанию из - за ошибки { ex.Message }");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,Specialist,HeadOfDepartment,Inspector")]
        public CompanyModel ChangeCompanyStep(int companyId, int stepId)
        {
            try
            {
                var company = _companyManager.GetCompanyById(companyId);
                if (company == null)
                    throw new Exception("Компания не найдена");
                _companyManager.ChangeCompanyStep(company, stepId);
                return new CompanyModel(company, company.Person);
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось найти компанию из - за ошибки { ex.Message }");
            }
        }
    }
}