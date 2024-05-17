using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Appointment_Scheduling_Application.Repositories.Repositories
{
    public interface IHelpMessageRepository
    {
        Task<List<HelpMessageModel>> GetAllHelpMessages();
        Task<HelpMessageModel> GetById(int UserId);
        Task<bool> CreateHelpMessage(HelpMessageModel helpMessage);
        Task<bool> UpdateHelpMessage(HelpMessageModel helpMessage);
    }
    public class HelpMessageRepository: IHelpMessageRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public HelpMessageRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<List<HelpMessageModel>> GetAllHelpMessages()
        {
            return await _unitOfWork.GetEntities<HelpMessageModel>().AsNoTracking().ToListAsync();
        }
        public async Task<HelpMessageModel> GetById(int UserId)
        {
            return await _unitOfWork.GetEntities<HelpMessageModel>().Where(x => x.UserId == UserId).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<bool> CreateHelpMessage(HelpMessageModel helpMessage)
        {
            await _unitOfWork.AddAsync(helpMessage);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> UpdateHelpMessage(HelpMessageModel helpMessage)
        {
            _unitOfWork.Update(helpMessage);
            return await _unitOfWork.CommitAsync();
        }
    }
}
