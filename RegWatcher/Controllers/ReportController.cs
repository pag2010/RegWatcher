using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using RegWatcher.Filters;
using RegWatcher.Interfaces.IManagers;
using System.Web;
using Microsoft.Extensions.Hosting.Internal;

namespace RegWatcher.Controllers
{
    [Route("api/[controller]/[action]")]
    [ActionFilterValidation]
    public class ReportController : Controller
    {
        private readonly IReportManager _reportManager;
        public ReportController(IReportManager reportManager)
        {
            _reportManager = reportManager;
        }

        [Authorize(Roles = "Administrator,Specialist,HeadOfDepartment")]
        [HttpPost]
        public FileResult GetPeriodReport(DateTime startDate, DateTime endDate, [FromBody]IEnumerable<string> userIds)
        {
            var data = _reportManager.GetData(startDate, endDate, userIds).ToList();
            ExcelPackage excel = new ExcelPackage();

                var list = excel.Workbook.Worksheets.Add("Worksheet1");
                var i = 2;
                foreach (var d in data)
                {
                    foreach (var cr in d.CheckingResults)
                    {
                        list.Cells[i, 1].Value = d.User.Person.FirstName;
                        list.Cells[i, 2].Value = d.GTS.Name;
                        list.Cells[i, 3].Value = d.GTS.Company.Inn;
                        list.Cells[i, 4].Value = d.GTS.Company.FullName;
                        list.Cells[i, 5].Value = d.Reason;
                        list.Cells[i, 6].Value = d.CheckingKind.Name;
                        list.Cells[i, 7].Value = cr.ViolationCount;
                        list.Cells[i, 8].Value = cr.Fine;
                        list.Cells[i, 9].Value = cr.Prescription != null ? 1 : 0;
                        list.Cells[i, 10].Value = cr.Article;
                        i++;
                    }
                }
            
                FileInfo excelFile = new FileInfo(@"Отчёт.xlsx");
            excel.SaveAs(excelFile);
            return File("Отчёт.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Отчет.xlsx");
        }
    }
}