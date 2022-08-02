using MediatR;

namespace ATS.Application.Features.Applications.Interview.Commands.DeleteInterview
{
    public record DeleteInterviewCommand(int id) : IRequest<bool>;
}
