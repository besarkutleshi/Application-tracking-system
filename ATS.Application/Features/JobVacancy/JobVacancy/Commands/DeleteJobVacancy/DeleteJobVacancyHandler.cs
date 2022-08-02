using ATS.Application.Contracts.Persistence.JobVacancy;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobVacancy.Commands.DeleteJobVacancy
{
    public class DeleteJobVacancyHandler : IRequestHandler<DeleteJobVacancyCommand, bool>
    {
        private readonly IOpenJob _openJob;

        public DeleteJobVacancyHandler(IOpenJob openJob)
        {
            _openJob = openJob;
        }

        public async Task<bool> Handle(DeleteJobVacancyCommand request, CancellationToken cancellationToken)
        {
            if (request.jobId < 1) throw new Exception("Job Id must be greater than 0");

            return await _openJob.DeleteAsync(request.jobId, cancellationToken);
        }
    }
}
