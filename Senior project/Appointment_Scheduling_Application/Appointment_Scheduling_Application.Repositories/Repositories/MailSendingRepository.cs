using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Appointment_Scheduling_Application.Repositories.Repositories
{
    public interface IMailSendingRepository
    {
        Task<List<MailSendingModel>> GetBySendingEmail(string email);
        Task<List<ToParticipant>> GetByToEmail(string email);
        Task<List<MailSendingModel>> GetByCcEmail(string email);
        Task<bool> CreateMail(MailSendingModel MailDetails,ToParticipant to);
    }
    public class MailSendingRepository: IMailSendingRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public MailSendingRepository(IUnitOfWork unitOfWork) 
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<List<MailSendingModel>> GetBySendingEmail(string email)
        {
            return await _unitOfWork.GetEntities<MailSendingModel>().Where(x => x.From == email).Include(x=>x.ToParticipant).AsNoTracking().ToListAsync();
        }
        public async Task<List<ToParticipant>> GetByToEmail(string email)
        {
            return await _unitOfWork.GetEntities<ToParticipant>().Where(x => x.To == email).AsNoTracking().ToListAsync();
        }
        public async Task<List<MailSendingModel>> GetByCcEmail(string email)
        {
            return await _unitOfWork.GetEntities<MailSendingModel>().Where(x => x.CC == email).Include(x => x.ToParticipant).AsNoTracking().ToListAsync();
        }
        public async Task<bool> CreateMail(MailSendingModel MailDetails, ToParticipant to)
        {
            await _unitOfWork.AddAsync(MailDetails);
            await _unitOfWork.CommitAsync();
            await _unitOfWork.AddRangeAsync(to);
            return await _unitOfWork.CommitAsync();
        }
    }
}
