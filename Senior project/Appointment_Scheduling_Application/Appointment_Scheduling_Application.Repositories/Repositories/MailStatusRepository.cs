using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Appointment_Scheduling_Application.Repositories.Repositories
{
    public interface IMailStatusRepository
    {
        Task<MailStatusModel> GetStatusById(int MailId);
        Task<bool> CreateStatus(MailStatusModel mailStatus);
        Task<bool> UpdateStatus(MailStatusModel mailStatus);
        Task<bool> DeleteStatus(MailStatusModel mailStatus);
    }
    public class MailStatusRepository: IMailStatusRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public MailStatusRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<MailStatusModel> GetStatusById(int MailId)
        {
            return await _unitOfWork.GetEntities<MailStatusModel>().Where(x => x.MailId == MailId).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<bool> CreateStatus(MailStatusModel mailStatus)
        {
            await _unitOfWork.AddAsync(mailStatus);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> UpdateStatus(MailStatusModel mailStatus)
        {
            _unitOfWork.Update(mailStatus);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> DeleteStatus(MailStatusModel mailStatus)
        {
            _unitOfWork.Remove(mailStatus);
            return await _unitOfWork.CommitAsync();
        }
    }
}
