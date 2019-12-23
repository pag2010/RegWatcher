using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegWatcher.Data;
using RegWatcher.Interfaces.IRepositories;

namespace RegWatcher.Repositories
{
    public class GTSRepository : IGTSRepository
    {
        private DataContext _context;

        public GTSRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(GTS gts)
        {
            _context.GTSs.Add(gts); 

        }

        public void Change(GTS oldGts, GTS newGts)
        {
            oldGts.CompanyId = newGts.CompanyId;
            oldGts.DangerKindId = newGts.DangerKindId;
            oldGts.Name = newGts.Name;
            oldGts.Purpose = newGts.Purpose;
        }

        public GTS GetById(int GTSId)
        {
            return _context.GTSs.Where(gts=>gts.GTSId == GTSId).SingleOrDefault();
        }
    }
}
