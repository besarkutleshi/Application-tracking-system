using ATS.Application.DTO_s.Administration.Roles;
using FluentValidation;

namespace ATS.Application.Features.Administration.Role.Commands.UpdateRole
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleDTO>
    {
        public UpdateRoleValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0);
            RuleFor(r => r.RoleName).NotEmpty();
            RuleFor(r => r.UpdateBy).GreaterThan(0);
        }
    }
}
