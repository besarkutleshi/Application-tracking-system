using ATS.Application.DTO_s.Administration.Roles;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Queries.GetRoles
{
    public record GetRolesQuery : IRequest<List<ListRolesDTO>>;
}
