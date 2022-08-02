using ATS.Application.DTO_s.Administration.Authentication;
using FluentValidation;

namespace ATS.Application.Features.Administration.Authentication.Commands.ChangePassword
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordValidator()
        {
            RuleFor(a => a.UserId).GreaterThan(0);
            RuleFor(a => a.Username).NotEmpty();
            RuleFor(a => a.OldPassword).NotEmpty();
            RuleFor(a => a.OldPassword).NotEqual(x => x.NewPassword).WithMessage("Old password and new password must be different");
            RuleFor(p => p.NewPassword).NotEmpty().WithMessage("Your password cannot be empty")
                   .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                   .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                   .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                   .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                   .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                   .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
        }
    }
}
