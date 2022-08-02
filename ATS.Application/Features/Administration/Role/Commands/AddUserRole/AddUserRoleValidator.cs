using ATS.Application.DTO_s.Administration.UserRole;
using FluentValidation;

namespace ATS.Application.Features.Administration.Role.Commands.AddUserRole
{
    public class AddUserRoleValidator : AbstractValidator<CreateUserRoleDTO>
    {
        public AddUserRoleValidator()
        {
            RuleFor(r => r.IsChecked).InclusiveBetween(0, 1);
            RuleFor(r => r.UserId).GreaterThan(0);
            RuleFor(r => r.RoleId).GreaterThan(0);
        }
    }
}
