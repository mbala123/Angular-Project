using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.Repositories;

namespace Appointment_Scheduling_Application.Services.Services
{
    public interface IMailSendingServices
    {
        Task<List<MailSendingModel>> GetBySendingEmail(string email);
        Task<List<ToParticipant>> GetByToEmail(string email);
        Task<List<MailSendingModel>> GetByCcEmail(string email);
        Task<bool> CreateMail(MailSendingModel MailDetails, ToParticipant to);
    }
    public class MailSendingServices: IMailSendingServices
    {
        private readonly IMailSendingRepository _mailSendingRepository;
        public MailSendingServices(IMailSendingRepository mailSendingRepository)
        {
            _mailSendingRepository = mailSendingRepository;
        }
        public async Task<List<MailSendingModel>> GetBySendingEmail(string email)
        {
            return await _mailSendingRepository.GetBySendingEmail(email);
        }
        public async Task<List<ToParticipant>> GetByToEmail(string email)
        {
            return await _mailSendingRepository.GetByToEmail(email);
        }
        public async Task<List<MailSendingModel>> GetByCcEmail(string email)
        {
            return await _mailSendingRepository.GetByCcEmail(email);
        }
        public async Task<bool> CreateMail(MailSendingModel MailDetails, ToParticipant to)
        {
            return await _mailSendingRepository.CreateMail(MailDetails,to);    
        }
    }
}
