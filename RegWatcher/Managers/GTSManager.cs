using RegWatcher.Data;
using RegWatcher.Interfaces.IManagers;
using RegWatcher.Interfaces.IRepositories;
using RegWatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Managers
{
    public class GTSManager : IGTSManager
    {
        private readonly IGTSRepository _gtsRepository;
        private readonly DataContext _context;

        public GTSManager(DataContext context, IGTSRepository gtsRepository)
        {
            _gtsRepository = gtsRepository;
            _context = context;
        }

        public GTS Add(GTSModel gtsModel)
        {
            var gts = gtsModel.GetGTS();
            _gtsRepository.Add(gts);
            _context.SaveChanges();
            return gts;
        }

        public GTS Change(GTSModel gtsModel)
        {
            var gts = GetById(gtsModel.GTSId.Value);
            if (gts == null)
                throw new Exception("ГТС не найдена");
            var newGts = gtsModel.GetGTS();
            _gtsRepository.Change(gts, newGts);
            _context.SaveChanges();
            return gts;
        }

        public GTS GetById(int GTSId)
        {
            return _gtsRepository.GetById(GTSId);
        }
    }
}
