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
    public class RecoveryController : ControllerBase
    {
        private readonly IRecoveryServices _recoveryServices;
        public RecoveryController(IRecoveryServices recoveryServices)
        {
            _recoveryServices = recoveryServices;
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<RecoveryModel>> GetRecoveryById(int UserId)
        {
            return Ok(await _recoveryServices.GetRecoveryById(UserId));
        }
        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> CreateRecovery(RecoveryModel recovery)
        {
            return Ok(await _recoveryServices.CreateRecovery(recovery));
        }
        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> DeleteRecovery(RecoveryModel recovery)
        {
            return Ok(await _recoveryServices.DeleteRecovery(recovery));
        }
    }
}
