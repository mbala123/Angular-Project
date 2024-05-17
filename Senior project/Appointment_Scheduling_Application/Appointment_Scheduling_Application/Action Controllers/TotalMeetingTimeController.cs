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
    public class TotalMeetingTimeController : ControllerBase
    {
        private readonly ITotalMeetingTimeServices _totalMeetingTimeServices;
        public TotalMeetingTimeController(ITotalMeetingTimeServices totalMeetingTimeServices)
        {
            this._totalMeetingTimeServices = totalMeetingTimeServices;
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<TotalMeetingTimeModel>>> GetById(int Id)
        {
            return await _totalMeetingTimeServices.GetById(Id);
        }
            [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> CreateandUpdateTotaltime(TotalMeetingTimeModel meetingTime)
        {
            return await _totalMeetingTimeServices.CreateandUpdateTotaltime(meetingTime);
        }
            [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> DeleteTotaltime(TotalMeetingTimeModel meetingTime)
        {
            return await _totalMeetingTimeServices.DeleteTotaltime(meetingTime);
        }
    }
}
