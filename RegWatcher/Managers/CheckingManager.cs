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
    public class CheckingManager : ICheckingManager
    {
        private readonly DataContext _context;
        private readonly ICheckingRepository _checkingRepository;

        public CheckingManager(DataContext context, ICheckingRepository checkingRepository)
        {
            _context = context;
            _checkingRepository = checkingRepository;
        }

        public Checking Add(CheckingModel checkingModel)
        {
            var checking = checkingModel.GetChecking();
            _checkingRepository.Add(checking);
            _context.SaveChanges();
            return checking;
        }

        public Checking Change(CheckingModel checkingModel)
        {
            throw new NotImplementedException();
        }

        public Checking GetById(int checkingId)
        {
            return _checkingRepository.GetById(checkingId);
        }

        public IQueryable<Checking> GetFiltered(CheckingFilter filter)
        {
            var query = from checking in _context.Checkings
                        where (!filter.EndDate.HasValue || filter.EndDate >= checking.CheckingDate)
                        && (!filter.StartDate.HasValue || filter.StartDate <= checking.CheckingDate)
                        && (filter.Number == null || checking.Number.ToLower().Contains(filter.Number.ToLower()))
                        && (filter.Reason == null || checking.Reason.ToLower().Contains(filter.Reason.ToLower()))
                        && (filter.UserName == null || checking.User.Person.FirstName.ToLower().Contains(filter.UserName.ToLower())
                        || checking.User.Person.SecondName.ToLower().Contains(filter.UserName.ToLower()))
                        && (!filter.StepId.HasValue || checking.StepId == filter.StepId)
                        select checking;
            return query;
        }
    }
}
