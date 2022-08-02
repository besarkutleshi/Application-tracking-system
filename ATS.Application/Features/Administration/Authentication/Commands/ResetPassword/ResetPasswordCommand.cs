using ATS.Application.DTO_s.Administration.Authentication;
using MediatR;
namespace ATS.Application.Features.Administration.Authentication.Commands.ResetPassword
{
    public record ResetPasswordCommand(ResetPasswordDTO resetPassword) : IRequest<bool>;
}
