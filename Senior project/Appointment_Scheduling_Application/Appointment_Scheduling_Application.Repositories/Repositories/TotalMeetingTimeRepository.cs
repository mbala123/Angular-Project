using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Appointment_Scheduling_Application.Repositories.Repositories
{
    public interface ITotalMeetingTimeRepository
    {
        Task<List<TotalMeetingTimeModel>> GetById(int Id);
        Task<bool> CreateTotaltime(TotalMeetingTimeModel meetingTime);
        Task<bool> UpdateTotaltime(TotalMeetingTimeModel meetingTime);
        Task<bool> DeleteTotaltime(TotalMeetingTimeModel meetingTime);
    }
    public class TotalMeetingTimeRepository: ITotalMeetingTimeRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public TotalMeetingTimeRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<List<TotalMeetingTimeModel>> GetById(int Id)
        {
            return await _unitOfWork.GetEntities<TotalMeetingTimeModel>().Where(x => x.Userid == Id).AsNoTracking().ToListAsync();
        }
        public async Task<bool> CreateTotaltime(TotalMeetingTimeModel meetingTime)
        {
            await _unitOfWork.AddAsync(meetingTime);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> UpdateTotaltime(TotalMeetingTimeModel meetingTime)
        {
            _unitOfWork.Update(meetingTime);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> DeleteTotaltime(TotalMeetingTimeModel meetingTime)
        {
            _unitOfWork.Remove(meetingTime);
            return await _unitOfWork.CommitAsync();
        }
    }
}
