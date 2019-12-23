using RegWatcher.Data;
using RegWatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IManagers
{
    public interface ICheckingManager
    {
        Checking GetById(int checkingId);
        Checking Change(CheckingModel checkingModel);
        Checking Add(CheckingModel checkingModel);

        IQueryable<Checking> GetFiltered(CheckingFilter filter);
    }
}
