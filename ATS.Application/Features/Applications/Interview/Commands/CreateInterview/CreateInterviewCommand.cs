using ATS.Application.DTO_s.Administration.Applications.Interview;
using MediatR;

namespace ATS.Application.Features.Applications.Interview.Commands.CreateInterview
{
    public record CreateInterviewCommand(CreateInterviewDTO createInterview) : IRequest<CreateInterviewDTO>;
}
