using MediatR;

namespace ATS.Application.Features.Administration.Role.Commands.DeleteRole
{
    public record DeleteRoleCommand(int id) : IRequest<bool>;
}
