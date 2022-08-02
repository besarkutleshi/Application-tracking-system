using ATS.Application.Contracts.Persistence.Administration;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.User.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ATS.Domain.Models.User>(request.updateUser);

            return await _user.UpdateAsync(user, cancellationToken);
        }
    }
}
