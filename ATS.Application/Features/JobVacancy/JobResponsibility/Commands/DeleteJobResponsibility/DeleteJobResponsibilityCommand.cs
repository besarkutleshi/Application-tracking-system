using MediatR;

namespace ATS.Application.Features.JobVacancy.JobResponsibility.Commands.DeleteJobResponsibility
{
    public record DeleteJobResponsibilityCommand(int responsibilityId) : IRequest<bool>;
}
