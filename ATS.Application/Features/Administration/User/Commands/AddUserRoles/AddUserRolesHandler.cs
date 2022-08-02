using ATS.Application.Contracts.Persistence.Administration;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.User.Commands.AddUserRoles
{
    public class AddUserRolesHandler : IRequestHandler<AddUserRolesCommand, bool>
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public AddUserRolesHandler(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddUserRolesCommand request, CancellationToken cancellationToken)
        {
            if (request.userId < 1) throw new Exception("User Id must be greater than 0");

            var userRoles = _mapper.Map<List<ATS.Domain.Models.UserRole>>(request.createUserRoles.Where(ur => ur.IsChecked == 1).ToList());

            return await _user.AddUserRoles(request.userId, userRoles, cancellationToken);
        }
    }
}
