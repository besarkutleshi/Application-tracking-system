using ATS.Application.DTO_s.Administration.Users;
using MediatR;

namespace ATS.Application.Features.Administration.User.Commands.CreateUser
{
    public record CreateUserCommand(CreateUserDTO createUser) : IRequest<CreateUserDTO>;
}
