using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.Base;
using Appointment_Scheduling_Application.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Appointment_Scheduling_Application.Repositories.Repositories
{
    public interface IUserRepository
    {
        Task<List<IdentityUser>> GetAllUser(); 
        Task<List<IdentityUser>> UserGetByName(string name);
        Task<IdentityUser> UserGetByEmail(string email);
        Task<bool> CreateUser(IdentityUser user);
        Task<bool> UpdateUser (IdentityUser user);
        Task<bool> DeleteUser (IdentityUser user);

    }
    public class UserRepository: IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<List<IdentityUser>> GetAllUser()
        {
            return await _unitOfWork.GetEntities<IdentityUser>().AsNoTracking().ToListAsync();
        }
        public async Task<List<IdentityUser>> UserGetByName(string name)
        {
            return await _unitOfWork.GetEntities<IdentityUser>().Where(x=>x.UserName==name).AsNoTracking().ToListAsync();   
        }
        public async Task<IdentityUser> UserGetByEmail(string email)
        {
            return await _unitOfWork.GetEntities<IdentityUser>().SingleOrDefaultAsync(x => x.Email == email);
        }
        public async Task<bool> CreateUser(IdentityUser user)
        {
            await _unitOfWork.AddAsync(user);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> UpdateUser(IdentityUser user)
        {
             _unitOfWork.Update(user);
            return await _unitOfWork.CommitAsync();
        }
        public async  Task<bool> DeleteUser(IdentityUser user)
        {
            _unitOfWork.Remove(user);
            return await _unitOfWork.CommitAsync();
        }
    }
}
