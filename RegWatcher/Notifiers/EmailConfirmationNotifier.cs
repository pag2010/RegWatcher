using RegWatcher.Data;
using RegWatcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using RegWatcher.Notifiers.Email;

namespace RegWatcher.Notifiers
{
    public class EmailConfirmationNotifier : INotifier
    {
        public void Notify(ApplicationUser user, string token, IEmailSender emailSender)
        {
            try
            {
                emailSender.SendEmailAsync(user.Email, "Подтверждение адреса электронной почты", token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
