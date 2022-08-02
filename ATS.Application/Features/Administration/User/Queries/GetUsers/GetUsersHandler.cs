using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.DTO_s.Administration.Users;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.User.Queries.GetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<ListUserDTO>>
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public GetUsersHandler(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<List<ListUserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _user.GetListAsync(cancellationToken);
            return _mapper.Map<List<ListUserDTO>>(users);
        }
    }
}
