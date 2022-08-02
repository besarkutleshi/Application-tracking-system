using ATS.Application.DTO_s.Administration.UserRole;
using ATS.Application.DTO_s.Administration.Users;
using ATS.Application.Features.Administration.User.Commands.AddUserRoles;
using ATS.Application.Features.Administration.User.Commands.CreateUser;
using ATS.Application.Features.Administration.User.Commands.DeleteUser;
using ATS.Application.Features.Administration.User.Commands.UpdateUser;
using ATS.Application.Features.Administration.User.Queries.GetUserById;
using ATS.Application.Features.Administration.User.Queries.GetUserRoles;
using ATS.Application.Features.Administration.User.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ATS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUser, CancellationToken token)
        {
            var createUserCommand = new CreateUserCommand(createUser);
            var user = await _mediator.Send(createUserCommand, token);

            return user is not null ? Ok(user.Id) : BadRequest("Can not create user");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUsers(CancellationToken token)
        {
            var getUsersQuery = new GetUsersQuery();
            var users = await _mediator.Send(getUsersQuery, token);

            if (users.Count == 0) return NotFound();
            if (users is null) return BadRequest("Can not find users");

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken token)
        {
            var getUserByIdQuery = new GetUserByIdQuery(id);
            var user = await _mediator.Send(getUserByIdQuery, token);

            if(user is null) return NotFound();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id, CancellationToken token)
        {
            var deleteUserCommand = new DeleteUserCommand(id);
            var deleted = await _mediator.Send(deleteUserCommand, token);

            return deleted ? Ok() : BadRequest("Can not delete user");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO updateUser, CancellationToken token)
        {
            var updateUserCommand = new UpdateUserCommand(updateUser);
            var updated = await _mediator.Send(updateUserCommand, token);

            return updated ? Ok() : BadRequest("Can not updated user");
        }

        [HttpGet("{userId}/roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserRoles(int userId, CancellationToken token)
        {
            var getUserRolesQuery = new GetUserRolesQuery(userId);
            var userRoles = await _mediator.Send(getUserRolesQuery, token);

            if(userRoles.Count == 0) return NotFound();
            if (userRoles is null) return BadRequest("Can not find user roles");

            return Ok(userRoles);
        }

        [HttpPost("{userId}/roles")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUserRoles(int userId, List<CreateUserRoleDTO> userRoleDTOs, CancellationToken token)
        {
            var addUserRoles = new AddUserRolesCommand(userId, userRoleDTOs);
            var added = await _mediator.Send(addUserRoles, token);

            return added ? Ok() : BadRequest("Can not add User Roels");
        }
    }
}
