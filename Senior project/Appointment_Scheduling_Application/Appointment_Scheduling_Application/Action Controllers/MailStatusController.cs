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
    public class MailStatusController : ControllerBase
    {
        private readonly IMailStatusServices _mailStatusServices;
        public MailStatusController(IMailStatusServices mailStatusServices)
        {
            this._mailStatusServices = mailStatusServices;
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<MailStatusModel>> GetStatusById(int MailId)
        {
            if (MailId != 0)
            {
                return Ok(await _mailStatusServices.GetStatusById(MailId));
            }
            return BadRequest(false);
        }
        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> CreateandUpdateStatus(MailStatusModel mailStatus)
        {
            if (mailStatus != null)
            {
                return Ok(await _mailStatusServices.CreateandUpdateStatus(mailStatus));
            }
            return BadRequest(false);
        }
        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> DeleteStatus(MailStatusModel mailStatus)
        {
            if (mailStatus != null)
            {
                return Ok(await _mailStatusServices.DeleteStatus(mailStatus));
            }
            return BadRequest(false);
        }
    }
}
