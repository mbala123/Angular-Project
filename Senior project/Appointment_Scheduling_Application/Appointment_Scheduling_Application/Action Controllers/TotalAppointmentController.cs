using Appointment_Scheduling_Application.Entitie.Model;
using Appointment_Scheduling_Application.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_Scheduling_Application.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalAppointmentController : ControllerBase
    {
        private readonly ITotalAppointmentServices _totalAppointmentServices;
        public TotalAppointmentController(ITotalAppointmentServices totalAppointmentServices)
        {
            _totalAppointmentServices = totalAppointmentServices;
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<TotalAppointmentModel>>> GetById(int Id)
        {
            return Ok(await _totalAppointmentServices.GetById(Id));
        }
        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> CreateandUpdateTotalAppointment(TotalAppointmentModel totalAppointment)
        {
            if (totalAppointment != null)
            {
                return Ok(await _totalAppointmentServices.CreateandUpdateTotalAppointment(totalAppointment));
            }
            return BadRequest("Mission Incomplete");
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> DeleteTotalAppointment(TotalAppointmentModel totalAppointment)
        {
            if (totalAppointment != null)
            {
                return Ok(await _totalAppointmentServices.DeleteTotalAppointment(totalAppointment));
            }
            return BadRequest("Mission Incomplete");
        }
    }
}
