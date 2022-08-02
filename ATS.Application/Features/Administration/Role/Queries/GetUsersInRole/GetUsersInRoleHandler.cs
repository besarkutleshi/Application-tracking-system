using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.DTO_s.Administration.UserRole;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Queries.GetUsersInRole
{
    public class GetUsersInRoleHandler : IRequestHandler<GetUsersInRoleQuery, List<ListUserRoleDTO>>
    {
        private readonly IRole _role;
        private readonly IMapper _mapper;

        public GetUsersInRoleHandler(IRole role, IMapper mapper)
        {
            _role = role;
            _mapper = mapper;
        }

        public async Task<List<ListUserRoleDTO>> Handle(GetUsersInRoleQuery request, CancellationToken cancellationToken)
        {
            if (request.roleId < 1) throw new Exception("Role Id must be greater than 0");

            var usersInRole = await _role.GetUsersInRole(request.roleId, cancellationToken);

            return _mapper.Map<List<ListUserRoleDTO>>(usersInRole);
        }
    }
}
