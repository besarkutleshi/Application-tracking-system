using ATS.Application.DTO_s.OpenJob.JobRequirements;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobRequirement.Queries.GetJobRequirementsByJobId
{
    public record GetRequirementsByJobIdQuery(int jobId): IRequest<List<ListRequirementsDTO>>;
}
