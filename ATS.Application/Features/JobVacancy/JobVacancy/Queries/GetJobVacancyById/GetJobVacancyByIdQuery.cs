using ATS.Application.DTO_s.OpenJob.JobVacancy;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobVacancy.Queries.GetJobVacancyById
{
    public record GetJobVacancyByIdQuery(int jobId) : IRequest<ListJobDTO>;
}
