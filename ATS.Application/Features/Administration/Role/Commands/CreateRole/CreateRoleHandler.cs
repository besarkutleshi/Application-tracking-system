using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.DTO_s.Administration.Roles;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Commands.CreateRole
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, CreateRoleDTO>
    {
        private readonly IRole _role;
        private readonly IMapper _mapper;

        public CreateRoleHandler(IRole role, IMapper mapper)
        {
            _role = role;
            _mapper = mapper;
        }

        public async Task<CreateRoleDTO> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<ATS.Domain.Models.Role>(request.createRole);
            var createdRole = await _role.AddAsync(role, cancellationToken);
            return _mapper.Map<CreateRoleDTO>(createdRole);
        }
    }
}
