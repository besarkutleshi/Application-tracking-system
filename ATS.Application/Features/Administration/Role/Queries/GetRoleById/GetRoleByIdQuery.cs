using ATS.Application.DTO_s.Administration.Roles;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Queries.GetRoleById
{
    public record GetRoleByIdQuery(int id) : IRequest<ListRolesDTO>;
}
