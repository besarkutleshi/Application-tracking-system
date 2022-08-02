using ATS.Application.DTO_s.OpenJob.JobResponsibility;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobResponsibility.Commands.CreateJobResponsibility
{
    public record CreateJobResponsibilityCommand(CreateResponsibilityDTO createResponsibility) : IRequest<CreateResponsibilityDTO>;
}
