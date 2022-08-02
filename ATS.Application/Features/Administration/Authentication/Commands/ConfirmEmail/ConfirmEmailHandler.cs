using ATS.Application.Contracts.Infrastructure;
using ATS.Application.Contracts.Persistence.Administration;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.Authentication.Commands.ConfirmEmail
{
    public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IAuthentication _authentication;
        private readonly IToken _token;

        public ConfirmEmailHandler(IMapper mapper, IAuthentication authentication, IToken token)
        {
            _mapper = mapper;
            _authentication = authentication;
            _token = token;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(request.token)) throw new Exception("Can not confirm email");

            var tokenResponse = _token.ValidateToken(request.token);
            if (tokenResponse == null) throw new Exception("Can not confirm email");

            return await _authentication.ConfirmEmail(tokenResponse.UserId, tokenResponse.Email, cancellationToken);
        }
    }
}
