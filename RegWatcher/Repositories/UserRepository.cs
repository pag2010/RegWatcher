using RegWatcher.Data;
using RegWatcher.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<ApplicationUser> GetPagedUsers(int page, int countPerPage)
        {
            return _context.ApplicationUsers
               .Skip(page * countPerPage)
               .Take(countPerPage);
        }
    }
}
