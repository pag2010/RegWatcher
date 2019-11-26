using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces
{
    public interface INotifier
    {
        void Notify(ApplicationUser user, string message, IEmailSender emailSender);
    }
}
