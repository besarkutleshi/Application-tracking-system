using ATS.Application.Contracts.Persistence.Administration;
using ATS.Domain.Models;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Commands.AddUserRole
{
    public class AddUserRoleHandler : IRequestHandler<AddUserRoleCommand, bool>
    {
        private readonly IRole _role;
        private readonly IMapper _mapper;

        public AddUserRoleHandler(IRole role, IMapper mapper)
        {
            _role = role;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            if (request.roleId < 1) throw new Exception("Role Id must be greater than 0");

            var userrole = _mapper.Map<List<UserRole>>(request.createUserRoles.Where(ur => ur.IsChecked == 1));

            return await _role.AddRolesInRole(request.roleId, userrole, cancellationToken);
        }
    }
}
