using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.DTO_s.Administration.Users;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.User.Queries.GetUserByUsername
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, ListUserDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public GetUserByUsernameHandler(IMapper mapper, IUser user)
        {
            _mapper = mapper;
            _user = user;
        }

        public async Task<ListUserDTO> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(request.username)) throw new Exception("Username must be defined");

            var user = await _user.GetUserByUsernameAsync(request.username, cancellationToken);

            return _mapper.Map<ListUserDTO>(user);
        }
    }
}
