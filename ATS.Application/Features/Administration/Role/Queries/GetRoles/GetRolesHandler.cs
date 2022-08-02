using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.DTO_s.Administration.Roles;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Queries.GetRoles
{
    public class GetRolesHandler : IRequestHandler<GetRolesQuery, List<ListRolesDTO>>
    {
        private readonly IRole _role;
        private readonly IMapper _mapper;

        public GetRolesHandler(IRole role, IMapper mapper)
        {
            _role = role;
            _mapper = mapper;
        }

        public async Task<List<ListRolesDTO>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _role.GetListAsync(cancellationToken);
            return _mapper.Map<List<ListRolesDTO>>(roles);
        }
    }
}
