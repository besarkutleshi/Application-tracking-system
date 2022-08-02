using ATS.Application.DTO_s.Administration.UserRole;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Queries.GetUsersInRole
{
    public record GetUsersInRoleQuery(int roleId) : IRequest<List<ListUserRoleDTO>>;
}
