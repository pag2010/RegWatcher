using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IRepositories
{
    public interface IGTSRepository
    {
        GTS GetById(int GTSId);
        void Change(GTS oldGts, GTS newGts);
        void Add(GTS gts);
    }
}
