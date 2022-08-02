using ATS.Application.DTO_s.Administration.Applications.Interview;
using ATS.Application.Features.Applications.Interview.Commands.ConfrimInterview;
using ATS.Application.Features.Applications.Interview.Commands.CreateInterview;
using ATS.Application.Features.Applications.Interview.Queries.GetInterviews;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ATS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private IMediator _mediator;

        public InterviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetInterviews(CancellationToken token)
        {
            var getInterviewsQuery = new GetInterviewsQuery();
            var list = await _mediator.Send(getInterviewsQuery, token);

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInterview(CreateInterviewDTO createInterview, CancellationToken token)
        {
            var createInterviewCommand = new CreateInterviewCommand(createInterview);
            var model = await _mediator.Send(createInterviewCommand, token);

            return model is not null ? Ok() : BadRequest("Can not create Interview");
        }

        [HttpPut("{interviewId}/{confirmValue}/confirmInterview")]
        public async Task<IActionResult> ConfirmInterview(int interviewId, short confirmValue, CancellationToken token)
        {
            var confirmInterviewCommand = new ConfirmInterviewCommand(interviewId, confirmValue);
            var response = await _mediator.Send(confirmInterviewCommand, token);

            return response ? Ok() : BadRequest("Can not confirm Interview");
        }
    }
}
