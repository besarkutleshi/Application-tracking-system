using ATS.Application.DTO_s.Administration.Roles;
using FluentValidation;

namespace ATS.Application.Features.Administration.Role.Commands.CreateRole
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleDTO>
    {
        public CreateRoleValidator()
        {
            RuleFor(r => r.RoleName).NotEmpty();
            RuleFor(r => r.InsertBy).GreaterThan(0);
        }
    }
}
