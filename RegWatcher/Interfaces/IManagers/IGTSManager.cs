using RegWatcher.Data;
using RegWatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IManagers
{
    public interface IGTSManager
    {
        GTS GetById(int GTSId);
        GTS Change(GTSModel gts);
        GTS Add(GTSModel gts);
    }
}
