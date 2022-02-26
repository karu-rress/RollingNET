#nullable enable

using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RollingRess
{
    public class MailSender
    {
        private string from = string.Empty;
        public string From
        {
            get => from;
            set => from = value.Contains("@gmail.com") ? value : throw new ArgumentException("Only Gmail is allowed.");
        }
        public string To { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public MailSender() { }
        public MailSender(string from, string to)
        {
            From = from;
            To = to;
        }
        public MailSender(string from, string to, string pw) : this(from, to)
        {
            Password = pw;
        }

        public async Task<bool> Send()
        {
            MailAddress send = new(From);
            MailAddress to = new(To);
            using SmtpClient smtp = new()
            {
                Host = "smtp.gmail.com",
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(send.Address, Password),
                Timeout = 20_000
            };
            using MailMessage msg = new(send, to)
            {
                Subject = Subject,
                Body = Body
            };

            try
            {
                await smtp.SendMailAsync(msg);
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
