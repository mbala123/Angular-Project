using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Appointment_Scheduling_Application.Repositories.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<AppointmentModel>> GetByEmail(int UserId);
        Task<bool> CreateAppointment(AppointmentModel appointment);
        Task<bool> UpdateAppointment(AppointmentModel appointment);
        Task<bool> DeleteAppointment(AppointmentModel appointment);
    }
    public class AppointmentRepository: IAppointmentRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<List<AppointmentModel>> GetByEmail(int UserId)
        {
            return await _unitOfWork.GetEntities<AppointmentModel>().Where(x => x.Id == UserId).ToListAsync();
        }
        public async Task<bool> CreateAppointment(AppointmentModel appointment)
        {
            await _unitOfWork.AddAsync(appointment);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> UpdateAppointment(AppointmentModel appointment)
        {
            _unitOfWork.Update(appointment);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> DeleteAppointment(AppointmentModel appointment)
        {
            _unitOfWork.Remove(appointment);
            return await _unitOfWork.CommitAsync();
        }

    }
}
