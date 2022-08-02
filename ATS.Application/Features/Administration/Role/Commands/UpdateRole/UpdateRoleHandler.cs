using ATS.Application.Contracts.Persistence.Administration;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Commands.UpdateRole
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, bool>
    {
        private readonly IRole _role;
        private readonly IMapper _mapper;

        public UpdateRoleHandler(IRole role, IMapper mapper)
        {
            _role = role;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<ATS.Domain.Models.Role>(request.updateRole);

            return await _role.UpdateAsync(role, cancellationToken);
        }
    }
}
