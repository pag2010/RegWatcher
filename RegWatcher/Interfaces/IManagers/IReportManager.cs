using RegWatcher.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RegWatcher.Interfaces.IManagers
{
    public interface IReportManager
    {
        IQueryable<Checking> GetData(DateTime startDate, DateTime EndDate, IEnumerable<string> userIds);
    }
}