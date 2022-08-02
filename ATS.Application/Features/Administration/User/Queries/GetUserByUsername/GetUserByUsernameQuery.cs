using ATS.Application.DTO_s.Administration.Users;
using MediatR;

namespace ATS.Application.Features.Administration.User.Queries.GetUserByUsername
{
    public record GetUserByUsernameQuery(string username) : IRequest<ListUserDTO>;
}
