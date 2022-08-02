using ATS.Application.DTO_s.Administration.Users;
using FluentValidation;

namespace ATS.Application.Features.Administration.User.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator()
        {
            RuleFor(a => a.Username).NotEmpty();
            RuleFor(a => a.EmpId).NotEmpty();
            RuleFor(a => a.InsertBy).GreaterThan(0);
        }
    }
}
