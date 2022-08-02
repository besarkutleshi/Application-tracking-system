using ATS.Application.DTO_s.OpenJob.JobRequirements;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobRequirement.Commands.CreateJobRequirement
{
    public record CreateJobRequirementCommand(CreateRequirementDTO createRequirement) : IRequest<CreateRequirementDTO>;
}
