using ATS.Application.DTO_s.OpenJob.JobResponsibility;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobResponsibility.Commands.UpdateJobResponsibilty
{
    public record UpdateJobResponsibilityCommand(UpdateResponsibilityDTO updateResponsibility) : IRequest<bool>;
}
