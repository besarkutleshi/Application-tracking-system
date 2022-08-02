using ATS.Application.DTO_s.Administration.Applications.Interview;
using MediatR;

namespace ATS.Application.Features.Applications.Interview.Commands.UpdateInterview
{
    public record UpdateInterviewCommand(UpdateInterviewDTO update) : IRequest<bool>;
}
