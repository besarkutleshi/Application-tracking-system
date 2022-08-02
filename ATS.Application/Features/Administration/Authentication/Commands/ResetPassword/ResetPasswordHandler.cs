using ATS.Application.Contracts.Infrastructure;
using ATS.Application.Contracts.Persistence.Administration;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.Authentication.Commands.ResetPassword
{
    public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly IAuthentication _authentication;
        private readonly IMapper _mapper;
        private readonly IToken _token;

        public ResetPasswordHandler(IAuthentication authentication, IMapper mapper, IToken token)
        {
            _authentication = authentication;
            _mapper = mapper;
            _token = token;
        }

        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ATS.Domain.Models.User>(request.resetPassword);

            var validToken = _token.ValidateToken(request.resetPassword.Token);

            if (validToken is null) throw new Exception("Can not reset password");

            return await _authentication.ResetPassword(user.Username, user.Password, cancellationToken);
        }
    }
}
