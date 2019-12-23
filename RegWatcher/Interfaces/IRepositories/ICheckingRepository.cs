using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IRepositories
{
    public interface ICheckingRepository
    {
        void Add(Checking checking);
        Checking GetById(int checkingId);
        void Change(Checking oldChecking, Checking newChecking);
    }
}
