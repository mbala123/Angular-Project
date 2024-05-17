using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.Repositories;

namespace Appointment_Scheduling_Application.Services.Services
{
    public interface ITotalAppointmentServices
    {
        Task<List<TotalAppointmentModel>> GetById(int Id);
        Task<bool> CreateandUpdateTotalAppointment(TotalAppointmentModel totalAppointment);
        Task<bool> DeleteTotalAppointment(TotalAppointmentModel totalAppointment);
    }
    public class TotalAppointmentServices: ITotalAppointmentServices
    {
        private readonly ITotalAppointmentRepository _totalAppointmentRepository;
        public TotalAppointmentServices(ITotalAppointmentRepository totalAppointmentRepository)
        {
            _totalAppointmentRepository = totalAppointmentRepository;
        }
        public async Task<List<TotalAppointmentModel>> GetById(int Id)
        {
            return await _totalAppointmentRepository.GetById(Id);
        }
        public async Task<bool> CreateandUpdateTotalAppointment(TotalAppointmentModel totalAppointment)
        {
            if(totalAppointment.Id != 0)
                return await _totalAppointmentRepository.UpdateTotalAppointment(totalAppointment);
            return await _totalAppointmentRepository.CreateTotalAppointment(totalAppointment);
        }
        public async Task<bool> DeleteTotalAppointment(TotalAppointmentModel totalAppointment)
        {
            return await _totalAppointmentRepository.DeleteTotalAppointment(totalAppointment);
        }
    }
}
