using ATS.Application.DTO_s.Administration.Authentication;
using FluentValidation;

namespace ATS.Application.Features.Administration.Authentication.Commands.ResetPassword
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordDTO>
    {
        public ResetPasswordValidator()
        {
            RuleFor(a => a.Username).NotEmpty();
            RuleFor(a => a.ConfirmPassword).NotEmpty();
            RuleFor(p => p.NewPassword).NotEmpty().WithMessage("Your password cannot be empty")
                   .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                   .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                   .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                   .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                   .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                   .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).")
                   .NotEqual(x => x.ConfirmPassword).WithMessage("Password and new password must match");
        }
    }
}
