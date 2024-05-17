using Appointment_Scheduling_Application.Services.MailSendingService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_Scheduling_Application.Services.Auth_Services
{
    public interface IAuthServices 
    {
        Task<string> EmailVerificationtokenGenrator(string email);
        Task<string> confirmEmail(string email, string token);
        Task<string> GenerateTokenforqrcode(string email);
        Task<bool> TwosetVerification(string email,string Opt);

    }

    public class AuthServices: IAuthServices
    {
        private readonly IMailNoticationSendingService _mailNoticationSendingService;
        private readonly UserManager<IdentityUser> _userManager;
        public AuthServices(IMailNoticationSendingService mailNoticationSendingService, UserManager<IdentityUser> userManager)
        {
            this._mailNoticationSendingService = mailNoticationSendingService;
            this._userManager = userManager;
        }
        public async Task<string> EmailVerificationtokenGenrator(string email)
        {
            var user = await FindUser(email);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //var message = "locahost";
            if(token!=null)
            {
                return await _mailNoticationSendingService.Sendingmail(email, token, ConstantValues.ConstantValues.verificationMailSubject);
            }
            return (ConstantValues.ConstantValues.ErrorMailMessage);
        }
        public async Task<string> confirmEmail(string email,string token)
        {
            var user = await FindUser(email);
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if(result.Succeeded)
            {
                return await _mailNoticationSendingService.Sendingmail(email,ConstantValues.ConstantValues.verifyedMailSubject, ConstantValues.ConstantValues.verifyedMailSubject);
            }
            return (ConstantValues.ConstantValues.ErrorMailMessage);
        }
        public async Task<string> GenerateTokenforqrcode(string email)
        {
            var response=await FindUser(email);
            var result = await _userManager.ResetAuthenticatorKeyAsync(response);
            return await _userManager.GetAuthenticatorKeyAsync(response);
        }
        public async Task<bool> TwosetVerification(string email,string Opt)
        {
            var response = await FindUser(email);
            var result = await _userManager.VerifyTwoFactorTokenAsync(response, _userManager.Options.Tokens.AuthenticatorTokenProvider,Opt);
            if (result)
            {
                await _userManager.SetTwoFactorEnabledAsync(response, true);
                return true;
            }
            return false;
        }
        private async Task<IdentityUser> FindUser(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
