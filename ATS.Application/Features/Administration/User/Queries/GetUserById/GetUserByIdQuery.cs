using ATS.Application.DTO_s.Administration.Users;
using MediatR;

namespace ATS.Application.Features.Administration.User.Queries.GetUserById
{
    public record GetUserByIdQuery(int id) : IRequest<ListUserDTO>;
}
