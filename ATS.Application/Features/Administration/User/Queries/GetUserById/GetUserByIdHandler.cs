using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.DTO_s.Administration.Users;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.User.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ListUserDTO>
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<ListUserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.id < 1) throw new Exception("User Id must be grear than 0");

            var user = await _user.GetAsync(request.id, cancellationToken);

            return _mapper.Map<ListUserDTO>(user);
        }
    }
}
