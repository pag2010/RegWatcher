using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        IQueryable<ApplicationUser> GetPagedUsers(int page, int countPerPage);
    }
}
