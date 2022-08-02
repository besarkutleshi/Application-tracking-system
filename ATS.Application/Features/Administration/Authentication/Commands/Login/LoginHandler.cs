using ATS.Application.Contracts.Infrastructure;
using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.DTO_s.Administration.Authentication;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.Authentication.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponseDTO>
    {
        private readonly IAuthentication _authentication;
        private readonly IMapper _mapper;
        private readonly IToken _token;

        public LoginHandler(IAuthentication authentication, IMapper mapper, IToken token)
        {
            _authentication = authentication;
            _mapper = mapper;
            _token = token;
        }

        public async Task<LoginResponseDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var login = _mapper.Map<ATS.Domain.Models.User>(request.login);
            var user = await _authentication.Login(login, cancellationToken);

            var response = _mapper.Map<LoginResponseDTO>(user);
            response.Token = _token.GenerateToken(response);

            return response;
        }
    }
}
