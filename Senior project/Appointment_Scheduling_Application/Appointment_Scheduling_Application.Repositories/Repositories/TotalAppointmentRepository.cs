using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Appointment_Scheduling_Application.Repositories.Repositories
{
    public interface ITotalAppointmentRepository
    {
        Task<List<TotalAppointmentModel>> GetById(int Id);
        Task<bool> CreateTotalAppointment(TotalAppointmentModel totalAppointment);
        Task<bool> UpdateTotalAppointment(TotalAppointmentModel totalAppointment);
        Task<bool> DeleteTotalAppointment(TotalAppointmentModel totalAppointment);
    }
    public class TotalAppointmentRepository: ITotalAppointmentRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public TotalAppointmentRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<List<TotalAppointmentModel>> GetById(int Id)
        {
            return await _unitOfWork.GetEntities<TotalAppointmentModel>().Where(x => x.Userid == Id).AsNoTracking().ToListAsync();
        }
        public async Task<bool> CreateTotalAppointment(TotalAppointmentModel totalAppointment)
        {
            await _unitOfWork.AddAsync(totalAppointment);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> UpdateTotalAppointment(TotalAppointmentModel totalAppointment)
        {
            _unitOfWork.Update(totalAppointment);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> DeleteTotalAppointment(TotalAppointmentModel totalAppointment)
        {
            _unitOfWork.Remove(totalAppointment);
            return await _unitOfWork.CommitAsync();
        }
    }
}
