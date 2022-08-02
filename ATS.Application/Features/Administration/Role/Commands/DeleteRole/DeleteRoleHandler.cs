using ATS.Application.Contracts.Persistence.Administration;
using MediatR;

namespace ATS.Application.Features.Administration.Role.Commands.DeleteRole
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly IRole _role;

        public DeleteRoleHandler(IRole role)
        {
            _role = role;
        }

        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            if (request.id < 1) throw new Exception("Role Id must be greater than 0");

            return await _role.DeleteAsync(request.id, cancellationToken);
        }
    }
}
