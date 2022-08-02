using ATS.Application.DTO_s.OpenJob.JobRequirements;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobRequirement.Commands.UpdateJobRequirement
{
    public record UpdateJobRequirementCommand(UpdateRequirementDTO updateRequirement) : IRequest<bool>;
}
