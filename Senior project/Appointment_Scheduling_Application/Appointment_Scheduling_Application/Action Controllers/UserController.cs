using Appointment_Scheduling_Application.DTO.DTOs;
using Appointment_Scheduling_Application.DTOs.DTOs;
using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_Scheduling_Application.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            this._userServices = userServices;
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> GetAllUser()
        {
            return Ok(await _userServices.GetAllUser());
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UserGetByName(string name)
        {
            if(name != null)
            {
                return Ok(await _userServices.UserGetByName(name));
            }
            return BadRequest("Mission Incomplete");
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UserGetByEmail(string email)
        {
            if (email != null)
            {
                return Ok(await _userServices.UserGetByEmail(email));
            }
            return BadRequest("Mission Incomplete");
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<bool>> CreateUser([FromForm] UserCreateModel user)
        {
            if(user !=null)
            {
                return Ok(await _userServices.CreateUser(user));
            }
            return BadRequest(false);
        }
        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> UpdateUser([FromForm] UserUpdateModel user)
        {
            if (user != null)
            {
                return Ok(await _userServices.UpdateUser(user));
            }
            return BadRequest(false);
        }
        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> DeleteUser(string Email)
        {
            if(Email != null)
            {
                return Ok(await _userServices.DeleteUser(Email));
            }
            return BadRequest(false);
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<bool> SignOut()
        {
            return await _userServices.SignOut();
        }
        
        [HttpPost("[action]")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<bool> SignIn([FromForm] LoginModel loginModel)
        {
                return await _userServices.SignIn(loginModel.Email, loginModel.Password);
        }

    }
}
