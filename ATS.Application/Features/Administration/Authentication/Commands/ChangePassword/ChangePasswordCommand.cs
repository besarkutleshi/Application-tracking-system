using ATS.Application.DTO_s.Administration.Authentication;
using MediatR;

namespace ATS.Application.Features.Administration.Authentication.Commands.ChangePassword
{
    public record ChangePasswordCommand(ChangePasswordDTO changePassword) : IRequest<bool>;
}
