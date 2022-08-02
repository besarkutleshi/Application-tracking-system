using ATS.Application.DTO_s.OpenJob.JobVacancy;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobVacancy.Commands.CreateJobVacancy
{
    public record CreateJobVacancyCommand(CreateJobDTO createJob) : IRequest<CreateJobDTO>;
}
