using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using Bizis.Common.Diagnostics;

namespace Bizis.Site.Common.Services
{
    public class EmailService
    {
        private static bool _TrySendMail(string to, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = false;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("EmailService.__TrySendMail Error to:{0} subject:{1}", to, subject), ex, false);
                return false;
            }
        }

        internal static bool TrySend_ErrorReport(string errMsg)
        {
            return _TrySendMail("info@bizis.si", "Napaka - Site", errMsg); // TODO
        }

        internal static bool TrySend_Report(string subject, string html, string to)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.Subject = subject;
                message.Body = html;
                message.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("EmailService.TrySend_Report Error to:{0} subject:{1}", to, subject), ex, false);
                return false;
            }
        }
    }
}
