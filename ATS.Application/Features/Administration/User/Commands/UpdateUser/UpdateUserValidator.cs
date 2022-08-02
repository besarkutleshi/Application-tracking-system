using ATS.Application.DTO_s.Administration.Users;
using FluentValidation;

namespace ATS.Application.Features.Administration.User.Commands.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator()
        {
            RuleFor(a => a.Id).GreaterThan(0);
            RuleFor(a => a.Username).NotEmpty();
            RuleFor(a => a.EmpId).GreaterThan(0);
            RuleFor(a => a.UpdateBy).GreaterThan(0);
        }
    }
}
