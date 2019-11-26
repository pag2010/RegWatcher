using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string mailto, string subject, string message, string attachFile = null);
    }
}
