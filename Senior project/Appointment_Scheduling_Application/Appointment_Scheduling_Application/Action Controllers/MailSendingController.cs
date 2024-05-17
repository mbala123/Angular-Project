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
    public class MailSendingController : ControllerBase
    {
        private readonly IMailSendingServices _mailSendingServices;
        public MailSendingController(IMailSendingServices mailSendingServices)
        {
            this._mailSendingServices = mailSendingServices;
        }

        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<MailSendingModel>>> GetBySendingEmail(string email)
        {
            if (email != null)
            {
                return Ok(await _mailSendingServices.GetBySendingEmail(email));
            }
            return BadRequest("Mission Incomplete");
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<ToParticipant>>> GetByToEmail(string email)
        {
            if (email != null)
            {
                return Ok(await _mailSendingServices.GetByToEmail(email));
            }
            return BadRequest("Mission Incomplete");
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<MailSendingModel>>> GetByCcEmail(string email)
        {
            if (email != null)
            {
                return Ok(await _mailSendingServices.GetByCcEmail(email));
            }
            return BadRequest("Mission Incomplete");
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<bool>> CreateMail(MailSendingModel MailDetails)
        {
            ToParticipant to=new ToParticipant();
            if (MailDetails != null && to != null)
            {
                return Ok(await _mailSendingServices.CreateMail(MailDetails, to));
            }
            return BadRequest(false);
        }
    }
}
