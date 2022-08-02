using ATS.Application.DTO_s.Administration.Roles;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Commands.CreateRole
{
    public record CreateRoleCommand(CreateRoleDTO createRole) : IRequest<CreateRoleDTO>;
}
