using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.DTO_s.Administration.Users;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Administration.User.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserDTO>
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<CreateUserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ATS.Domain.Models.User>(request.createUser);
            var addedUser = await _user.AddAsync(user, cancellationToken);
            return _mapper.Map<CreateUserDTO>(addedUser);
        }
    }
}
