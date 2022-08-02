using ATS.Application.DTO_s.Administration.Authentication;
using MediatR;

namespace ATS.Application.Features.Administration.Authentication.Commands.Login
{
    public record LoginCommand(LoginDTO login) : IRequest<LoginResponseDTO>;
}
