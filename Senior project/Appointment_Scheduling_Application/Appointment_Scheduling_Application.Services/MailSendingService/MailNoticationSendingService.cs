using Appointment_Scheduling_Application.Entitie.Model;
using System.Net.Mail;
using System.Net;
using static System.Net.WebRequestMethods;

namespace Appointment_Scheduling_Application.Services.MailSendingService
{
    public interface IMailNoticationSendingService
    {
        Task<string> Sendingmail(string email, string message,string subject);
    }
    public class MailNoticationSendingService: IMailNoticationSendingService
    {
        public async Task<string> Sendingmail(string email,string message, string subject)
        {
            return await MailGenerator(email,message,subject);
        }
        private async Task<string> MailGenerator(string email, string message, string subject)
        {
            
            string ToEmail = email;

            var FromEmail = ConstantValues.ConstantValues.FromEmailId;

            var password = ConstantValues.ConstantValues.Emailpassword;

            var client = new SmtpClient("smtp.gmail.com", 587);

            client.EnableSsl = true;

            client.UseDefaultCredentials = false;

            client.Credentials = new NetworkCredential(FromEmail, password);

            var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(FromEmail);

            mailMessage.To.Add(ToEmail);
                mailMessage.Subject =subject;
                mailMessage.Body =message ;

                client.Send(mailMessage);
                return ConstantValues.ConstantValues.successMailMessage;
        }
    }
}
