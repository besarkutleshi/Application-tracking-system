using ATS.Application.DTO_s.Administration.Users;
using MediatR;

namespace ATS.Application.Features.Administration.User.Queries.GetUsers
{
    public record GetUsersQuery() : IRequest<List<ListUserDTO>>;
}
