using ATS.Application.DTO_s.OpenJob.JobVacancy;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobVacancy.Queries.GetJobVacancies
{
    public record GetJobVacanciesQuery : IRequest<List<ListJobDTO>>;
}
