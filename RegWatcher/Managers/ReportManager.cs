using RegWatcher.Data;
using RegWatcher.Interfaces.IManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Managers
{
    public class ReportManager : IReportManager
    {
        private readonly DataContext _context;
        
        public ReportManager(DataContext context)
        {
            _context = context;
        }

        public IQueryable<Checking> GetData(DateTime startDate, DateTime endDate, IEnumerable<string> userIds)
        {
            var query = from checking in _context.Checkings
                        where checking.CloseDate >= startDate
                        && checking.CloseDate <= endDate
                        && userIds.Contains(checking.UserId)
                        select checking;
            return query;
        }
    }
}
