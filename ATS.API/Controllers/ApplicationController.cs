using ATS.Application.DTO_s.Administration.Applications.Application;
using ATS.Application.Features.Applications.Application.Commands.CreateApplication;
using ATS.Application.Features.Applications.Application.Commands.UpdateApplicationStatus;
using ATS.Application.Features.Applications.Application.Queries.GetApplicationQuestions;
using ATS.Application.Features.Applications.Application.Queries.GetApplications;
using ATS.Application.Features.Applications.Application.Queries.GetUserApplications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ATS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private IMediator _mediator;

        public ApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplications(CancellationToken token)
        {
            var getApplicationQuery = new GetApplicationsQuery();
            var list = await _mediator.Send(getApplicationQuery, token);

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(CreateApplicationDTO createApplication, CancellationToken token)
        {
            var createApplicationCommand = new CreateApplicationCommand(createApplication);
            var model = await _mediator.Send(createApplicationCommand, token);

            return model is not null ? Ok(model) : BadRequest("Can not create application");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplicationStatus(UpdateApplicationsDTO updateApplications, CancellationToken token)
        {
            var updateApplicationCommand = new UpdateApplicationStatusCommand(updateApplications);
            var isUpdated = await _mediator.Send(updateApplicationCommand, token);
            return isUpdated ? Ok() : BadRequest("Can not update application status");
        }

        [HttpGet("{applicationId}/questions")]
        public async Task<IActionResult> GetApplicationQuestions(int applicationId, CancellationToken token)
        {
            var getApplicationQuestionsQuery = new GetApplicationQuestionsQuery(applicationId);
            var list = await _mediator.Send(getApplicationQuestionsQuery, token);

            return Ok(list);
        }

        [HttpGet("{userId}/{applicationTypeId}")]
        public async Task<IActionResult> GetUserApplications(int userId, int applicationTypeId, CancellationToken token)
        {
            var getUserApplicationsQuery = new GetUserApplicationsQuery(userId, applicationTypeId);
            var list = await _mediator.Send(getUserApplicationsQuery, token);

            return Ok(list);
        }

    }
}
