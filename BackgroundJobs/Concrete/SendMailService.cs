using BackgroundJobs.Abstract;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;


namespace BackgroundJobs.Concrete
{
    public class SendMailService : ISendMailService
    {
        public void SendPasswordInfoMail(string Firstname, string email, string password)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Melek Doğan", "forprojectmd@outlook.com"));
            mailMessage.To.Add(new MailboxAddress(Firstname, email));
            mailMessage.Subject = "Password Information";
            mailMessage.Body = new TextPart("plain")
            {
                Text = $"Hello {Firstname}! \n Your password here: {password}"
            };
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.office365.com", 587,SecureSocketOptions.StartTls);
                smtpClient.Authenticate("forprojectmd@outlook.com", "78m93o74a25m");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}

