using MediatR;

namespace ATS.Application.Features.Applications.Interview.Commands.ConfrimInterview
{
    public record ConfirmInterviewCommand(int interviewId, short value) : IRequest<bool>;
}
