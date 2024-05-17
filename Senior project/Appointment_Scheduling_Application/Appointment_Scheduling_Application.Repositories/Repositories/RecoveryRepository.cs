using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Appointment_Scheduling_Application.Repositories.Repositories
{
    public interface IRecoveryRepository
    {
        Task<RecoveryModel> GetRecoveryById(int UserId);
        Task<bool> CreateRecovery(RecoveryModel recovery);
        Task<bool> DeleteRecovery(RecoveryModel recovery);
    }

    public class RecoveryRepository: IRecoveryRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public RecoveryRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<RecoveryModel> GetRecoveryById(int UserId)
        {
            return await _unitOfWork.GetEntities<RecoveryModel>().Where(x => x.UserId == UserId).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<bool> CreateRecovery(RecoveryModel recovery)
        {
            await _unitOfWork.AddAsync(recovery);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> DeleteRecovery(RecoveryModel recovery)
        {
            _unitOfWork.Remove(recovery);
            return await _unitOfWork.CommitAsync();
        }
    }
}
