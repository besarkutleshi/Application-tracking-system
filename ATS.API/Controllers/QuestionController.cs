using ATS.Application.Features.Applications.Question.Queries.GetApplicationQuestions;
using ATS.Application.Features.Applications.Question.Queries.GetQuestions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ATS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions(CancellationToken token)
        {
            var getQuestionsQuery = new GetQuestionsQuery();
            var list = await _mediator.Send(getQuestionsQuery, token);

            return Ok(list);
        }

        [HttpGet("{applicationId}/applicationQuestions")]
        public async Task<IActionResult> GetApplicationQuestions(int applicationId, CancellationToken token)
        {
            var getApplicationQuestions = new GetApplicationQuestionsQuery(applicationId);
            var list = await _mediator.Send(getApplicationQuestions, token);

            return Ok(list);
        }
    }
}
