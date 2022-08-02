using ATS.Application.DTO_s.Administration.Users;
using MediatR;

namespace ATS.Application.Features.Administration.User.Commands.UpdateUser
{
    public record UpdateUserCommand(UpdateUserDTO updateUser) : IRequest<bool>;
}
