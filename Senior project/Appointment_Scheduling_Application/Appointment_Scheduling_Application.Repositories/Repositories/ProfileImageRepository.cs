using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Appointment_Scheduling_Application.Repositories.Repositories
{
    public interface IProfileImageRepository
    {
        Task<ProfileImageModel> GetProfileImageModel(string email);
        Task<bool> UpdateProfileImageModel(ProfileImageModel model);
        Task<bool> CreateProfileImageModel(ProfileImageModel model);
        Task<bool> DeleteProfileImageModel (ProfileImageModel model);
    }
    public class ProfileImageRepository:IProfileImageRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProfileImageRepository(IUnitOfWork unitOfWork) 
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<ProfileImageModel> GetProfileImageModel(string email)
        {
            return await _unitOfWork.GetEntities<ProfileImageModel>().SingleOrDefaultAsync(x=>x.Email==email);
        }
        public async Task<bool> UpdateProfileImageModel(ProfileImageModel model)
        {
            _unitOfWork.Update(model);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> CreateProfileImageModel(ProfileImageModel model)
        {
            await _unitOfWork.AddAsync(model);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> DeleteProfileImageModel(ProfileImageModel model)
        {
            _unitOfWork.Remove(model);
            return await _unitOfWork.CommitAsync();
        }

    }
}
