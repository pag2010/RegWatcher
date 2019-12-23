using RegWatcher.Data;
using RegWatcher.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Repositories
{
    public class CheckingRepository : ICheckingRepository
    {
        private readonly DataContext _context;

        public CheckingRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Checking checking)
        {
            _context.Add(checking);
        }

        public void Change(Checking oldChecking, Checking newChecking)
        {
            oldChecking.CheckingDate = newChecking.CheckingDate;
            oldChecking.CheckingKindId = newChecking.CheckingKindId;
            oldChecking.DocumentReasonId = newChecking.DocumentReasonId;
            oldChecking.GTSId = newChecking.GTSId;
            oldChecking.Number = newChecking.Number;
            oldChecking.StepId = newChecking.StepId;
            oldChecking.UserId = newChecking.UserId;
        }

        public Checking GetById(int checkingId)
        {
            return _context.Checkings.Where(c=>c.CheckingId == checkingId).SingleOrDefault();
        }
    }
}
