using ATS.Application.Contracts.Infrastructure;
using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.Models;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ATS.Application.Features.Administration.Authentication.Commands.ForgotPassword
{
    public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordCommand, bool>
    {
        private readonly IUser _user;
        private readonly IToken _token;
        private readonly ISendEmail _sendEmail;
        private readonly IConfiguration _configuration;

        public ForgotPasswordHandler(IUser user, IToken token, ISendEmail sendEmail, IConfiguration configuration)
        {
            _user = user;
            _token = token;
            _sendEmail = sendEmail;
            _configuration = configuration;
        }

        public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(request.username)) throw new Exception("Username must be defined");

            var user = await _user.GetUserByUsernameAsync(request.username, cancellationToken);

            if(user is not null)
            {
                string token = _token.GenerateTokenEmailConfirmation(user.Id, user.Username);
                string link = $"{_configuration.GetValue<string>("EmailSettings:WebSiteLink")}resetPassword/{token}";
                string body = $"Please reset your account password by clicking this link <a href={link}> Reset Password Link </a> ";
                var response = await _sendEmail.SendEmail(new MailRequest("", user.Username, "Forgot Password", body, 3, "KEDS_MAIL"));

                if (response) return true;
            }
            return false;
        }
    }
}
