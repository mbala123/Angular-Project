using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;
namespace Appointment_Scheduling_Application.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentServices _appointmentServices;
        public AppointmentController(IAppointmentServices appointmentServices)
        {
            this._appointmentServices = appointmentServices;
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<AppointmentModel>>> GetByEmail(int UserId)
        {
            if (UserId != 0)
            {
                return Ok(await _appointmentServices.GetByEmail(UserId));
            }
            return BadRequest("Mission Incomplete");
        }
        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> CreateandUpdateAppointment(AppointmentModel appointment)
        {
            if (appointment != null)
            {
                return Ok(await _appointmentServices.CreateandUpdateAppointment(appointment));
            }
            return BadRequest("Mission Incomplete");
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> DeleteAppointment(AppointmentModel appointment)
        {
            if (appointment != null)
            {
                return Ok(await _appointmentServices.DeleteAppointment(appointment));
            }
            return BadRequest("Mission Incomplete");
        }
    }
}
