using ATS.Application.Contracts.Persistence.Administration;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.Authentication.Commands.ChangePassword
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IAuthentication _authentication;

        public ChangePasswordHandler(IMapper mapper, IAuthentication authentication)
        {
            _mapper = mapper;
            _authentication = authentication;
        }

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ATS.Domain.Models.User>(request.changePassword);
            var isChanged = await _authentication.ChangePassword(user, request.changePassword.NewPassword, cancellationToken);

            return isChanged;
        }
    }
}
