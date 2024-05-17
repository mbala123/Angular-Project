using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.Repositories;
using Appointment_Scheduling_Application.Services.Mapping;

namespace Appointment_Scheduling_Application.Services.Services
{
    public interface IProfileImageService
    {
        Task<ProfileImageModel> GetProfileImageModel(string email);
        Task<bool> UpdateProfileImageModel(IFormFile file,string email);
        Task<bool> CreateProfileImageModel(IFormFile file, string email);
        Task<bool> DeleteProfileImageModel(string email);
    }
    public class ProfileImageService: IProfileImageService
    {
        private readonly IProfileImageRepository _profileImageRepository;
        private readonly IManualMapper _manualMapper;
        public ProfileImageService(IProfileImageRepository profileImageRepository, IManualMapper manualMapper)
        {
            this._profileImageRepository = profileImageRepository;
            this._manualMapper= manualMapper;
        }
        public async Task<ProfileImageModel> GetProfileImageModel(string email)
        {
            return await _profileImageRepository.GetProfileImageModel(email);
        }
        public async Task<bool> UpdateProfileImageModel(IFormFile file, string email)
        {
            var checking = GetProfileImageModel(email);
            if(checking!=null)
            {
                var imagedata = ImageConverter(file);
                var data = _manualMapper.ProfileImageMapper(imagedata, email);
                data.Id=checking.Id;
                return await _profileImageRepository.UpdateProfileImageModel(data);
            }
            return false;

        }
        public async Task<bool> CreateProfileImageModel(IFormFile file, string email)
        {
            var imagedata = ImageConverter(file);
            var data = _manualMapper.ProfileImageMapper(imagedata, email);
            return await _profileImageRepository.CreateProfileImageModel(data);
        }
        public async Task<bool> DeleteProfileImageModel(string email)
        {
            var data=await GetProfileImageModel(email);
            return await _profileImageRepository.DeleteProfileImageModel(data);
        }
        private byte[] ImageConverter(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }


            }
            else
                return null;
        }
    }
}
