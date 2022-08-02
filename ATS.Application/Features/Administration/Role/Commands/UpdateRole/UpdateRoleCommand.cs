using ATS.Application.DTO_s.Administration.Roles;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Commands.UpdateRole
{
    public record UpdateRoleCommand(UpdateRoleDTO updateRole) : IRequest<bool>;
}
