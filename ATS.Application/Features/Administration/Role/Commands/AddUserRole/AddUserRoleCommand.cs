using ATS.Application.DTO_s.Administration.UserRole;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Commands.AddUserRole
{
    public record AddUserRoleCommand(int roleId, List<CreateUserRoleDTO> createUserRoles) : IRequest<bool>;
}
