using ATS.Application.DTO_s.Administration.Authentication;
using FluentValidation;
namespace ATS.Application.Features.Administration.Authentication.Commands.ConfirmEmail
{
    public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailDTO>
    {
        public ConfirmEmailValidator()
        {
            RuleFor(a => a.Username).NotEmpty().EmailAddress();
            RuleFor(a => a.UserId).GreaterThan(0);
        }
    }
}
