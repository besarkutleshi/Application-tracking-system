using ATS.Application.DTO_s.Administration.Roles;
using ATS.Application.DTO_s.Administration.UserRole;
using ATS.Application.Features.Administration.Role.Commands.AddUserRole;
using ATS.Application.Features.Administration.Role.Commands.CreateRole;
using ATS.Application.Features.Administration.Role.Commands.DeleteRole;
using ATS.Application.Features.Administration.Role.Commands.UpdateRole;
using ATS.Application.Features.Administration.Role.Queries.GetRoleById;
using ATS.Application.Features.Administration.Role.Queries.GetRoles;
using ATS.Application.Features.Administration.Role.Queries.GetUsersInRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ATS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(CreateRoleDTO createRole, CancellationToken token)
        {
            var createRoleCommand = new CreateRoleCommand(createRole);
            var role = await _mediator.Send(createRoleCommand, token);

            return role is not null ? Ok(role.Id) : BadRequest("Can not add role");
        }

        [HttpPut]
        public async Task<IActionResult> EditRole(UpdateRoleDTO updateRole, CancellationToken token)
        {
            var updateRoleCommand = new UpdateRoleCommand(updateRole);
            var role = await _mediator.Send(updateRoleCommand, token);

            return role ? Ok() : BadRequest("Can not update role");
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles(CancellationToken token)
        {
            var getRolesQuery = new GetRolesQuery();
            var roles = await _mediator.Send(getRolesQuery, token);

            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id, CancellationToken token)
        {
            var getRoleByIdQuery = new GetRoleByIdQuery(id);
            var role = await _mediator.Send(getRoleByIdQuery, token);

            return Ok(role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id, CancellationToken token)
        {
            var deleteRoleCommand = new DeleteRoleCommand(id);
            var deleted = await _mediator.Send(deleteRoleCommand, token);

            return deleted ? Ok() : BadRequest("Can not delete role");
        }

        [HttpGet("{roleId}/usersInRole")]
        public async Task<IActionResult> GetUsersInRole(int roleId, CancellationToken token)
        {
            var getUsersInRoleQuery = new GetUsersInRoleQuery(roleId);
            var users = await _mediator.Send(getUsersInRoleQuery, token);

            return Ok(users);
        }

        [HttpPost("{roleId}/usersInRole")]
        public async Task<IActionResult> AddUsersInRole(int roleId, List<CreateUserRoleDTO> userRoles, CancellationToken token)
        {
            var addUsersInRoleCommand = new AddUserRoleCommand(roleId, userRoles);
            var areAdded = await _mediator.Send(addUsersInRoleCommand, token);

            return areAdded ? Ok() : BadRequest("Can not add users in role");
        }
    }
}
