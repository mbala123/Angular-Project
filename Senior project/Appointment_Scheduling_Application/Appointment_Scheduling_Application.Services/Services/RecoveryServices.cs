using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.Repositories;

namespace Appointment_Scheduling_Application.Services.Services
{
    public interface IRecoveryServices
    {
        Task<RecoveryModel> GetRecoveryById(int UserId);
        Task<bool> CreateRecovery(RecoveryModel recovery);
        Task<bool> DeleteRecovery(RecoveryModel recovery);
    }
    public class RecoveryServices: IRecoveryServices
    {
        private readonly IRecoveryRepository _recoveryRepository;
        public RecoveryServices(IRecoveryRepository recoveryRepository)
        {
            _recoveryRepository = recoveryRepository;
        }
        public async Task<RecoveryModel> GetRecoveryById(int UserId)
        {
            return await _recoveryRepository.GetRecoveryById(UserId);
        }
        public async Task<bool> CreateRecovery(RecoveryModel recovery)
        {
            return await _recoveryRepository.CreateRecovery(recovery);
        }
        public async Task<bool> DeleteRecovery(RecoveryModel recovery)
        {
            return await _recoveryRepository.DeleteRecovery(recovery);
        }
    }
}
