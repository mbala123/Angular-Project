using Consul;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Appointment_Scheduling_Application.Services.Auth_Services
{
    public interface IJwtService
    {
        Task<string> GenerateJwtToken(string email);
    }
    public class JwtService: IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        public JwtService(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task<string> GenerateJwtToken(string email)
        {
            var issuers = "http://localhost";
            var audience = "http://localhost";
            var Key = "0123456789ABCDEF";
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(type:JwtRegisteredClaimNames.Email,value:user.Email),
                        new Claim(type:JwtRegisteredClaimNames.Jti,value:user.Id),

                    };
                    var keyBytes = Encoding.UTF8.GetBytes(Key);
                    var theKey = new SymmetricSecurityKey(keyBytes);
                    var creds = new SigningCredentials(theKey, SecurityAlgorithms.HmacSha256);
                    DateTime date = DateTime.Now;
                    var token = new JwtSecurityToken(issuers, audience, claims, date, DateTime.Now.AddHours(2), creds);
                    var generatedToken= new { token = new JwtSecurityTokenHandler().WriteToken(token) };
                return Convert.ToString(generatedToken.token);
                }
            return "😵🥴 Wrong Wrong";
        }
    }
}
