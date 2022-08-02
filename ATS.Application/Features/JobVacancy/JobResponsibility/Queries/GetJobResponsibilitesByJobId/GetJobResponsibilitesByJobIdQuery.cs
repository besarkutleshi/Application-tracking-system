using ATS.Application.DTO_s.OpenJob.JobResponsibility;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobResponsibility.Queries.GetJobResponsibilitesByJobId
{
    public record GetJobResponsibilitesByJobIdQuery(int responsibilityId) : IRequest<List<ListResponsibilityDTO>>;
}
