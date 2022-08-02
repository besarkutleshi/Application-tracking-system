using ATS.Application.DTO_s.Administration.UserRole;
using MediatR;

namespace ATS.Application.Features.Administration.User.Queries.GetUserRoles
{
    public record GetUserRolesQuery(int userId) : IRequest<List<ListUserRoleDTO>>;
}
