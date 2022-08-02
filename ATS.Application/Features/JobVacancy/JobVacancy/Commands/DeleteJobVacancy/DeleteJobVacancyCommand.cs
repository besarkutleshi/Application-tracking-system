using MediatR;

namespace ATS.Application.Features.JobVacancy.JobVacancy.Commands.DeleteJobVacancy
{
    public record DeleteJobVacancyCommand(int jobId) : IRequest<bool>;
}
