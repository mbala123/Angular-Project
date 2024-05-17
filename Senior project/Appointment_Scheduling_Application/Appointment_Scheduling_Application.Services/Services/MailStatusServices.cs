using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.Repositories;

namespace Appointment_Scheduling_Application.Services.Services
{
    public interface IMailStatusServices
    {
        Task<MailStatusModel> GetStatusById(int MailId);
        Task<bool> CreateandUpdateStatus(MailStatusModel mailStatus);
        Task<bool> DeleteStatus(MailStatusModel mailStatus);
    }
    public class MailStatusServices: IMailStatusServices
    {
        private readonly IMailStatusRepository _mailStatusRepository;
        public MailStatusServices(IMailStatusRepository mailStatusRepository)
        {
            _mailStatusRepository = mailStatusRepository;
        }
        public async Task<MailStatusModel> GetStatusById(int MailId)
        {
            return await _mailStatusRepository.GetStatusById(MailId);
        }
        public async Task<bool> CreateandUpdateStatus(MailStatusModel mailStatus)
        {
            if(mailStatus.Id !=0)
                return await _mailStatusRepository.UpdateStatus(mailStatus);
            return await _mailStatusRepository.CreateStatus(mailStatus);
        }
        public async Task<bool> DeleteStatus(MailStatusModel mailStatus)
        {
            return await _mailStatusRepository.DeleteStatus(mailStatus);
        }
    }
}
