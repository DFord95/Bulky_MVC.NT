using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Utilities
{
    public class EmailSender 
    {
        public void send(string UserName, string Subject, string body)
        {
            //logic to send email
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("webmaster-noreply@dot.state.al.us"));
            email.To.Add(MailboxAddress.Parse(UserName));
            email.Subject = "Confirm Your Account";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();

            //Here i'm using smtp.ethereal to test, you can also use another SMTP server providers.  
            smtp.Connect("CSSENDMAIL.DOT.STATE.AL.US", 25, MailKit.Security.SecureSocketOptions.None);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
