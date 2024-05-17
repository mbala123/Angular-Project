using Appointment_Scheduling_Application.DTOs.DTOs;
using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Repositories.Repositories;
using Appointment_Scheduling_Application.Services.Mapping;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Appointment_Scheduling_Application.Services.Services
{
    public interface IUserServices
    {
        Task<List<UserViewModel>> GetAllUser();
        Task<List<UserViewModel>> UserGetByName(string name);
        Task<UserViewModel> UserGetByEmail(string email);
        Task<bool> UpdateUser(UserUpdateModel user);
        Task<bool> CreateUser(UserCreateModel user);
        Task<bool> DeleteUser(string Email);
        Task<bool> SignOut();
        Task<bool> SignIn(string Email, string Password);

    }
    public class UserServices: IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IManualMapper _mapping;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IProfileImageService _profileImageService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserServices(IUserRepository userRepository, IManualMapper mapping, UserManager<IdentityUser> userManager, IProfileImageService profileImageService, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._userRepository = userRepository;
            this._mapping = mapping;
            this._userManager = userManager;
            this._profileImageService = profileImageService;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }
        public async Task<List<UserViewModel>> GetAllUser()
        {
            var userList= await _userRepository.GetAllUser();
            var userViewModelList=new List<UserViewModel>();
            for(int i=0;i<userList.Count;i++)
            {
                var imagedata = await _profileImageService.GetProfileImageModel(userList[i].Email);
                var userViewModel = _mapping.UserViewModelMapping(userList[i],imagedata.Image);
                userViewModelList.Add(userViewModel);
            }
           return userViewModelList;
        }
        public async Task<List<UserViewModel>> UserGetByName(string name)
        {
            var userList = await _userRepository.UserGetByName(name);
            var userViewModelList = new List<UserViewModel>();
            for (int i = 0; i < userList.Count; i++)
            {
                var imagedata = await _profileImageService.GetProfileImageModel(userList[i].Email);
                var userViewModel = _mapping.UserViewModelMapping(userList[i], imagedata.Image);
                userViewModelList.Add(userViewModel);
            }
            return userViewModelList;
        }
        public async Task<UserViewModel> UserGetByEmail(string email)
        {
            var imagedata = await _profileImageService.GetProfileImageModel(email);
            var user = await _userRepository.UserGetByEmail(email);
            var userViewModel = _mapping.UserViewModelMapping(user, imagedata.Image);
            return userViewModel;
        }
        public async Task<bool> CreateUser(UserCreateModel user)
        {
            await _profileImageService.CreateProfileImageModel(user.file,user.Email);
            var role = new IdentityRole { Name = "Member" };
            var roleResult=await _roleManager.CreateAsync(role);
            var data=_mapping.UserCreateMapper(user);
            var data1=await _userManager.CreateAsync(data,user.Password);
            var data2 = await _userManager.AddToRoleAsync(data, "Member");
            return true;
        }
        public async Task<bool> UpdateUser(UserUpdateModel user)
        {
            if (await UserGetByEmail(user.Email) != null)
            {
                await _profileImageService.UpdateProfileImageModel(user.file, user.Email);
                var data =_mapping.UpdateCreateMapper(user);
                return await _userRepository.UpdateUser(data);
            }
            return false;
        }
        public async Task<bool> DeleteUser(string Email)
        {
            var userData = await _userRepository.UserGetByEmail(Email);
            return await _userRepository.DeleteUser(userData);
        }
        public async Task<bool> SignOut()
        {
            await _signInManager.SignOutAsync();
            return true;
        }
        public async Task<bool> SignIn(string Email,string Password)
        {
            //var result = await _signInManager.PasswordSignInAsync(Email, Password, false, false);  result.Succeeded
            if (true)
            {
                var user=await _userManager.FindByEmailAsync(Email);
                if(await _userManager.IsInRoleAsync(user, "Member"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
