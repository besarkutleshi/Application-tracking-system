using MediatR;

namespace ATS.Application.Features.Administration.Authentication.Commands.ConfirmEmail
{
    public record ConfirmEmailCommand(string token) : IRequest<bool>;
}
