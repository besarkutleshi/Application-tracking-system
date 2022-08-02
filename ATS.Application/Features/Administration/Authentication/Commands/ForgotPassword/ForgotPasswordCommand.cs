using MediatR;

namespace ATS.Application.Features.Administration.Authentication.Commands.ForgotPassword
{
    public record ForgotPasswordCommand(string username) : IRequest<bool>;
}
