using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.Repositories;

namespace Appointment_Scheduling_Application.Services.Services
{
    public interface IAppointmentServices
    {
        Task<List<AppointmentModel>> GetByEmail(int UserId);
        Task<bool> CreateandUpdateAppointment(AppointmentModel appointment);
        Task<bool> DeleteAppointment(AppointmentModel appointment);
    }
    public class AppointmentServices: IAppointmentServices
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentServices(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<List<AppointmentModel>> GetByEmail(int UserId)
        {
            return await _appointmentRepository.GetByEmail(UserId);
        }
        public async Task<bool> CreateandUpdateAppointment(AppointmentModel appointment)
        {
            if(appointment.Id !=0)
                return await _appointmentRepository.UpdateAppointment(appointment);
            return await _appointmentRepository.CreateAppointment(appointment);
        }
        public async Task<bool> DeleteAppointment(AppointmentModel appointment)
        {
            return await _appointmentRepository.DeleteAppointment(appointment);
        }
    }

}
