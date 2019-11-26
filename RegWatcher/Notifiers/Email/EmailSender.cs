using RegWatcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RegWatcher.Notifiers.Email
{
    public class EmailSender : IEmailSender
    {
        private MailAddress _from = new MailAddress("iregwatcher@gmail.com", "RegWatcher");
        private NetworkCredential _creditals = new NetworkCredential("iregwatcher", "q135790!");
        private string _smtpServer = "smtp.gmail.com";

        public EmailSender(string smtpServer, string fromEmail, string fromName, string password)
        {
            this._from = new MailAddress(fromEmail, fromName);
            this._creditals = new NetworkCredential(fromEmail, password);
        }

        public EmailSender()
        {

        }

        public void SendMail(string smtpServer, string from, string password,
                                    string mailto, string caption, string message, 
                                    string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

        public async Task SendEmailAsync(string mailto, string subject, string message,
                                    string attachFile = null)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = _from;
                    mail.To.Add(new MailAddress(mailto));
                    mail.Subject = subject;
                    mail.Body = message;
                    if (!string.IsNullOrEmpty(attachFile))
                        mail.Attachments.Add(new Attachment(attachFile));
                    SmtpClient client = new SmtpClient();
                    client.Host = _smtpServer;
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = _creditals;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mail);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }
    }
}
