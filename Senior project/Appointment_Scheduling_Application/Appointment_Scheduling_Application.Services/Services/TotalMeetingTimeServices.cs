using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.Repositories;

namespace Appointment_Scheduling_Application.Services.Services
{
    public interface ITotalMeetingTimeServices
    {
         Task<List<TotalMeetingTimeModel>> GetById(int Id);
        Task<bool> CreateandUpdateTotaltime(TotalMeetingTimeModel meetingTime);
        Task<bool> DeleteTotaltime(TotalMeetingTimeModel meetingTime);
    }
    public class TotalMeetingTimeServices: ITotalMeetingTimeServices
    {
        private readonly ITotalMeetingTimeRepository _totalMeetingTimeRepository;
        public TotalMeetingTimeServices(ITotalMeetingTimeRepository totalMeetingTimeRepository)
        {
            this._totalMeetingTimeRepository = totalMeetingTimeRepository;
        }
        public async Task<List<TotalMeetingTimeModel>> GetById(int Id)
        {
            return await _totalMeetingTimeRepository.GetById(Id);
        }

        public async Task<bool> CreateandUpdateTotaltime(TotalMeetingTimeModel meetingTime)
        {
            if(meetingTime.Id != 0) 
                return await _totalMeetingTimeRepository.UpdateTotaltime(meetingTime);
            return await _totalMeetingTimeRepository.CreateTotaltime(meetingTime);
        }

        public async Task<bool> DeleteTotaltime(TotalMeetingTimeModel meetingTime)
        {
            return await _totalMeetingTimeRepository.DeleteTotaltime(meetingTime);
        }
    }   
}
