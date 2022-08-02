using ATS.Application.DTO_s.Administration.Authentication;
using ATS.Application.Features.Administration.Authentication.Commands.ChangePassword;
using ATS.Application.Features.Administration.Authentication.Commands.ConfirmEmail;
using ATS.Application.Features.Administration.Authentication.Commands.ForgotPassword;
using ATS.Application.Features.Administration.Authentication.Commands.Login;
using ATS.Application.Features.Administration.Authentication.Commands.Register;
using ATS.Application.Features.Administration.Authentication.Commands.ResetPassword;
using ATS.Application.Features.Administration.User.Commands.DeleteUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ATS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login, CancellationToken token)
        {
            var loginCommand = new LoginCommand(login);
            var response = await _mediator.Send(loginCommand, token);

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUser, CancellationToken token)
        {
            var registerCommand = new RegisterUserCommand(registerUser);
            var response = await _mediator.Send(registerCommand, token);

            if (response == 1) return Ok();

            if (response == -1) return BadRequest("Can not register user");

            // you must delete user when user is registered but email to confirm did not go,
            // because user will try to register again with the same email if we dont delete it, email will exists
            var deleteUserCommand = new DeleteUserCommand(response);
            await _mediator.Send(deleteUserCommand, token);

            return BadRequest("Can not register user");
        }


        [HttpGet("{username}/forgotPassword")]
        public async Task<IActionResult> ForgotPassword(string username, CancellationToken token)
        {
            var forgotPasswordCommand = new ForgotPasswordCommand(username);
            var response = await _mediator.Send(forgotPasswordCommand, token);

            return response ? Ok() : BadRequest("Can not send email");
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePassword, CancellationToken token)
        {
            var changePasswordCommand = new ChangePasswordCommand(changePassword);
            var response = await _mediator.Send(changePasswordCommand, token);

            return response ? Ok() : BadRequest("Can not change password");
        }

        [HttpPost("{token}/confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, CancellationToken cancellationToken)
        {
            var confirmEmailCommand = new ConfirmEmailCommand(token);
            var response = await _mediator.Send(confirmEmailCommand, cancellationToken);

            return response ? Ok() : BadRequest("Can not confirm email");
        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPassword, CancellationToken token)
        {
            var resetPasswordCommand = new ResetPasswordCommand(resetPassword);
            var isReseted = await _mediator.Send(resetPasswordCommand, token);

            return isReseted ? Ok() : BadRequest("Can not reset password");
        }

    }
}
