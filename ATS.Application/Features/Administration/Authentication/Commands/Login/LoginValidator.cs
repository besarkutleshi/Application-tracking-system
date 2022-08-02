using ATS.Application.DTO_s.Administration.Authentication;
using FluentValidation;

namespace ATS.Application.Features.Administration.Authentication.Commands.Login
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
