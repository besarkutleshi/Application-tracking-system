using MediatR;

namespace ATS.Application.Features.Administration.User.Commands.DeleteUser
{
    public record DeleteUserCommand(int id) : IRequest<bool>;
}
