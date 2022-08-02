using ATS.Application.DTO_s.Administration.UserRole;
using MediatR;

namespace ATS.Application.Features.Administration.User.Commands.AddUserRoles
{
    public record AddUserRolesCommand(int userId, List<CreateUserRoleDTO> createUserRoles) : IRequest<bool>;
}
