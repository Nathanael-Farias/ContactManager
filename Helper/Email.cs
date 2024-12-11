using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AuthSystem.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Send(string email, string assunto, string message)
        {
        try
        {
            string host = _configuration.GetValue<string>("SMTP:Host");
            string name = _configuration.GetValue<string>("SMTP:Name");
            string username = _configuration.GetValue<string>("SMTP:UserName");
            string password = _configuration.GetValue<string>("SMTP:Password");
            int port = _configuration.GetValue<int>("SMTP:Port");

            MailMessage mail = new MailMessage
            {
             From = new MailAddress(username, name)
            };

            mail.To.Add(email);
            mail.Subject = "Subject";
            mail.Body = message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            using (SmtpClient smtp = new SmtpClient(host,port))
            {
                smtp.Credentials = new NetworkCredential(username,password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
        }
        catch (System.Exception ex)
        {
            return false;
            
        }



        }
    }
}