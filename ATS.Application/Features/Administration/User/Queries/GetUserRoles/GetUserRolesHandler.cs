using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.DTO_s.Administration.UserRole;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.User.Queries.GetUserRoles
{
    public class GetUserRolesHandler : IRequestHandler<GetUserRolesQuery, List<ListUserRoleDTO>>
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public GetUserRolesHandler(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<List<ListUserRoleDTO>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            if (request.userId < 1) throw new Exception("User Id must be greater than 0");

            var userRoles = await _user.GetUserRoles(request.userId, cancellationToken);

            return _mapper.Map<List<ListUserRoleDTO>>(userRoles);
        }
    }
}
