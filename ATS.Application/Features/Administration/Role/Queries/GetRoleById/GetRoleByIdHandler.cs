using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.DTO_s.Administration.Roles;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Queries.GetRoleById
{
    public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, ListRolesDTO>
    {
        private readonly IRole _role;
        private readonly IMapper _mapper;

        public GetRoleByIdHandler(IRole role, IMapper mapper)
        {
            _role = role;
            _mapper = mapper;
        }

        public async Task<ListRolesDTO> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.id < 1) throw new Exception("Role Id must be greater than 0");

            var role = await _role.GetAsync(request.id, cancellationToken);

            return _mapper.Map<ListRolesDTO>(role);
        }
    }
}
