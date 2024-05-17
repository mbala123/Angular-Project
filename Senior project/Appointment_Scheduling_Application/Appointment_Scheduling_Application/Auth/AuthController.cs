using Appointment_Scheduling_Application.Services.Auth_Services;
using Appointment_Scheduling_Application.Services.MailSendingService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_Scheduling_Application.WebAPI.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        private readonly IJwtService _jwtService;
        public AuthController(IAuthServices authServices, IJwtService jwtService)
        {
            _authServices = authServices;
            _jwtService = jwtService;
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> EmailVerification(string Email)
        {
            return Ok(await _authServices.EmailVerificationtokenGenrator(Email));
        }
        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> confirmMail(string email,string token)
        {
            return Ok(await _authServices.confirmEmail(email,token));
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<string> GenerateTokenforqrcode(string email)
        {
            return await _authServices.GenerateTokenforqrcode(email);
        }

        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<bool> TwosetVerification(string email, string Opt)
        {
            return await _authServices.TwosetVerification(email, Opt);  
        }
        [HttpGet("[action]")]
        //[AllowAnonymous]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<string> GetToken(string email)
        {
            return (await _jwtService.GenerateJwtToken(email));
        }
    }
}
