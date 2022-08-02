using ATS.Application.Contracts.Persistence.Administration;
using MediatR;

namespace ATS.Application.Features.Administration.User.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUser _user;

        public DeleteUserHandler(IUser user)
        {
            _user = user;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (request.id < 1) throw new Exception("User Id must be greater than 0");

            return await _user.DeleteAsync(request.id, cancellationToken);
        }
    }
}
