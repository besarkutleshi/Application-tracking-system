using ATS.Application.DTO_s.Administration.Authentication;
using MediatR;

namespace ATS.Application.Features.Administration.Authentication.Commands.Register
{
    public record RegisterUserCommand(RegisterUserDTO registerUser) : IRequest<int>;
}
