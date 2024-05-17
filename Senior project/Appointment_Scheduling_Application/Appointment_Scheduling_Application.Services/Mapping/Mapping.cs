using Appointment_Scheduling_Application.DTOs.DTOs;
using Appointment_Scheduling_Application.Entitie.Model;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace Appointment_Scheduling_Application.Services.Mapping
{
    public interface IManualMapper
    {
        UserViewModel UserViewModelMapping(IdentityUser model, byte[] imagedata);
        IdentityUser UserCreateMapper(UserCreateModel model);
        IdentityUser UpdateCreateMapper(UserUpdateModel model);
        ProfileImageModel ProfileImageMapper(byte[] imageData,string email);
    }
    public class ManualMapper:IManualMapper
    {
        public IdentityUser UserCreateMapper(UserCreateModel model)
        {
            IdentityUser user =new IdentityUser()
            {
                Email=model.Email,
                UserName=model.FirstName + model.LastName,
                PhoneNumber=model.PhoneNumber,
            };
            return user;
        }
        public IdentityUser UpdateCreateMapper(UserUpdateModel model)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.FirstName + model.LastName,
                PhoneNumber = model.PhoneNumber,
                Id=model.Id
            };
            return user;
        }
        public UserViewModel UserViewModelMapping(IdentityUser model, byte[] imagedata)
        {
            UserViewModel user = new UserViewModel()
            {
                PhoneNumber=model.PhoneNumber,
                Email=model.Email,
                Name=model.UserName,
                Id=model.Id,
                image= Convert.ToBase64String(imagedata)
            };
            return user;
        }
        public ProfileImageModel ProfileImageMapper(byte[] imageData, string email)
        {
            ProfileImageModel profileImage = new ProfileImageModel()
            {
                Email=email,
                Image=imageData
            };
            return profileImage;
        }
    }
}
