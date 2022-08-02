using ATS.Application.DTO_s.OpenJob.JobVacancy;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobVacancy.Commands.UpdateJobVacancy
{
    public record UpdateJobVacancyCommand(UpdateJobDTO updateJob) : IRequest<bool>;
}
