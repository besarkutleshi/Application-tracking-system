using ATS.Application.Contracts.Infrastructure;
using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.Models;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ATS.Application.Features.Administration.Authentication.Commands.Register
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAuthentication _authentication;
        private readonly ISendEmail _sendEmail;
        private readonly IConfiguration _configuration;
        private readonly IToken _token;

        public RegisterUserHandler(IMapper mapper, IAuthentication authentication, ISendEmail sendEmail, IConfiguration configuration, IToken token)
        {
            _mapper = mapper;
            _authentication = authentication;
            _sendEmail = sendEmail;
            _configuration = configuration;
            _token = token;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ATS.Domain.Models.User>(request.registerUser);
            var model = await _authentication.RegisterUser(user, cancellationToken);
            if (model is not null)
            {
                string token = _token.GenerateTokenEmailConfirmation(model.Id, model.Username);
                // change WebSiteLink value to localhost:3000 when you are in development in appsettings 
                string link = $"{_configuration.GetValue<string>("EmailSettings:WebSiteLink")}{token}/confirmEmail";
                string body = $"Please confirm your account by clicking this link <a href={link}> Confirmation Link </a>";
                var response = await _sendEmail.SendEmail(new MailRequest("", model.Username, "Email Confirmation", body, 3, "KEDS_MAIL"));
                
                if (response) return 1;

                if (!response) return model.Id;
            }
            return -1;
        }
    }
}
